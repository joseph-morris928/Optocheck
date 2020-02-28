using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
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
        //public List<Label> errorValueLabels = new List<Label>();
        public List<Label> statusValueLabels = new List<Label>();

        public List<string> frontThresholds = new List<string>() { ">8.83 mm\rand\r<8.93 mm", ">-1° and <1°", ">-0.06°\rand\r<0.06°", ">-0.06°\rand\r<0.06°" };
        public List<string> measurementNames = new List<string>() { "Position", "Roll", "Pitch", "Yaw" };

        public string[,] valueArray = new string[4, 2];
        public string csvInfinityPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Infinity.csv";
        public string csvZboxPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Zbox.csv";
        public string csvFrontPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Front.csv";
        private bool isMessageBoxOpen = false;

        private ITLCameraSDK _tlCameraSDK;
        private ITLCamera _tlCamera;

        public Optocheck()
        {
            InitializeComponent();
            for (int i = 0; i < 4; ++i)
            {
                // add labels to all lists
                Label namelabel = (Label)this.Controls.Find("measurementName" + (i + 1), true)[0];
                Label expectedlabel = (Label)this.Controls.Find("expectedValue" + (i + 1), true)[0];
                Label measuredlabel = (Label)this.Controls.Find("measuredValue" + (i + 1), true)[0];
                //Label errorlabel = (Label)this.Controls.Find("errorValue" + (i + 1), true)[0];
                Label statuslabel = (Label)this.Controls.Find("statusLabel" + (i + 1), true)[0];
                if (namelabel != null)
                    measurementNameLabels.Add(namelabel);
                if (measuredlabel != null)
                    measuredValueLabels.Add(measuredlabel);
                if (expectedlabel != null)
                    expectedValueLabels.Add(expectedlabel);
                //if (errorlabel != null)
                //    errorValueLabels.Add(errorlabel);
                if (statuslabel != null)
                    statusValueLabels.Add(statuslabel);
            }
            this._tlCameraSDK = TLCameraSDK.OpenTLCameraSDK();
            var serialNumbers = this._tlCameraSDK.DiscoverAvailableCameras();
            if (serialNumbers.Count == 0) snLabel.Text = "No cameras!";
            else if (serialNumbers.Count == 1) snLabel.Text = serialNumbers.First();
        }
        private void scanButton_click(object sender, EventArgs e)
        {
            if ((infinityRadioButton.Checked==true) || (zboxRadioButton.Checked==true) || (frontRadioButton.Checked==true))
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
            } else
            {
                MessageBox.Show("Please select a Mirror Type!", "Mirror Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    //errorValueLabels[i].Text = "";
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
                        //CalculateError();
                        PassOrFail();
                    } else CSVNotFound();
                } else if (zboxRadioButton.Checked == true)
                {
                    if (File.Exists(csvZboxPath))
                    {
                        ScanComplete(csvZboxPath);
                        //CalculateError();
                        PassOrFail();
                    } else CSVNotFound();
                } else if (frontRadioButton.Checked == true)
                {
                    if (File.Exists(csvFrontPath))
                    {
                        ScanComplete(csvFrontPath);
                        //CalculateError();
                        PassOrFail();
                    } else CSVNotFound();
                }
            }
            else scanProgressBar.Increment(1);
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
                    if (i == 0) measuredValueLabels[i].Text += " mm";
                    else measuredValueLabels[i].Text += "°";
                }

            }
        }

        private void CalculateError()
        {
            double measured_num, expected_num, numerator, error, percent_error = 0;
            for (int i = 0; i < 4; ++i)
            {
                measured_num = Convert.ToDouble(measuredValueLabels[i].Text); // convert measured value from string to double
                expected_num = Convert.ToDouble(expectedValueLabels[i].Text); // convert expected value from string to double
                numerator = measured_num - expected_num; // subtraction, creating numerator of percent error expression
                error = numerator / expected_num; // division, creating the error
                percent_error = Math.Round(error * 100, 2); // multiply by 100 to get a percentage and round to 2 decimal places
                //errorValueLabels[i].Text = percent_error.ToString() + "%"; // update the labels and append % symbol to end
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
            } else
            {
                // Play Failure Sound
                SoundPlayer failureSound = new SoundPlayer(@"C:\Windows\Media\chord.wav");
                failureSound.Play();
            }
        }


        private bool PositionCheck()
        {
            if (Convert.ToDouble(valueArray[0, 1]) > 8.83 && Convert.ToDouble(valueArray[0,1]) < 8.93)
            {
                statusLabel1.Text = "Pass";
                statusLabel1.BackColor = Color.Green;
                return true;
            } else
            {
                statusLabel1.Text = "Fail";
                statusLabel1.BackColor = Color.Red;
                return false;
            }
        }

        private bool RollCheck()
        {
            if (Convert.ToDouble(valueArray[1,1]) > -1 && Convert.ToDouble(valueArray[1,1]) < 1)
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
            if (Convert.ToDouble(valueArray[2,1]) > -0.06 && Convert.ToDouble(valueArray[2,1]) < 0.06)
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
            if (Convert.ToDouble(valueArray[3,1]) > -0.06 && Convert.ToDouble(valueArray[3,1]) < 0.06)
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
                expectedValueLabels[i].Text = "";
                measuredValueLabels[i].Text = "";
                //errorValueLabels[i].Text = "";
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
                } else if (clickedLabel.Text== "Roll")
                {
                    measurementPicture.pictureBox1.Image = Image.FromFile(imagePath + "RollCheck.png");
                    measurementPicture.Text = "Roll Check";
                } else if (clickedLabel.Text == "Pitch")
                {
                    measurementPicture.pictureBox1.Image = Image.FromFile(imagePath + "PitchCheck.png");
                    measurementPicture.Text = "Pitch Check";
                } else if (clickedLabel.Text == "Yaw")
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
    }
}
