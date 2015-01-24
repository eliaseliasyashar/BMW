using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotiv;

namespace DataRetrival
{
    class DataRetrival
    {
        // create a Emotiv Engine
        // It is the start point to operate and manage the headset
        EmoEngine engine;
        static void Main(string[] args)
        {
            DataRetrival dr = new DataRetrival();
            dr.mainLoop();
            Console.ReadKey();
        }
        void mainLoop()
        {
            engine = EmoEngine.Instance;
          //  engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);
            engine.Connect();

            while (true)
            {
                engine.ProcessEvents(1000);
                Console.WriteLine("hello");
            }

          //  Console.WriteLine(engine.);
          
            engine.Disconnect();
        }

     

    }
}
