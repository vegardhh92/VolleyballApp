using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp.Utils
{
    class GameCalc
    {
        public double attackEfficiency(string attacks)
        {
            double k = 0;
            double e = 0;
            double total = attacks.Length;
            System.Diagnostics.Debug.WriteLine("Length: " + total);
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
    }
}
