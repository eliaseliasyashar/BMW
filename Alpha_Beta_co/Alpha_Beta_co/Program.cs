using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Beta_co
{
    class Program
    {
        double[] Altha = new double[500];
        double[] Betha = new double[500];
        double[] P_Alpha_State = new double[2];
        double[] P_Beta_State = new double[3];
        double[] Alpha_State = new double[2];
        double[] Beta_State = new double[3];
        double Max_Altha;   //   set using the Aptha array
        double Max_Beta;    //   set using the Betha array
        void FindMax_Alpha(double[] a)
        {
             Max_Altha = a.Max();
        }

        void FindMax_Beta(double[] a)
        {
            Max_Beta = a.Max();
        }
        static void Main(string[] args)
        {
            Program a = new Program();
        double[] alpha = new double[]{1.2,1.5,2.6,4.6,2.5,12.3,15.2,14.3,11.1,16.23};
        double[] beta = new double[] { 1.5, 1.2, 3.6, 5.6, 3.4, 7.39, 11.2, 14.3, 15.1, 19.23 };

        a.FindMax_Alpha(alpha);
        a.FindMax_Beta(beta);
            for(int i=0;i<10;i++)
            {
                a.Alpha_Mapping(alpha[i]);
                a.Beta_Mapping(beta[i]);
            }
            a.Probability();

            Console.WriteLine("Probability of Altha\n"); 
            for (int i = 0; i < a.P_Alpha_State.Length; i++)
                Console.Write(a.P_Alpha_State[i] + "\n");

            Console.WriteLine("Probability of Beta\n");
            for (int i = 0; i < a.P_Beta_State.Length; i++)
                Console.Write(a.P_Beta_State[i] + "\n");


            Console.ReadKey();
        }

        void Alpha_Mapping(double input)
        {
            
             for(int i=0;i<P_Alpha_State.Length;i++)
             {
                 if((input > ((double)i/P_Alpha_State.Length)*Max_Altha) & (input<=(((double)i+1)/P_Alpha_State.Length)*Max_Altha))
                         Alpha_State[i]++;
             }
        }

        void Beta_Mapping(double input)
        {
            for ( int i = 0; i < P_Beta_State.Length; i++)
            {
                if ((input > ((double)i / P_Beta_State.Length)*Max_Beta) & (input <= (((double)i + 1.0) / (double)P_Beta_State.Length)*Max_Beta))
                    Beta_State[i]++;
            }
        }

        void Probability()
        {
            for (int i = 0; i < Alpha_State.Length; i++)
                P_Alpha_State[i] = Alpha_State[i] / 10.0;

            for (int i = 0; i < Beta_State.Length; i++)
            P_Beta_State[i] = Beta_State[i] / 10.0;
                
        }

        // need to implement
        void Input()
        {

        }

    }
}
