using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thorlabs.TSI.Core;
using Thorlabs.TSI.CoreInterfaces;
using Thorlabs.TSI.ImageData;
using Thorlabs.TSI.ImageDataInterfaces;
using Thorlabs.TSI.TLCamera;
using Thorlabs.TSI.TLCameraInterfaces;


namespace Optocheck
{
    public partial class Optocheck : Form
    {
        public List<Label> measurementNameLabels = new List<Label>();
        public List<Label> expectedValueLabels = new List<Label>();
        public List<Label> measuredValueLabels = new List<Label>();
        public List<Label> statusValueLabels = new List<Label>();

        // Expected Measurements to be displayed on labels
        public List<string> frontThresholds = new List<string>() { ">8.83 mm\rand\r<8.93 mm", ">-1° and <1°", ">-0.06°\rand\r<0.06°", ">-0.06°\rand\r<0.06°" };
        public List<string> zboxThresholds = new List<string>() { };
        public List<string> infinityThresholds = new List<string>() { };
        public List<string> measurementNames = new List<string>() { "Position", "Roll", "Pitch", "Yaw" };

        string iradionPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Iradion";
        public string[,] valueArray = new string[4, 2];
        public string csvInfinityPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Infinity.csv";
        public string csvZboxPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Zbox.csv";
        public string csvFrontPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Front.csv";
        string[] lines;
        string imagesFolder = "";
        string imagesPath = "";


        private bool isMessageBoxOpen = false;

        private ITLCameraSDK sdk;
        private ITLCamera cam = null;
        private IList<String> nums;
        SerialPort port;
        string[] ports;



        public Optocheck()
        {
            InitializeComponent();
            for (int i = 0; i < 4; ++i)
            {
                // add labels to all lists
                Label namelabel = (Label)this.Controls.Find("measurementName" + (i + 1), true)[0];
                Label expectedlabel = (Label)this.Controls.Find("expectedValue" + (i + 1), true)[0];
                Label measuredlabel = (Label)this.Controls.Find("measuredValue" + (i + 1), true)[0];
                Label statuslabel = (Label)this.Controls.Find("statusLabel" + (i + 1), true)[0];
                if (namelabel != null)
                    measurementNameLabels.Add(namelabel);
                if (measuredlabel != null)
                    measuredValueLabels.Add(measuredlabel);
                if (expectedlabel != null)
                    expectedValueLabels.Add(expectedlabel);
                if (statuslabel != null)
                    statusValueLabels.Add(statuslabel);
            }


            lines = System.IO.File.ReadAllLines(iradionPath + "\\CNC Control.txt"); // G code .txt file to control CNC
            this.menuStrip1.BackColor = Color.FromKnownColor(KnownColor.Control); // MenuBar color matches rest of form

            sdk = TLCameraSDK.OpenTLCameraSDK();
            nums = sdk.DiscoverAvailableCameras();


        }

        private void Optocheck_Load(object sender, EventArgs e)
        {
            ports = SerialPort.GetPortNames();
            sdk.OnCameraConnect += Sdk_OnCameraConnect; // Constantly check for if camera gets connected
            sdk.OnCameraDisconnect += Sdk_OnCameraDisconnect; // Constantly check for if camera gets disconnected
            iradionPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Iradion";
            imagesFolder = System.IO.Directory.CreateDirectory(iradionPath + "\\Images").ToString();
            imagesPath = System.IO.Path.Combine(iradionPath, imagesFolder).ToString();

            if (ports.Length > 0) // if there is at least one COM port
            {
                port = new SerialPort(ports[0], 115200, Parity.None, 8, StopBits.One);
                try
                {
                    port.Open(); // open first available port
                    statusOfCNCLabel.Text = "Connected";
                    statusOfCNCLabel.ForeColor = Color.Green;
                }
                catch (Exception)
                {

                }

            }

            if (nums.Count > 0) // if there is at least one camera connected
            {


                cam = sdk.OpenCamera(nums[0], false); // auto open first available cam
                statusOfCameraLabel.Text = "Connected";
                statusOfCameraLabel.ForeColor = Color.Green;

                //Set Camera parameters
                this.cam.OperationMode = OperationMode.SoftwareTriggered;
                this.cam.ExposureTime_us = 10000;
                this.cam.FramesPerTrigger_zeroForUnlimited = 1; // Camera will only pull 1 frame
                this.cam.OnImageFrameAvailable += OnFrameAvailable; // Register for Image Received Event
                if (!cam.IsArmed) this.cam.Arm(); // arm the camera to take images

            }


        }

