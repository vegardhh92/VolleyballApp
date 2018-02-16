using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VolleyballApp
{
    class Validators
    {

        public bool NewPlayerValidator(string numb, string name, string position)
        {
            bool numbCheck = false;
            bool nameCheck = false;
            bool posCheck = false;
            string regString = "^[0-9]{1,2}$";
            if (numb != null && Regex.IsMatch(numb, regString))
            {
                numbCheck = true;
            }
            if (name != null && Regex.IsMatch(name, "[A - Za - z]"))
            {
                nameCheck = true;
            }
            if(position != null)
            {
                posCheck = true;
            }
            return (numbCheck && nameCheck && posCheck);
        }
    }
}
