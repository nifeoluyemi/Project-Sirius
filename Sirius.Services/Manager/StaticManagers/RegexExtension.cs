using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.StaticManagers
{
    public static class RegexExtension
    {
        public static bool IsValidEmail(string emailorUsername)
        {
            string stringExpr = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex reg = new Regex(stringExpr);
            return reg.IsMatch(emailorUsername) ? true : false;
        }


    }
}
