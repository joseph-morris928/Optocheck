using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optocheck
{
    public partial class CNCForm : Form
    {
        SerialPort port;
        public CNCForm(Form callingForm, SerialPort port_in)
        {
            InitializeComponent();
            goHomeButton.Enabled = true;
            port = port_in;
        }

        public CNCForm(Form callingForm)
        {
            InitializeComponent();
        }

        private void CNCForm_Load(object sender, EventArgs e)
        {

        }

        private void goHomeButton_Click(object sender, EventArgs e)
        {
            port.Write("$H\n");
        }
    }
}
