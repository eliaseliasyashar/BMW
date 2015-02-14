using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EEGDatabase;

namespace BMW_GUI
{
  
    public partial class ControlForm : Form
    {

        #region global variable

        public EEG_DataReader dataReader;

        public Queue<double> O1Queue= new Queue<double>();
        public Database eegDB = new Database();
        public SSVEP_Form ssvep;
        public SensorContactForm cqForm;

        public Boolean OPStart = false;
        #endregion


        public ControlForm(EEG_DataReader e_dataReader, Database db)
        {
            InitializeComponent();
            dataReader = e_dataReader;
            eegDB = db;
            DataTimer.Enabled = true;


            this.FormClosing += new FormClosingEventHandler(ControlForm_ClosingForm);

        }


        public void ShowCQ()
        {
            cqForm = dataReader.scForm;
            cqForm.Show();
            cqForm.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

        }

        private void button_submit_Click(object sender, EventArgs e)
        {

            String selectedItem = listBox_Type.SelectedItem.ToString();

            button_submit.Enabled = false;
            listBox_Type.Enabled = false;

            PostSubmit(selectedItem);
            OPStart = true;


        }

        public void PostSubmit(String selectedItem)
        {
            
            if (selectedItem == "SSVEP")
            {
                ssvep = new SSVEP_Form(9);
                ssvep.Show();

                ssvep.SSVEP_11Hz.Enabled = true;
                ssvep.SSVEP_13Hz.Enabled = true;
                // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "Mental Task")
            {
                EmoUpdate.Enabled = true;
            }
        

        
        }

        private void DataTimer_Tick(object sender, EventArgs e)
        {

            if (OPStart)
            {
                List<EmotivRawEEG> receivedData = dataReader.DataCollect();

                if (receivedData != null)
                {
                    

                    /*add retreive EEG data to the general list*/
                    /*
                    foreach (EmotivRawEEG data in receivedData)
                    {
                        EEGStorer.Add(data);
                    }
                     * */

                    for (int i = 0; i < receivedData.Count; i++)
                    {
                        O1Queue.Enqueue(receivedData[i].O1);
                    }
                }
                //   if (receivedData == null) { label3.Text = "null"; }
            }
        }

        private void ControlForm_ClosingForm(object sender, FormClosingEventArgs e)
        {

            cqForm.Hide();
            //  cqForm.Close();
            //this.Close();

        }

        private void EmoUpdate_Tick(object sender, EventArgs e)
        {
            if (dataReader.getEmoCount()>  0)
            {
                AffectivValue affv = dataReader.getEmoData();

                textBox_boredom.Text = affv.boredom.ToString();
                textBox_frustration.Text = affv.frustration.ToString();
                textBox_longExcitement.Text = affv.longTermExcitement.ToString();
                textBox_ShortExcitement.Text = affv.shortTermExcitementScore.ToString();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
             String selectedItem = listBox_Type.SelectedItem.ToString();

              if (selectedItem == "SSVEP")
            {
               ssvep.Hide();
                ssvep.SSVEP_11Hz.Enabled = false;
                ssvep.SSVEP_13Hz.Enabled = false;
                // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "Mental Task")
            {
            EmoUpdate.Enabled=false;
            dataReader.WriteAffectiv();
            }

              button_submit.Enabled = true;
              listBox_Type.Enabled = true;
              OPStart = false;

        }
       
           


    }
  
}