        public void OnFrameAvailable(ITLCamera sender, EventArgs eventargs)
        {
            //Get Frame if available, otherwise get Null
            Frame availableFrame = sender.GetPendingFrameOrNull();
            if (availableFrame != null)
            {
                Console.WriteLine("Image Available from Camera");
                //image was received. Process image
                Bitmap toSave = availableFrame.ImageData.ToBitmap_Format24bppRgb(); //creates Bitmap
                toSave.Save(imagesPath + "\\Image" + DateTime.Now.ToString().Replace('/', '-').Replace(':', ',') + ".png"); // Save image to Desktop/Iradion/Images
            }
        }

        private void scanButton_click(object sender, EventArgs e)
        {
            if ((infinityRadioButton.Checked == true) || (zboxRadioButton.Checked == true) || (frontRadioButton.Checked == true))
            {


                // Start of CNC and Image Acquisition


                if (port != null && cam != null)
                {
                    if (!port.IsOpen)
                    {
                        port.Open();
                    }


                    if (port.IsOpen && cam.IsArmed)
                    {
                        scanProgressBar.Value = 0;
                        scanButton.Enabled = false;
                        cancelScanButton.Enabled = true;
                        infinityRadioButton.Enabled = false;
                        zboxRadioButton.Enabled = false;
                        frontRadioButton.Enabled = false;

                        scanTimer.Start();

                        for (int i = 0; i < 4; ++i)
                        {
                            //if (infinityRadioButton.Checked == true) expectedValueLabels[i].Text = infinityValues[i];
                            //else if (zboxRadioButton.Checked == true) expectedValueLabels[i].Text = zboxValues[i];
                            if (frontRadioButton.Checked == true) expectedValueLabels[i].Text = frontThresholds[i];
                            measurementNameLabels[i].Text = measurementNames[i];
                            measuredValueLabels[i].Text = "Scanning...";
                            //errorValueLabels[i].Text = "Calculating...";
                            statusValueLabels[i].Text = "Calculating...";
                            statusValueLabels[i].BackColor = SystemColors.Control;
                        }

                        var mre = new AutoResetEvent(false);

                        var buffer = new StringBuilder();
                        string mostRecent = "";

                        port.DataReceived += (s, e2) =>
                        {
                            buffer.Append(port.ReadExisting());
                            if (buffer.ToString().IndexOf("\r\n") >= 0)
                            {
                                Console.WriteLine("Got response: {0}", buffer);
                                if (mostRecent.Contains("G4 P2"))
                                {
                                    cam.IssueSoftwareTrigger();
                                }


                                mre.Set(); //allow loop to continue
                                buffer.Clear();
                            }
                        };

                        var responseTimeout = TimeSpan.FromSeconds(15);

                        foreach (var command in lines)
                        {
                            try
                            {
                                Console.WriteLine("Write '{0}' to {1}", command, port.PortName);
                                port.WriteLine(command);
                                mostRecent = command;

                                Console.WriteLine("Waiting for response...");


                                if (!mre.WaitOne(responseTimeout)) // THIS IS WHAT CAUSES THREAD TO LOCK UP
                                // calling WaitOne on main thread is bad practice, can not determine another solution
                                {
                                    Console.WriteLine("Did not receive response");

                                }
                            }
                            catch (TimeoutException)
                            {
                                Console.WriteLine("Write took longer than expected");
                            }
                            catch
                            {
                                Console.WriteLine("Failed to write to port");
                            }
                        }

                        Console.ReadLine();
                    }
                    else MessageBox.Show("Please ensure both your camera and CNC are properly connected!");
                }
                else MessageBox.Show("Please ensure both your camera and CNC are properly connected!");


                // End of CNC and Image Acquisition


            }
            else
            {
                MessageBox.Show("Please select a Mirror Type!", "Mirror Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // THIS BUTTON DOES NOT WORK BECAUSE THE THREAD LOCKS UP DURING THE ONLY TIME IT IS POSSIBLE TO CLICK
        private void cancelScanButton_Click(object sender, EventArgs e)
        {
            isMessageBoxOpen = true;
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the scan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            isMessageBoxOpen = false;
            if (result == DialogResult.Yes)
            {
                scanTimer.Stop();
                scanProgressBar.Value = 0;
                scanButton.Enabled = true;
                cancelScanButton.Enabled = false;
                infinityRadioButton.Enabled = true;
                zboxRadioButton.Enabled = true;
                frontRadioButton.Enabled = true;
                for (int i = 0; i < 4; ++i)
                {
                    expectedValueLabels[i].Text = "";
                    measuredValueLabels[i].Text = "";
                    statusValueLabels[i].Text = "";
                }
                MessageBox.Show("Scan Cancelled Successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void exitButton_click(object sender, EventArgs e)
        {
            isMessageBoxOpen = true;
            DialogResult result = MessageBox.Show("Are you sure you want to close Optocheck?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            isMessageBoxOpen = false;
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void scanTimer_Tick(object sender, EventArgs e)
        {
            if (isMessageBoxOpen) return;

            if (scanProgressBar.Value == 100)
            {
                scanTimer.Stop();
                scanButton.Enabled = true;
                cancelScanButton.Enabled = false;
                infinityRadioButton.Enabled = true;
                zboxRadioButton.Enabled = true;
                frontRadioButton.Enabled = true;
                // Functions after scan is complete
                if (infinityRadioButton.Checked == true)
                {
                    if (File.Exists(csvInfinityPath))
                    {
                        ScanComplete(csvInfinityPath);
                        PassOrFail();
                    }
                    else CSVNotFound();
                }
                else if (zboxRadioButton.Checked == true)
                {
                    if (File.Exists(csvZboxPath))
                    {
                        ScanComplete(csvZboxPath);
                        PassOrFail();
                    }
                    else CSVNotFound();
                }
                else if (frontRadioButton.Checked == true)
                {
                    if (File.Exists(csvFrontPath))
                    {
                        ScanComplete(csvFrontPath);
                        PassOrFail();
                    }
                    else CSVNotFound();
                }
            }
            else scanProgressBar.Increment(1);
            // Progress bar implementation could be improved, but could not test due to the thread locking up!
        }

        private void ScanComplete(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine(); // header line, to be skipped
                for (int i = 0; i < 4; ++i)
                {
                    // Parse CSV and update labels
                    var line = reader.ReadLine(); // read one line
                    var values = line.Split(','); // separate values by commas and store in values array
                    valueArray[i, 0] = values[0]; // add name of value to array
                    valueArray[i, 1] = values[1]; // add measured value to array
                    measuredValueLabels[i].Text = valueArray[i, 1]; // update measured value label
                    statusValueLabels[i].Font = new Font("Microsoft Sans Serif", 24);
                    if (i == 0) measuredValueLabels[i].Text += " mm";
                    else measuredValueLabels[i].Text += "°";
                }

            }
        }

        private void PassOrFail()
        {
            int numOfPass = 0;
            if (PositionCheck() == true) numOfPass++;
            if (RollCheck() == true) numOfPass++;
            if (PitchCheck() == true) numOfPass++;
            if (YawCheck() == true) numOfPass++;

            if (numOfPass == 4)
            {
                // Play Success Sound
                SoundPlayer successSound = new SoundPlayer(@"C:\Windows\Media\tada.wav");
                successSound.Play();
            }
            else
            {
                // Play Failure Sound
                SoundPlayer failureSound = new SoundPlayer(@"C:\Windows\Media\chord.wav");
                failureSound.Play();
            }
        }


        private bool PositionCheck()
        {
            if (Convert.ToDouble(valueArray[0, 1]) > 8.83 && Convert.ToDouble(valueArray[0, 1]) < 8.93) // threshold values to compare
            {
                statusLabel1.Text = "Pass";
                statusLabel1.BackColor = Color.Green;
                return true;
            }
            else
            {
                statusLabel1.Text = "Fail";
                statusLabel1.BackColor = Color.Red;
                return false;
            }
        }

        private bool RollCheck()
        {
            if (Convert.ToDouble(valueArray[1, 1]) > -1 && Convert.ToDouble(valueArray[1, 1]) < 1) // threshold values to compare
            {
                statusLabel2.Text = "Pass";
                statusLabel2.BackColor = Color.Green;
                return true;
            }
            else
            {
                statusLabel2.Text = "Fail";
                statusLabel2.BackColor = Color.Red;
                return false;
            }
        }

        private bool PitchCheck()
        {
            if (Convert.ToDouble(valueArray[2, 1]) > -0.06 && Convert.ToDouble(valueArray[2, 1]) < 0.06) // threshold values to compare
            {
                statusLabel3.Text = "Pass";
                statusLabel3.BackColor = Color.Green;
                return true;
            }
            else
            {
                statusLabel3.Text = "Fail";
                statusLabel3.BackColor = Color.Red;
                return false;
            }
        }

        private bool YawCheck()
        {
            if (Convert.ToDouble(valueArray[3, 1]) > -0.06 && Convert.ToDouble(valueArray[3, 1]) < 0.06) // threshold values to compare
            {
                statusLabel4.Text = "Pass";
                statusLabel4.BackColor = Color.Green;
                return true;
            }
            else
            {
                statusLabel4.Text = "Fail";
                statusLabel4.BackColor = Color.Red;
                return false;
            }
        }

        private void CSVNotFound()
        {
            MessageBox.Show("The .CSV file cannot be found!");
            for (int i = 0; i < 4; ++i)
            {
                measurementNameLabels[i].Text = "";
                expectedValueLabels[i].Text = "";
                measuredValueLabels[i].Text = "";
                statusValueLabels[i].Text = "";
            }
            scanProgressBar.Value = 0;
            infinityRadioButton.Checked = false;
            zboxRadioButton.Checked = false;
            frontRadioButton.Checked = false;
        }

        private void measurementName_Click(object sender, EventArgs e)
        {
            MeasurementPicture measurementPicture = new MeasurementPicture();
            Label clickedLabel = sender as Label;
            string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\";

            if (clickedLabel != null)
            {
                if (clickedLabel.Text == "Position")
                {
                    measurementPicture.pictureBox1.Image = Image.FromFile(imagePath + "PositionCheck.png");
                    measurementPicture.Text = "Position Check";
                }
                else if (clickedLabel.Text == "Roll")
                {
                    measurementPicture.pictureBox1.Image = Image.FromFile(imagePath + "RollCheck.png");
                    measurementPicture.Text = "Roll Check";
                }
                else if (clickedLabel.Text == "Pitch")
                {
                    measurementPicture.pictureBox1.Image = Image.FromFile(imagePath + "PitchCheck.png");
                    measurementPicture.Text = "Pitch Check";
                }
                else if (clickedLabel.Text == "Yaw")
                {
                    measurementPicture.pictureBox1.Image = Image.FromFile(imagePath + "YawCheck.png");
                    measurementPicture.Text = "Yaw Check";
                }
                measurementPicture.ShowDialog();

            }
        }

        private void notYetWorkingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton.Checked == true)
            {
                MessageBox.Show("Please select a different mirror type. The " + clickedRadioButton.Text + " mirror type is not yet working but will be implemented in the near future.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clickedRadioButton.Checked = false;
            }

        }



        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(Color color);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.statusOfCameraLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.statusOfCameraLabel.Text = text;
            }
        }

        private void SetColor(Color color)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.statusOfCameraLabel.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                this.Invoke(d, new object[] { color });
            }
            else
            {
                this.statusOfCameraLabel.ForeColor = color;
            }
        }

        private void Sdk_OnCameraConnect(ITLCameraSDK sender, CameraConnectEventArgs eventArgs)
        {
            if (cam == null)
            {
                nums = sdk.DiscoverAvailableCameras();
                cam = sdk.OpenCamera(nums[0], false);

                SetText("Connected");
                SetColor(Color.Green);
            }
        }

        private void Sdk_OnCameraDisconnect(ITLCameraSDK sender, CameraDisconnectEventArgs eventArgs)
        {
            nums = sdk.DiscoverAvailableCameras();
            if (cam != null)
            {
                if (cam.IsArmed)
                {
                    cam.Disarm();
                }
                cam.Dispose();
                cam = null;

                SetText("Not Connected");
                SetColor(Color.Red);
            }

        }

        private void Optocheck_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (cam != null)
            {
                if (cam.IsArmed)
                {
                    cam.Disarm();
                }
                cam.Dispose();
                cam = null;
            }
            sdk.Dispose();
            if (port != null)
            {
                if (port.IsOpen)
                {
                    port.Close();
                }
            }


        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (cam != null)
            {
                this.cam.OnImageFrameAvailable -= OnFrameAvailable;
                if (this.cam.IsArmed) this.cam.Disarm();
                CameraForm cameraForm = new CameraForm(this, ref cam, ref sdk);
                cameraForm.ShowDialog();



            }
            else
            {
                CameraForm cameraForm = new CameraForm(this, ref sdk);
                cameraForm.ShowDialog();
            }
            // Run after Camera Form is closed:
            if (cam != null)
            {
                this.cam.OnImageFrameAvailable += OnFrameAvailable;
                this.cam.FramesPerTrigger_zeroForUnlimited = 1;
                if (!cam.IsArmed) cam.Arm();
            }
            
        }

        private void arduinoInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (port != null)
            {
                if (port.IsOpen)
                {
                    CNCForm cncForm = new CNCForm(this, port);
                    cncForm.ShowDialog();
                }
                else
                {
                    CNCForm cncForm = new CNCForm(this);
                    cncForm.ShowDialog();
                }
            }
            else MessageBox.Show("No CNC connected!");
            
        }

        public string CameraConnectivityText
        {
            get { return statusOfCameraLabel.Text; }
            set { statusOfCameraLabel.Text = value; }
        }

        public Color CameraConnectivityColor
        {
            get { return statusOfCameraLabel.ForeColor; }
            set { statusOfCameraLabel.ForeColor = value; }
        }

        public string CNCConnectivityText
        {
            get { return statusOfCNCLabel.Text; }
            set { statusOfCNCLabel.Text = value; }
        }

        public Color CNCConnectivityColor
        {
            get { return statusOfCNCLabel.ForeColor; }
            set { statusOfCNCLabel.ForeColor = value; }
        }
    }
}