using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public string[,] valueArray = new string[10, 2];
        public Optocheck()
        {
            InitializeComponent();
            for (int i = 0; i < 10; ++i)
            {
                Label measuredlabel = (Label)this.Controls.Find("measuredValue" + (i + 1), true)[0];
                Label expectedlabel = (Label)this.Controls.Find("expectedValue" + (i + 1), true)[0];
                Label errorlabel = (Label)this.Controls.Find("errorValue" + (i + 1), true)[0];
                if (measuredlabel != null)
                    measuredValueLabels.Add(measuredlabel);
                if (expectedlabel != null)
                    expectedValueLabels.Add(expectedlabel);
                if (errorlabel != null)
                    errorValueLabels.Add(errorlabel);
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
                    Label measuredlabel = (Label)this.Controls.Find("measuredValue" + (i + 1), true)[0];
                    Label errorlabel = (Label)this.Controls.Find("errorValue" + (i + 1), true)[0];
                    if (measuredlabel != null)
                        measuredlabel.Text = "Scanning...";
                    if (errorlabel != null)
                        errorlabel.Text = "Calculating...";
                }

                //Scan Status Label
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
                // Play Sound
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\Media\tada.wav");
                simpleSound.Play();
                ScanComplete();
            } else
            {
                scanProgressBar.Increment(1);
            }
        }

        private void ScanComplete()
        {
            using (var reader = new StreamReader(@"C:\Users\joemorris\Desktop\Iradion\Test CSV File.csv"))
            {
                reader.ReadLine(); //header line
                for (int i = 0; i < 10; ++i)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    valueArray[i, 0] = values[0]; //add name of value to array
                    valueArray[i, 1] = values[1]; //add measured value to array
                    measuredValueLabels[i].Text = valueArray[i, 1]; //update measured value label
                }
            }
            CalculateError();
        }

        private void CalculateError()
        {
            double measured_num, expected_num, numerator, error, percent_error = 0;
            for (int i = 0; i < 10; ++i)
            {
                measured_num = Convert.ToDouble(measuredValueLabels[i].Text);
                expected_num = Convert.ToDouble(expectedValueLabels[i].Text);
                numerator = measured_num - expected_num;
                error = numerator / expected_num;
                percent_error = Math.Round(error * 100, 2);
                errorValueLabels[i].Text = percent_error.ToString() + "%";
            }
        }
    }
}
