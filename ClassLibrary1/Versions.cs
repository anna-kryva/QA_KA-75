using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskNamespace
{
    public class Versions
    {
        public static int CompareVersions(string str1, string str2)
        {
            str1 = str1.Replace(".", "");
            str2 = str2.Replace(".", "");
            int lenDiff = str1.Length - str2.Length;
            str1 = lenDiff < 0 ? str1 + String.Concat(Enumerable.Repeat("0", -lenDiff)) : str1;
            str2 = lenDiff > 0 ? str2 + String.Concat(Enumerable.Repeat("0", lenDiff)) : str2;

            if (String.Compare(str1, str2) == 1)
            {
                return (1);
            }
            else
            {
                if (String.Compare(str1, str2) == 0)
                {
                    return (0);
                }
                else
                {
                    return (-1);
                }
            }
        }
    }
}
