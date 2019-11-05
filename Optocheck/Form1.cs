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
        public List<Label> measuredValueLabels = new List<Label>();
        public List<Label> expectedValueLabels = new List<Label>();
        public List<Label> errorValueLabels = new List<Label>();
        public List<Label> statusValueLabels = new List<Label>();
        public string[,] valueArray = new string[10, 2];
        Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        public Optocheck()
        {
            InitializeComponent();
            for (int i = 0; i < 10; ++i)
            {
                // add labels to all lists
                Label measuredlabel = (Label)this.Controls.Find("measuredValue" + (i + 1), true)[0];
                Label expectedlabel = (Label)this.Controls.Find("expectedValue" + (i + 1), true)[0];
                Label errorlabel = (Label)this.Controls.Find("errorValue" + (i + 1), true)[0];
                Label statuslabel = (Label)this.Controls.Find("statusLabel" + (i + 1), true)[0];
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

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
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the scan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            if (scanProgressBar.Value == 100)
            {
                scanTimer.Stop();
                scanButton.Enabled = true;
                cancelScanButton.Enabled = false;
                infinityRadioButton.Enabled = true;
                zboxRadioButton.Enabled = true;
                frontRadioButton.Enabled = true;
                // Functions after scan is complete
                if (File.Exists(@"C:\Users\joemorris\Desktop\Iradion\Test CSV File.csv"))
                {
                    ScanComplete();
                    CalculateError();
                    PassOrFail();
                } else
                {
                    MessageBox.Show("The .CSV file cannot be found!");
                }
            } else
            {
                scanProgressBar.Increment(1);
            }
        }

        private void ScanComplete()
        {
            watch.Start();
            using (var reader = new StreamReader(@"C:\Users\joemorris\Desktop\Iradion\Test CSV File.csv"))
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

            }
        }
    }
}
