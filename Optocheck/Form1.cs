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

namespace Optocheck
{
    public partial class Optocheck : Form
    {
        public List<Label> measurementNameLabels = new List<Label>();
        public List<Label> expectedValueLabels = new List<Label>();
        public List<Label> measuredValueLabels = new List<Label>();
        public List<Label> errorValueLabels = new List<Label>();
        public List<Label> statusValueLabels = new List<Label>();
        public List<string> infinityValues = new List<string>() { "0.13", "0.43", "0.23", "0.7", "0.36", "0.52", "0.94", "1.12", "0.74", "0.68"};
        public List<string> zboxValues = new List<string>() { "0.13", "0.23", "0.28", "0.42", "0.51", "0.58", "0.75", "0.82", "0.96", "1.06" };
        public List<string> frontValues = new List<string>() { "1.03", "0.87", "0.75", "0.72", "0.64", "0.52", "0.35", "0.34", "0.22", "0.07" };
        public string[,] valueArray = new string[10, 2];
        public string csvInfinityPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Infinity.csv";
        public string csvZboxPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Zbox.csv";
        public string csvFrontPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Iradion\Front.csv";
        private bool isMessageBoxOpen = false;

        public Optocheck()
        {
            InitializeComponent();
            for (int i = 0; i < 10; ++i)
            {
                // add labels to all lists
                Label namelabel = (Label)this.Controls.Find("measurementName" + (i + 1), true)[0];
                Label expectedlabel = (Label)this.Controls.Find("expectedValue" + (i + 1), true)[0];
                Label measuredlabel = (Label)this.Controls.Find("measuredValue" + (i + 1), true)[0];
                Label errorlabel = (Label)this.Controls.Find("errorValue" + (i + 1), true)[0];
                Label statuslabel = (Label)this.Controls.Find("statusLabel" + (i + 1), true)[0];
                if (namelabel != null)
                    measurementNameLabels.Add(namelabel);
                if (measuredlabel != null)
                    measuredValueLabels.Add(measuredlabel);
                if (expectedlabel != null)
                    expectedValueLabels.Add(expectedlabel);
                if (errorlabel != null)
                    errorValueLabels.Add(errorlabel);
                if (statuslabel != null)
                    statusValueLabels.Add(statuslabel);
            }
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
                for (int i = 0; i < 10; ++i)
                {
                    if (infinityRadioButton.Checked == true) expectedValueLabels[i].Text = infinityValues[i];
                    else if (zboxRadioButton.Checked == true) expectedValueLabels[i].Text = zboxValues[i];
                    else if (frontRadioButton.Checked == true) expectedValueLabels[i].Text = frontValues[i];
                    measuredValueLabels[i].Text = "Scanning...";
                    errorValueLabels[i].Text = "Calculating...";
                    statusValueLabels[i].Text = "Calculating...";
                    statusValueLabels[i].BackColor = SystemColors.Control;
                }
                scanStatusLabel.Visible = false;
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
                scanStatusLabel.Text = "Scan Canceled Successfully!";
                scanStatusLabel.Visible = true;
                scanStatusLabel.Left = (this.ClientSize.Width - scanStatusLabel.Width) / 2;
                for (int i = 0; i < 10; ++i)
                {
                    expectedValueLabels[i].Text = "";
                    measuredValueLabels[i].Text = "";
                    errorValueLabels[i].Text = "";
                    statusValueLabels[i].Text = "";
                }
                
            }
            
        }

        private void exitButton_click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close Optocheck?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
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
                        CalculateError();
                        PassOrFail();
                    } else CSVNotFound();
                } else if (zboxRadioButton.Checked == true)
                {
                    if (File.Exists(csvZboxPath))
                    {
                        ScanComplete(csvZboxPath);
                        CalculateError();
                        PassOrFail();
                    } else CSVNotFound();
                } else if (frontRadioButton.Checked == true)
                {
                    if (File.Exists(csvFrontPath))
                    {
                        ScanComplete(csvFrontPath);
                        CalculateError();
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
                for (int i = 0; i < 10; ++i)
                {
                    // Parse CSV and update labels
                    var line = reader.ReadLine(); // read one line
                    var values = line.Split(','); // separate values by commas and store in values array
                    valueArray[i, 0] = values[0]; // add name of value to array
                    valueArray[i, 1] = values[1]; // add measured value to array
                    measuredValueLabels[i].Text = valueArray[i, 1]; // update measured value label
                }

            }
        }

        private void CalculateError()
        {
            double measured_num, expected_num, numerator, error, percent_error = 0;
            for (int i = 0; i < 10; ++i)
            {
                measured_num = Convert.ToDouble(measuredValueLabels[i].Text); // convert measured value from string to double
                expected_num = Convert.ToDouble(expectedValueLabels[i].Text); // convert expected value from string to double
                numerator = measured_num - expected_num; // subtraction, creating numerator of percent error expression
                error = numerator / expected_num; // division, creating the error
                percent_error = Math.Round(error * 100, 2); // multiply by 100 to get a percentage and round to 2 decimal places
                errorValueLabels[i].Text = percent_error.ToString() + "%"; // update the labels and append % symbol to end
            }
        }

        private void PassOrFail()
        {
            int numOfPass = 0;
            for (int i = 0; i < 10; ++i)
            {
                if (Math.Abs(Convert.ToDouble(errorValueLabels[i].Text.TrimEnd('%'))) < 10)
                    // remove % symbol, convert string to double, and take absolute value to compare to 10%
                {
                    statusValueLabels[i].Text = "Pass";
                    statusValueLabels[i].BackColor = Color.Green;
                    numOfPass++;
                } else
                {
                    statusValueLabels[i].Text = "Fail";
                    statusValueLabels[i].BackColor = Color.Red;
                }
            }
            if (numOfPass == 10)
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

        private void CSVNotFound()
        {
            MessageBox.Show("The .CSV file cannot be found!");
            for (int i = 0; i < 10; ++i)
            {
                expectedValueLabels[i].Text = "";
                measuredValueLabels[i].Text = "";
                errorValueLabels[i].Text = "";
                statusValueLabels[i].Text = "";
            }
            scanProgressBar.Value = 0;
            infinityRadioButton.Checked = false;
            zboxRadioButton.Checked = false;
            frontRadioButton.Checked = false;
        }
    }
}
