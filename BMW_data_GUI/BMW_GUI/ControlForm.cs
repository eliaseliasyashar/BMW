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

        public List<double> O1List= new List<double>();
        public Database eegDB = new Database();
        public SSVEP_Form ssvep;
        public SensorContactForm cqForm;

        public Boolean OPStart = false;
        public Fourier ft = new Fourier();
        #endregion


        public ControlForm(EEG_DataReader e_dataReader, Database db)
        {
            InitializeComponent();
            dataReader = e_dataReader;
            eegDB = db;
            DataTimer.Enabled = true;

            HideLabel();
            this.FormClosing += new FormClosingEventHandler(ControlForm_ClosingForm);

        }

        void HideLabel()
        {
            label1.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            textBox_boredom.Hide();
            textBox_frustration.Hide();
            textBox_ShortExcitement.Hide();
            textBox_longExcitement.Hide();
            textBox_freq.Hide();
            label6.Hide();

        
        }
        void ShowEMOLabel()
        {
            label1.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            textBox_boredom.Show();
            textBox_frustration.Show();
            textBox_ShortExcitement.Show();
            textBox_longExcitement.Show();


        }
        void ShowFreq()
        {
            label6.Show();
            textBox_freq.Show();
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
                ShowFreq();
                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "Mental Task")
            {
                EmoUpdate.Enabled = true;
                ShowEMOLabel();
                ShowFreq();
            }
        

        
        }
        int index = 0;

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
                        O1List.Add(receivedData[i].O1);
                    }
                }

                double maxFreq = 0;
                double maxMag = 0;
                double alphaPower=0;
                double betaPower = 0;
                if (O1List.Count >= 128)
                {
                    List<double> range = O1List.GetRange(0, 128);

                    double[] FFT_data = new double[128];
                    FFT_data = range.ToArray();
                    ft.RealFFT(FFT_data, true);

                    /*Compute MaxFreq*/
                    for (int i = 0; i < FFT_data.Length; i += 2)
                    {
                        if (i > 6 && (Math.Pow(FFT_data[i], 2)) + Math.Pow(FFT_data[i + 1], 2) > maxMag)
                        { 
                            maxFreq = Math.Pow(FFT_data[i], 2) + Math.Pow(FFT_data[i + 1], 2);
                            maxFreq = (i * 128 / FFT_data.Length) / 2;
                        }
                    
                    }

                    /*Compute Alpha*/
                    for (int j = 8*2; j < 12*2; j += 2)
                    {
                        
                            alphaPower += Math.Pow(FFT_data[j], 2) + Math.Pow(FFT_data[j + 1], 2);
                            
                     }

                     /*Compute Beta*/
                    for (int k = 13*2; k < FFT_data.Length; k += 2)
                    {
                       
                            betaPower += Math.Pow(FFT_data[k], 2) + Math.Pow(FFT_data[k + 1], 2);
                            
                        

                    }

                      //textBox_alpha.Text 
                   textBox_freq.Text = maxFreq.ToString();
                    textBox_alpha.Text=alphaPower.ToString();
                    textBox_Beta.Text = betaPower.ToString();
                    O1List.RemoveRange(0, 64);

                    }

                   
                
                }
                
              

                

                //   if (receivedData == null) { label3.Text = "null"; }
            
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
