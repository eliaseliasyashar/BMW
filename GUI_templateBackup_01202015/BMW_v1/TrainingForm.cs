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
    public partial class TrainingForm : Form
    {
        public TrainingForm()
        {
            InitializeComponent();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            button_submit.Enabled=false;
            listBox_Type.Enabled = false;
            String selectedItem = listBox_Type.SelectedItem.ToString();
            Direction_postsubmit(selectedItem);
            experimentTimer1.Interval = 10000;
            experimentTimer1.Enabled = true;


             

        }



        private void listBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

            String selectedItem = listBox_Type.SelectedItem.ToString();
            Direction_presubmit(selectedItem);

        }

        public void Direction_postsubmit(String selectedItem)
        {
            //Relax-baseline
            if (selectedItem == "Relax")
            {
               // richTextBox_Direction.Text = "Relax and Think of Nothing for 10 seconds. ";
            }
            else if (selectedItem == "Math-Level1" || selectedItem == "Math-Level2")
            {
                int n1, n2 = 0;
                Random rnd1 = new Random();

                n1 = rnd1.Next(0, 100);
                n2 = rnd1.Next(0, 100);
                if (selectedItem == "Math-Level1")
                {
                    richTextBox_Direction.Text = "Solve the below expression in your mind : \n " +
                                                n1 + " + " + n2;
                }
                else if (selectedItem == "Math-Level2")
                {
                    richTextBox_Direction.Text = "Solve the below expression in your mind : \n " +
                                                  n1 + " x " + n2;
                }
            }
            //Geometric figure rotation task
            else if (selectedItem == "Geometric figure rotation")
            {
                richTextBox_Direction.Text = "Memorize the following figure \n";
            }

            else if (selectedItem == "Mental letter composing")
            {
              //  richTextBox_Direction.Text = "Mentally Compose a letter to a friend";
            }
            else if (selectedItem == "Visual counting")
            {
                richTextBox_Direction.Text = "Imagine a blackboard. \n" +
                            "First, Visualize number 0 on the board," +
                            "Erase it while counting 1, and so on. ";
            }
            
     

        
        }
        public void Direction_presubmit(String selectedItem)
        {
            pictureBox1.Image = pictureBox1.InitialImage;
            
            //Relax-baseline
            if (selectedItem == "Relax")
            {
                richTextBox_Direction.Text = "Relax and Think of Nothing for 10 seconds. ";
            }
            else if (selectedItem == "Math-Level1" || selectedItem == "Math-Level2")
            {
              
                    richTextBox_Direction.Text = "You will be solving mathematic expression in your mind for 10 s"; 
               
            }
            //Geometric figure rotation task
            else if (selectedItem == "Geometric figure rotation")
            {
                richTextBox_Direction.Text = "You will first memorize the following figure for 10 seconds, \n" +
                                             "then visualized the object being rotated about the axis. ";
                pictureBox1.Image = global::BMW_v1.Properties.Resources.cube;
            }

            else if (selectedItem == "Mental letter composing")
            {
                richTextBox_Direction.Text = "You will mentally compose a letter to a friend fo 10 s";
            }
            else if (selectedItem == "Visual counting")
            {
                richTextBox_Direction.Text = "You will imagine a blackboard. \n" +
                            "First, Visualize number 0 on the board," +
                            "Erase it while counting 1, and so on. ";
            }
            
     


        }

        int numOfTick = 0;
        private void experimentTimer1_Tick(object sender, EventArgs e)
        {
            String selectedItem = listBox_Type.SelectedItem.ToString();
            if (selectedItem == "Geometric figure rotation" && numOfTick==0)
            {
                richTextBox_Direction.Text = "Visualized the object being rotated about the axis for 10s. ";
                pictureBox1.Image =pictureBox1.InitialImage;
                numOfTick++;

       
            }
           
            else 
            {
                Direction_presubmit(selectedItem);
                button_submit.Enabled = true;
                listBox_Type.Enabled = true;
                numOfTick = 0;
                experimentTimer1.Enabled = false;

            }
        }

    }
}
