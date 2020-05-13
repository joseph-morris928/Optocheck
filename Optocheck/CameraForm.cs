using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Thorlabs.TSI.Core;
using Thorlabs.TSI.CoreInterfaces;
using Thorlabs.TSI.ImageData;
using Thorlabs.TSI.ImageDataInterfaces;
using Thorlabs.TSI.TLCamera;
using Thorlabs.TSI.TLCameraInterfaces;

namespace Optocheck
{
    public partial class CameraForm : Form
    {
        private ITLCameraSDK sdk;
        private ITLCamera cam;
        private IList<String> nums;

        private class LockableSharedData
        {
            public bool IsUpdateUIRequested;

            public ImageDataUShort1D LatestImageData;
        }

        private readonly DispatcherTimer _dispatcherTimerUpdateUI = new DispatcherTimer();
        private readonly LockableSharedData _lockableSharedData = new LockableSharedData();
        private Bitmap _latestDisplayBitmap;
        //public uint _bitDepth;

        public CameraForm()
        {
            InitializeComponent();
            
        }

        private Optocheck mainForm = null;
        public CameraForm(Form callingForm, ref ITLCamera cam_in, ref ITLCameraSDK sdk_in) // if cam is already opened prior to opening form
        {
            mainForm = callingForm as Optocheck;
            //sdk = TLCameraSDK.OpenTLCameraSDK();
            sdk = sdk_in;
            cam = cam_in;
            nums = sdk.DiscoverAvailableCameras();
            InitializeComponent();
        }

        public CameraForm(Form callingForm, ref ITLCameraSDK sdk_in) // if cam is not opened
        {
            mainForm = callingForm as Optocheck;
            //sdk = TLCameraSDK.OpenTLCameraSDK();
            sdk = sdk_in;
            nums = sdk.DiscoverAvailableCameras();
            InitializeComponent();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
                // Display each comport available for Arduino to connect to computer
                foreach (string mynums in nums)
                {
                    cameraSelection.Items.Add(mynums);
                    if (nums[0] != null)
                    {
                        cameraSelection.SelectedItem = nums[0];
                        connectButton.Enabled = true;
                    }
                }

            if (cam != null)
            {
                this.cam.OnImageFrameAvailable += OnFrameAvailable;
                //this._bitDepth = cam.BitDepth;

                this.cam.OperationMode = OperationMode.SoftwareTriggered;
                this.cam.FramesPerTrigger_zeroForUnlimited = 0;
                if (!cam.IsArmed) this.cam.Arm();
                this.cam.IssueSoftwareTrigger();

                this._dispatcherTimerUpdateUI.Interval = TimeSpan.FromMilliseconds(50);
                this._dispatcherTimerUpdateUI.Tick += this.DispatcherTimerUpdateUI_Tick;
                this._dispatcherTimerUpdateUI.Start();

                connectionStatusLabel.Visible = true;
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                //this.mainForm.CameraConnectivityText = "Connected";
                //this.mainForm.CameraConnectivityColor = Color.Green;
                imageOutput.Visible = true;
            }

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            cam = sdk.OpenCamera(cameraSelection.SelectedItem.ToString(), false);
            //Set Camera parameters
            //cam.OperationMode = OperationMode.SoftwareTriggered;
            //cam.ExposureTime_us = 10000;
            //cam.FramesPerTrigger_zeroForUnlimited = 1;//Camera will only pull 1 frame
            //cam.OnImageFrameAvailable += OnFrameAvailable; // Register for Image Received Event
            //cam.Arm();


            this.cam.OnImageFrameAvailable += OnFrameAvailable;
            //this._bitDepth = cam.BitDepth;

            this.cam.OperationMode = OperationMode.SoftwareTriggered;
            this.cam.Arm();
            this.cam.IssueSoftwareTrigger();


            this._dispatcherTimerUpdateUI.Interval = TimeSpan.FromMilliseconds(50);
            this._dispatcherTimerUpdateUI.Tick += this.DispatcherTimerUpdateUI_Tick;
            this._dispatcherTimerUpdateUI.Start();

            connectionStatusLabel.Visible = true;
            connectButton.Enabled = false;
            disconnectButton.Enabled = true;
            this.mainForm.CameraConnectivityText = "Connected";
            this.mainForm.CameraConnectivityColor = Color.Green;
            imageOutput.Visible = true;
        }

        private void OnFrameAvailable(ITLCamera sender, EventArgs eventargs)
        {
            lock (this._lockableSharedData)
            {
                var frame = sender.GetPendingFrameOrNull();

                if (frame != null)
                {
                    this._lockableSharedData.LatestImageData = (ImageDataUShort1D)(frame.ImageData);
                    this._lockableSharedData.IsUpdateUIRequested = true;
                }
            }
        }

        private void DispatcherTimerUpdateUI_Tick(object sender, EventArgs e)
        {
            lock (this._lockableSharedData)
            {
                if (this._lockableSharedData.IsUpdateUIRequested)
                {
                    if (this._latestDisplayBitmap != null)
                    {
                        this._latestDisplayBitmap.Dispose();
                        this._latestDisplayBitmap = null;
                    }
                    this._latestDisplayBitmap = this._lockableSharedData.LatestImageData.ToBitmap_Format24bppRgb();
                    this.imageOutput.Invalidate();
                    this._lockableSharedData.IsUpdateUIRequested = false;
                }
            }
        }

        private void imageOutput_Paint(object sender, PaintEventArgs e)
        {
            if (this._latestDisplayBitmap != null)
            {
                var scale = Math.Min((float)this.imageOutput.Width / this._latestDisplayBitmap.Width, (float)this.imageOutput.Height / this._latestDisplayBitmap.Height);
                e.Graphics.DrawImage(this._latestDisplayBitmap, new RectangleF(((float)this.imageOutput.Width - this._latestDisplayBitmap.Width * scale) / 2, ((float)this.imageOutput.Height - this._latestDisplayBitmap.Height * scale) / 2, this._latestDisplayBitmap.Width * scale, this._latestDisplayBitmap.Height * scale));
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (this.cam != null)
            {
                if (this.cam.IsArmed)
                {
                    this.cam.Disarm();
                }
                if (this._dispatcherTimerUpdateUI != null)
                {
                    this._dispatcherTimerUpdateUI.Stop();
                    this._dispatcherTimerUpdateUI.Tick -= this.DispatcherTimerUpdateUI_Tick;
                }
                this.cam.OnImageFrameAvailable -= this.OnFrameAvailable;
                this.cam.Dispose();
                this.cam = null;
                this.mainForm.CameraConnectivityText = "Not Connected";
                this.mainForm.CameraConnectivityColor = Color.Red;
                connectionStatusLabel.Visible = false;
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
                imageOutput.Visible = false;
            }
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.cam != null)
            {
                if (this.cam.IsArmed)
                {
                    this.cam.Disarm();
                }
                if (this._dispatcherTimerUpdateUI != null)
                {
                    this._dispatcherTimerUpdateUI.Stop();
                    this._dispatcherTimerUpdateUI.Tick -= this.DispatcherTimerUpdateUI_Tick;
                }
                this.cam.OnImageFrameAvailable -= this.OnFrameAvailable;
            }
            
        }
    }
}
