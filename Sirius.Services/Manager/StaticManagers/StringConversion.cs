using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.StaticManagers
{
    public static class StringConversion
    {
        public static string ConvertToString(IEnumerable<string> stringList)
        {
            if (stringList.Count() < 1)
            {
                return string.Empty;
            }
            else if (stringList.Count() == 1)
            {
                return stringList.SingleOrDefault();
            }
            else
            {
                return String.Join(", ", stringList);
            }
        }

        //This converts guid to string and removes the hyphen
        public static string ConvertGuidToString(Guid guid)
        {
            return guid.ToString("n");
        }

        public static string ConvertGuidToString(string guid)
        {
            return guid.Replace("-", "");
        }

        //if string is more than 10
        public static bool IsStringMoreThanNCharacters(int n, string input)
        {

            return false;
        }

        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
                source = source.Substring(0, length) + "...";
            return source;
        }

        public static string RemoveSpaces(string input)
        {
            return input.Replace(" ", "");
        }

        public static string Slugify(this String input)
        {
            string tolower = input.ToLower();
            return tolower.Replace(" ", "_");
        }
    }
}
