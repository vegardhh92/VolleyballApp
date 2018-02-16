using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VolleyballApp.Utils
{
    class Validators
    {

        public bool NewPlayerValidator(string numb, string name, string position)
        {
            bool numbCheck = false;
            bool nameCheck = false;
            bool posCheck = false;
            string regString = "^[1 - 9] +[0 - 9] *$";
            if (numb != null && Regex.IsMatch(numb, regString))
            {
                numbCheck = true;
            }
            if (name != null && Regex.IsMatch(name, "[A - Za - z]"))
            {
                nameCheck = true;
            }
            if (position != null)
            {
                posCheck = true;
            }
            return (numbCheck && nameCheck && posCheck);
        }

        public Boolean servValidator(string servs)
        {
            string servRegEx = "[0+-]";
            if (servs == "" || Regex.IsMatch(servs, servRegEx))
            {
                System.Diagnostics.Debug.WriteLine("Serv OK");
                return true;
                
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Serv fail");
                return false;
            }
        }

        public Boolean attackValidator(string attacks)
        {
            string attackRegEx = "[+-0]";
            if (attacks == "" || Regex.IsMatch(attacks, attackRegEx))
            {
                System.Diagnostics.Debug.WriteLine("attack ok");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Attack fail");
                return false;
            }
        }
        public Boolean receptionValidator(string rec)
        {
            string servRegEx = "[12345]";
            if (rec == "" || Regex.IsMatch(rec, servRegEx))
            {
                System.Diagnostics.Debug.WriteLine("reception ok");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("reception fail");
                return false;
            }
        }
        public Boolean blockValidator(string block)
        {
            string blockRegEx = "[+k]";
            if (block == "" || Regex.IsMatch(block, blockRegEx))
            {
                System.Diagnostics.Debug.WriteLine("block ok");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("block fail");
                return false;
            }
        }

        public Boolean digValidator(string dig)
        {
            string servRegEx = "[!]";
            if (dig == "" || Regex.IsMatch(dig, servRegEx))
            {
                System.Diagnostics.Debug.WriteLine("dig ok");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Dig fail");
                return false;
            }
        }
    }
}
    