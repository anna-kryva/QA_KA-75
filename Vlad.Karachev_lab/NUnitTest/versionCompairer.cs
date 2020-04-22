using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTest
{
    public class versionCompairer
    {
        public static int compareVersion(string ver1, string ver2)
        {


            ver1.Split('.');
            var ver1Splitted = ver1.Split('.');
            var ver2Splitted = ver2.Split('.');
            int len = Math.Max(ver1Splitted.Length, ver2Splitted.Length);
            Array.Resize(ref ver1Splitted, len);
            for (int i = ver1Splitted.Length-1; ver1Splitted[i] == null; i--)
            {
                ver1Splitted[i] = "0";
            }
            Array.Resize(ref ver2Splitted, len);

            for (int i = ver2Splitted.Length-1; ver2Splitted[i] == null; i--)
            {
                ver2Splitted[i] = "0";
            }
            for (int i = 0; i < len; i++)
            {
                if (Int32.Parse(ver1Splitted[i]) > Int32.Parse(ver2Splitted[i]))
                {
                    return 1;
                }
                if (Int32.Parse(ver1Splitted[i]) < Int32.Parse(ver2Splitted[i]))
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
