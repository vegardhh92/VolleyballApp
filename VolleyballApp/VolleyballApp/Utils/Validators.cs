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
            return (pNameValidator(name) && pNumberValidator(numb) && pPosValidator(position));
            /*
            bool numbCheck = false;
            bool nameCheck = false;
            bool posCheck = false;

            string validNameRegex = "^[^0-9]+$";
            string numberRegEx = "^([1-9]|[1-9][0-9])$";

            if (numb != null && Regex.IsMatch(numb, numberRegEx))
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
            */
        }

        public Boolean pNumberValidator(string number)
        {
            string numberRegEx = "^([1-9]|[1-9][0-9])$";
            return (number != null && Regex.IsMatch(number, numberRegEx));
        }

        public Boolean pNameValidator(string name)
        {
            string nameRegEx = "^[A-Za-z'.-]+$";

            return (name != null && Regex.IsMatch(name, nameRegEx));

        }

        public Boolean pPosValidator(string pos)
        {
            return pos != null;
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
    