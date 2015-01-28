using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMW_v1
{
    public partial class MainForm : Form
    {

        #region Forms
        TrainingForm TF;
        ControlForm CF;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
          //  textBox_Name.Enabled = false;
            //Show Form according to each command
            switch(listBox_Mode.SelectedIndex)
            {

                //Training
                case 0:
                    TF = new TrainingForm();
                    TF.Show();
                  
                    break;
                //Control
                case 1: 
                   CF = new ControlForm();
                    CF.Show();
                    break;

                default: break;          
            }
          

            



        }
    }
}
