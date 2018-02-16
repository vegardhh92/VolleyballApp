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
            string regString = "^[0-9][0-9]$";
            string validNameRegex = "^[^0-9]+$";
            if (numb != null && Regex.IsMatch(numb, regString))
            {
                numbCheck = true;
            }
            if (name != null && Regex.IsMatch(name, validNameRegex))
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean attackValidator(string attacks)
        {
            string attackRegEx = "[+-0]";
            if (attacks == "" || Regex.IsMatch(attacks, attackRegEx))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean receptionValidator(string rec)
        {
            string servRegEx = "[12345]";
            if (rec == "" || Regex.IsMatch(rec, servRegEx))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean blockValidator(string block)
        {
            string servRegEx = "[+k]";
            if (block == "" || Regex.IsMatch(block, servRegEx))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean digValidator(string dig)
        {
            string servRegEx = "[!]";
            if (dig == "" || Regex.IsMatch(dig, servRegEx))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    