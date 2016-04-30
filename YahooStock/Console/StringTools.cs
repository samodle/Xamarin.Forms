using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analytics
{
    public static class StringHelper
    {
        public static List<string> splitAtCommas(string rawString)
        {
            string str = string.Join("", rawString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            return str.Split(',').ToList<string>();
        }

    }
}
