using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp.Utils
{
    public class GameCalc
    {
        public double AttackEfficiency(string attacks)
        {
            double k = 0;
            double e = 0;
            double total = attacks.Length;
            System.Diagnostics.Debug.WriteLine("Length: " + total);
            if(total == 0)
            {
                return 0;
            }
            foreach(Char c in attacks)
            {
                if (c == '+')
                {
                    k++;
                }else if(c == '-')
                {
                    e++;
                }
            }
            double attackEff = 0;
            attackEff = (k - e) / total;
            System.Diagnostics.Debug.WriteLine("k: " + k + " e: " + e + " attackEff: " + attackEff);
            return Math.Round(attackEff,2);
        }

        public double ServEfficiency(string servs)
        {
            double ace = 0;
            double error = 0;
            double total = servs.Length;
            if (total == 0)
            {
                return 0;
            }
            System.Diagnostics.Debug.WriteLine("Length: " + total);
            foreach (Char c in servs)
            {
                if (c == '+')
                {
                    ace++;
                }
                else if (c == '-')
                {
                    error++;
                }
            }
            double servEff = 0;
            servEff = (ace - error) / total;
            System.Diagnostics.Debug.WriteLine("k: " + ace + " e: " + error + " servEfficency: " + servEff);
            return Math.Round(servEff, 2);
        }

        public double avgReception(string receptions)
        {

            double total = receptions.Length;

            if (total == 0)
            {
                return 0;
            }
            double avg = 0;
            foreach(Char c in receptions)
            {
                if (c == '1')

                    avg += 1;
                else if (c == '2')
                    avg += 2;
                else if (c == '3')
                    avg += 3;
                else if (c == '4')
                    avg += 4;
                else if (c == '5')
                    avg += 5;
            }
             return  avg = avg / total;
        }
    }
}
