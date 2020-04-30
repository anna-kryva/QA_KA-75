using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackNamespace
{
    public class Compare
    {
        public static int CompareVersions(string v1, string v2)
        {
            v1 = v1.Replace(".", "0");
            v2 = v2.Replace(".", "0");

            return String.Compare(v1.PadRight(v2.Length, '0'), v2.PadRight(v1.Length, '0'));
        }
    }
}
