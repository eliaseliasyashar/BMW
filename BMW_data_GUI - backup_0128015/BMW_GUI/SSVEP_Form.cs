using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMW_GUI
{
    public partial class SSVEP_Form : Form
    {
        public SSVEP_Form()
        {
            InitializeComponent();
        }

        private void SSVEP_timer1_Tick(object sender, EventArgs e)
        {
            if (rectangleShape1.Visible == false) rectangleShape1.Visible = true;
            else if (rectangleShape1.Visible == true) rectangleShape1.Visible = false;

        }

        private void SSVEP_timer2_Tick(object sender, EventArgs e)
        {
            if (rectangleShape2.Visible == false) rectangleShape2.Visible = true;
            else if (rectangleShape2.Visible == true) rectangleShape2.Visible = false;

        }
    }
}
