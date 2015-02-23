using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClosedEyeStable
{

    public class NaiveBayisClassifier
    {
        // input alpha_o1 list
        List<double> alpha_o1 = new List<double>();
        // input beta_o1 list
        List<double> beta_o1 = new List<double>();
        // input stable list
        List<bool> stable = new List<bool>();
        double alpha_stable = 0.0;
        double beta_stable = 0.0;
        public double Max_alpha = 0.0;
        public double Max_beta = 0.0;
        // classify factors
        List<bool> Factor_High_Alpha = new List<bool>();
        List<bool> Factor_High_Beta = new List<bool>();

        double HighAlpha_Stable = 0.0;
        double LowAlpha_Stable = 0.0;
        double HighBeta_Stable = 0.0;
        double LowBeta_Stable = 0.0;
        double Stable = 0.0;

        double P_HighAlpha_Stable = 0.0;
        double P_LowAlpha_Stable = 0.0;
        double P_HighBeta_Stable = 0.0;
        double P_LowBeta_Stable = 0.0;
        double P_Stable = 0.0;

        double HighAlpha_NOStable = 0.0;
        double LowAlpha_NOStable = 0.0;
        double HighBeta_NOStable = 0.0;
        double LowBeta_NOStable = 0.0;
        //  double NOStable = 0.0;

        double P_HighAlpha_NOStable = 0.0;
        double P_LowAlpha_NOStable = 0.0;
        double P_HighBeta_NOStable = 0.0;
        double P_LowBeta_NOStable = 0.0;
        double P_NOStable = 0.0;
        // get the input from GUI for tranning 
        public void input(List<double> alpha, List<double> beta, List<bool> t)
        {
            alpha_o1 = alpha;
            beta_o1 = beta;
            stable = t;
        }

        public void Find_StablePoint()
        {
            Max_alpha = alpha_o1.Max();
            Max_beta = beta_o1.Max();
            alpha_stable = (Max_alpha + alpha_o1.Min()) / 2.0;
            Console.WriteLine("alpha_stable" + alpha_stable);
            beta_stable = (Max_beta + beta_o1.Min()) / 2.0;
            Console.WriteLine("beta_stable" + beta_stable);
        }

        public void AnalysisTranningSet()
        {
            for (int i = 0; i < stable.Count; i++) // Loop with for.
            {
                // update alpha status
                if (alpha_o1[i] > alpha_stable && stable[i] == true)
                {
                    Stable++;
                    HighAlpha_Stable++;
                }
                else if (alpha_o1[i] > alpha_stable && stable[i] == false)
                    HighAlpha_NOStable++;
                else if (alpha_o1[i] <= alpha_stable && stable[i] == true)
                {
                    Stable++;
                    LowAlpha_Stable++;
                }
                else if (alpha_o1[i] <= alpha_stable && stable[i] == false)
                    LowAlpha_NOStable++;






                // update beta status
                if (beta_o1[i] > beta_stable && stable[i] == true)
                    HighBeta_Stable++;
                else if (beta_o1[i] > beta_stable && stable[i] == false)
                    HighBeta_NOStable++;
                else if (beta_o1[i] <= beta_stable && stable[i] == true)
                    LowBeta_Stable++;
                else if (beta_o1[i] <= beta_stable && stable[i] == false)
                    LowBeta_NOStable++;
            }


            P_HighAlpha_Stable = HighAlpha_Stable / Stable;
            P_HighAlpha_NOStable = HighAlpha_NOStable / (stable.Count - Stable);
            P_LowAlpha_Stable = LowAlpha_Stable / Stable;
            P_LowAlpha_NOStable = LowAlpha_NOStable / (stable.Count - Stable);


            Console.WriteLine("P_HighAlpha_Stable " + P_HighAlpha_Stable);
            Console.WriteLine("P_HighAlpha_NOStable " + P_HighAlpha_NOStable);
            Console.WriteLine("P_LowAlpha_Stable " + P_LowAlpha_Stable);
            Console.WriteLine(" P_LowAlpha_NOStable " + P_LowAlpha_NOStable);

            P_Stable = Stable / stable.Count;
            P_HighBeta_Stable = HighBeta_Stable / Stable;
            P_HighBeta_NOStable = HighBeta_NOStable / (stable.Count - Stable);
            P_LowBeta_Stable = LowBeta_Stable / Stable;
            P_LowBeta_NOStable = LowBeta_NOStable / (stable.Count - Stable);


            Console.WriteLine("P_Stable " + P_Stable);
            Console.WriteLine("P_HighBeta_Stable " + P_HighBeta_Stable);
            Console.WriteLine("P_HighBeta_NOStable " + P_HighBeta_NOStable);
            Console.WriteLine(" P_LowBeta_Stable " + P_LowBeta_Stable);
            Console.WriteLine(" P_LowBeta_NOStable " + P_LowBeta_NOStable);
            Console.WriteLine("\n\n\n");

        }

        public bool classify(double alpha, double beta)
        {
            bool Result = false;
            double P_on = 0.0;
            double P_off = 0.0;
            if (alpha <= Max_alpha && beta <= Max_beta)
            {
                if (alpha <= alpha_stable && beta <= beta_stable)
                {
                    P_off = P_LowAlpha_Stable * P_LowBeta_Stable * P_Stable;
                    Console.WriteLine("P_ff" + P_off);
                    P_on = P_LowAlpha_NOStable * P_LowBeta_NOStable * (1 - P_Stable);
                    Console.WriteLine("P_on" + P_on);
                }
                else if (alpha > alpha_stable && beta <= beta_stable)
                {
                    P_off = P_HighAlpha_Stable * P_LowBeta_Stable * P_Stable;
                    P_on = P_HighAlpha_NOStable * P_LowBeta_NOStable * (1 - P_Stable);
                }
                else if (alpha > alpha_stable && beta > beta_stable)
                {
                    P_off = P_HighAlpha_Stable * P_HighBeta_Stable * P_Stable;
                    P_on = P_HighAlpha_NOStable * P_HighBeta_NOStable * (1 - P_Stable);
                }
                else
                {
                    P_off = P_LowAlpha_Stable * P_HighBeta_Stable * P_Stable;
                    P_on = P_LowAlpha_NOStable * P_HighBeta_NOStable * (1 - P_Stable);
                }
            }
            else
            {
                return false;
            }

            if (P_on >= P_off)
                Result = false;
            else
                Result = true;


            return Result;
        }

        public static void Main(string[] args)
        {
            List<double> alpha = new List<double>();
            List<double> beta = new List<double>();
            List<bool> sta = new List<bool>();
            double[] a = {10.66178358,87.79868504,109.8623819,26.39070664,34.77600883,16.43211182,14.8526008,22.13850081,25.40871526,25.02557525,
                                28.88724447,21.79479457,18.02888231,43.82362131,58.89162098,50.20137052,17.52706361,30.30484933,41.10360287,38.08321578,
                                46.43793419,64.6921688,56.2921771,58.68889493,73.84311505,83.60653603,66.27132533,70.66488478,41.32154973,30.9376161,
                                17.05235693,27.4837544};

            double[] b = {17.00298602,55.1940691,65.8548605,34.54510489,29.14994485,23.57869361,22.86869054,27.53953628,32.0172021,
                          32.49938851,35.66198722,30.68930674,27.93514779,54.278022,53.4036818,52.12683276,24.5002717,40.12624521,
                          35.81387484,25.47700201,24.14335124,22.39188861,26.60156105,20.39004809,28.91405261,38.45561384,34.50494698,
                          43.36318324,26.21557937,27.14167731,20.18916073,27.51200176};

            bool[] stable ={false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
                           false,false,false,true,true,true,true,true,true,false,false,false,false,false,false,false,false};

            foreach (double ele in a)
                alpha.Add(ele);

            foreach (double ele in b)
                beta.Add(ele);

            foreach (bool ele in stable)
                sta.Add(ele);

            NaiveBayisClassifier nb = new NaiveBayisClassifier();
            nb.input(alpha, beta, sta);
            nb.Find_StablePoint();
            nb.AnalysisTranningSet();
            bool t = nb.classify(20, 20);
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
