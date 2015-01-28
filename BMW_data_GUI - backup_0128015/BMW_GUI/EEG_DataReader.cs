using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using Emotiv;
using System.IO;
using System.Threading;
using System.Reflection;

namespace BMW_GUI
{
    public class EEG_DataReader
    {
        EmoEngine engine; // Access to the EDK is viaa the EmoEngine 
        int userID = -1; // userID is used to uniquely identify a user's headset
        string filename = "outfile3.csv"; // output filename
        List<EmotivRawEEG> eegCollector = new List<EmotivRawEEG>();

        public EEG_DataReader()
        {
            // create the engine
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);

            // connect to Emoengine.            
            engine.Connect();

            // create a header for our output file
            WriteHeader();
        
        }
        public void sessionOver()
        {
            engine.Disconnect();
        }
        public void engine_UserAdded_Event(object sender, EmoEngineEventArgs e)
        {
           Console.WriteLine("User Added Event has occured");

            // record the user 
            userID = (int)e.userId;

            // enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);

            // ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(10);

        }

        /*
         * training: 1 ver datacollect- add data to the datastructure
         return it all together in the end of experiment session
         
         control: return list of data upon request*/

        public List<EmotivRawEEG> DataCollect()
        {
            List<EmotivRawEEG> tempEEGStorage = new List<EmotivRawEEG>();
            // Handle any waiting events
            engine.ProcessEvents();
            // If the user has not yet connected, do not proceed
            if ((int)userID == -1)
            {
                EmotivRawEEG datareader = new EmotivRawEEG() { RAW_CQ = 1 };
                tempEEGStorage.Add(datareader);
                return tempEEGStorage;
            }
            Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);


            if (data == null)
            {
                return null;
            }

            int _bufferSize = data[EdkDll.EE_DataChannel_t.TIMESTAMP].Length;
           for (int i = 0; i < _bufferSize; i++)
           {
               #region dataAssignment to Data structure
               EmotivRawEEG datareader = new EmotivRawEEG() {
              COUNTER = data[EdkDll.EE_DataChannel_t.COUNTER][i],
              INTERPOLATED = data[EdkDll.EE_DataChannel_t.INTERPOLATED][i],
              RAW_CQ = data[EdkDll.EE_DataChannel_t.RAW_CQ][i],
              AF4=data[EdkDll.EE_DataChannel_t.AF4][i],
              F8 = data[EdkDll.EE_DataChannel_t.F8][i],
              F4 = data[EdkDll.EE_DataChannel_t.F4][i],
              FC6 = data[EdkDll.EE_DataChannel_t.FC6][i],
              T8 = data[EdkDll.EE_DataChannel_t.T8][i],
              P8 = data[EdkDll.EE_DataChannel_t.P8][i],
              O2 = data[EdkDll.EE_DataChannel_t.O2][i],
              O1 = data[EdkDll.EE_DataChannel_t.O1][i],
              P7 = data[EdkDll.EE_DataChannel_t.P7][i],
              T7 = data[EdkDll.EE_DataChannel_t.T7][i],
              FC5 = data[EdkDll.EE_DataChannel_t.FC5][i],
              F3 = data[EdkDll.EE_DataChannel_t.F3][i],
              F7 = data[EdkDll.EE_DataChannel_t.F7][i],
              AF3 = data[EdkDll.EE_DataChannel_t.AF3][i],
              GYROX = data[EdkDll.EE_DataChannel_t.GYROX][i],
              GYROY = data[EdkDll.EE_DataChannel_t.GYROY][i],
              TIMESTAMP = data[EdkDll.EE_DataChannel_t.TIMESTAMP][i],
              ES_TIMESTAMP = data[EdkDll.EE_DataChannel_t.ES_TIMESTAMP][i],
              FUNC_ID = data[EdkDll.EE_DataChannel_t.FUNC_ID][i],
              FUNC_VALUE = data[EdkDll.EE_DataChannel_t.FUNC_VALUE][i],
              MARKER = data[EdkDll.EE_DataChannel_t.MARKER][i],
              SYNC_SIGNAL = data[EdkDll.EE_DataChannel_t.SYNC_SIGNAL][i],
                date = DateTime.Now};
              

               #endregion

               tempEEGStorage.Add(datareader);
               eegCollector.Add(datareader);

            }

           return tempEEGStorage;
        }
        public String Run()
        {
            // Handle any waiting events
            engine.ProcessEvents();

            // If the user has not yet connected, do not proceed
            if ((int)userID == -1)
                return "userID";

            Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);


            if (data == null)
            {
                return "data";
            }

            int _bufferSize = data[EdkDll.EE_DataChannel_t.TIMESTAMP].Length;

            //Console.WriteLine("Writing " + _bufferSize.ToString() + " lines of data ");

            // Write the data to a file
            filename = "outfile1.csv";
            TextWriter file = new StreamWriter(filename, true);

            for (int i = 0; i < _bufferSize; i++)
            {
               
                // now write the data
                foreach (EdkDll.EE_DataChannel_t channel in data.Keys)
                    file.Write(data[channel][i] + ",");
                file.WriteLine("");

            }
            file.Close();
            return _bufferSize.ToString();
        }

        public void setFileName(String name)
        {
            filename = name;
        }
        public void WriteHeader()
        {
           
            TextWriter file = new StreamWriter(filename, false);

            string header = "COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL,";

            file.WriteLine(header);
            file.Close();
        }



    }

 
}
