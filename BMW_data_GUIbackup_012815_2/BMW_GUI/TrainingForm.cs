using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EEGDatabase;

namespace BMW_GUI
{
    public partial class TrainingForm : Form
    {
        #region global variable
        public EEG_DataReader dataReader;
        private BackgroundWorker DataWorker;
        public List <EmotivRawEEG> EEGStorer= new List<EmotivRawEEG>();
        public Database eegDB = new Database();
        public String userName;
        #endregion

        private void EmotivDataWorker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                //will collect data
                dataReader.DataCollect();
                System.Threading.Thread.Sleep(600);
            }
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }


        }

        public TrainingForm( EEG_DataReader e_dataReader, Database db, String user)
        {
            InitializeComponent();
            dataReader = e_dataReader;
            eegDB = db;
            userName = user;

            /*
            #region BackgroundWorker

            DataWorker = new BackgroundWorker();
            DataWorker.DoWork += new DoWorkEventHandler(EmotivDataWorker);
            DataWorker.WorkerSupportsCancellation = true;
            #endregion
            */
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            button_submit.Enabled = false;
            listBox_Type.Enabled = false;
            
            String selectedItem = listBox_Type.SelectedItem.ToString();
            
            Direction_postsubmit(selectedItem);
            experimentTimer.Interval = 10000;
            experimentTimer.Enabled = true;
            Datatimer.Enabled = true;

             
        }


        public void Direction_postsubmit(String selectedItem)
        {
            //Relax-baseline
            if (selectedItem == "Relax")
            {
                 richTextBox_Direction.Text = "Relax and Think of Nothing for 10 seconds. ";
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
            else if (selectedItem == "SSVEP-9HZ")
            {
                SSVEP_Timer.Enabled = true;

            }
            else
            {
            }




        }
        public void Direction_presubmit(String selectedItem)
        {
            pictureBox1.Image = pictureBox1.InitialImage;
            pictureBox1.Visible = false;

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
                pictureBox1.Image = global::BMW_GUI.Properties.Resources.cube;
                pictureBox1.Visible = true;
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
            else if (selectedItem == "SSVEP-9HZ")
            {

                richTextBox_Direction.Text = "Look at the blinking circle for SSVEP experiment! ";
                SSVEP_light.Visible = true;
            }



        }

        int numOfTick = 0;

        //Experiment Timer- Keep Track of time for experiment
        private void experimentTimer_Tick(object sender, EventArgs e)
        {

            String selectedItem = listBox_Type.SelectedItem.ToString();
            if (selectedItem == "Geometric figure rotation" && numOfTick == 0)
            {
                richTextBox_Direction.Text = "Visualized the object being rotated about the axis for 10s. ";
                pictureBox1.Image = pictureBox1.InitialImage;
                pictureBox1.Visible = false;
                numOfTick++;


            }

            else
            {
                richTextBox_Direction.Text = "Tasks Over";
//                Direction_presubmit(selectedItem);
                button_submit.Enabled = true;
                listBox_Type.Enabled = true;
                numOfTick = 0;
                experimentTimer.Enabled = false;
                SSVEP_Timer.Enabled = false;
                SSVEP_light.Visible = false;
                if (EEGStorer.Count != 0)
                    WriteFile();
                else
                    label3.Text = "No Data Readed";
                
                
            }

        }


        private void Datatimer_Tick(object sender, EventArgs e)
        {
            //do that so unneeded data will be processed and cleared
            if (experimentTimer.Enabled == false)
            {
                label3.Text = dataReader.Run();
            }
            else
            {
                List<EmotivRawEEG> receivedData = dataReader.DataCollect();
                if (receivedData != null)
                {

                    /*add retreive EEG data to the general list*/
                    foreach (EmotivRawEEG data in receivedData)
                    {
                        EEGStorer.Add(data);
                    }
                }
                if (receivedData == null) { label3.Text = "null"; }
                //if (receivedData.Count == 1) { label3.Text = "not connect"; }
            }

        }

        private void listBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = listBox_Type.SelectedItem.ToString();
            richTextBox_Direction.Text = selectedItem;

            Direction_presubmit(selectedItem);

        }
        


        /*For testing storing data*/
        string filename = "outfile_testing.csv"; // output filename
        public void WriteFile()
        {
            
            filename = listBox_Type.SelectedItem.ToString()+"_"+
                EEGStorer[0].date.ToString("hh") +
                EEGStorer[0].date.ToString("mm") +
                EEGStorer[0].date.ToString("MMM") +
                EEGStorer[0].date.ToString("dd")+
                EEGStorer[0].date.ToString("yyyy")+".csv";
            TextWriter file = new StreamWriter(filename, false);

            string header = "COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL,DateTime";

            file.WriteLine(header);
            // Write the data to a file
        
            for (int i = 0; i < EEGStorer.Count; i++)
            {

                // now write the data
                #region write each variable to file
                file.Write(EEGStorer[i].COUNTER + ",");
                file.Write(EEGStorer[i].INTERPOLATED + ",");
                file.Write(EEGStorer[i].RAW_CQ + ",");
                file.Write(EEGStorer[i].AF4 + ",");
                file.Write(EEGStorer[i].F8 + ",");
                file.Write(EEGStorer[i].F4 + ",");
                file.Write(EEGStorer[i].FC6 + ",");
                file.Write(EEGStorer[i].T8+ ",");
                file.Write(EEGStorer[i].P8+ ",");
                file.Write(EEGStorer[i].O2 + ",");
                file.Write(EEGStorer[i].O1 + ",");
                file.Write(EEGStorer[i].P7 + ",");
                file.Write(EEGStorer[i].T7 + ",");
                file.Write(EEGStorer[i].FC5 + ",");
                file.Write(EEGStorer[i].F3 + ",");
                file.Write(EEGStorer[i].F7 + ",");
                file.Write(EEGStorer[i].AF3 + ",");
                file.Write(EEGStorer[i].GYROX + ",");
                file.Write(EEGStorer[i].GYROY + ",");
                file.Write(EEGStorer[i].TIMESTAMP + ",");
                file.Write(EEGStorer[i].ES_TIMESTAMP + ",");
                file.Write(EEGStorer[i].FUNC_ID + ",");
                file.Write(EEGStorer[i].FUNC_VALUE + ",");
                file.Write(EEGStorer[i].MARKER + ",");
                file.Write(EEGStorer[i].SYNC_SIGNAL + ",");
                file.Write(EEGStorer[i].date + ",");
                
                #endregion
                //add data to database
                //session number not considered. Sort of dependent on database
                eegDB.EEG_Insert(userName, EEGStorer[i].AF3,  EEGStorer[i].F7 ,  EEGStorer[i].F3, 
                EEGStorer[i].FC5,  EEGStorer[i].T7, EEGStorer[i].P7, EEGStorer[i].O1,  EEGStorer[i].O2,
                EEGStorer[i].P8 , EEGStorer[i].T8, EEGStorer[i].FC6, EEGStorer[i].F4, EEGStorer[i].F8, 
                EEGStorer[i].AF4,EEGStorer[i].TIMESTAMP, 1, EEGStorer[i].date.ToString()); 
     
                file.WriteLine("");

            }
            EEGStorer.Clear();
            file.Close();
        }

        private void SSVEP_Timer_Tick(object sender, EventArgs e)
        {
            if (SSVEP_light.Visible == true)
            {
                SSVEP_light.Visible = false;
            }
            else { SSVEP_light.Visible = true; }
        }



    }
}
