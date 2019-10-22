using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optocheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                scanButton.Enabled = false;
                infinityRadioButton.Enabled = false;
                zboxRadioButton.Enabled = false;
                frontRadioButton.Enabled = false;
            } else
            {
                MessageBox.Show("Please select a Mirror Type", "Mirror Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
