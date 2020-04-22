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
            int diff = v1.Length - v2.Length;

            v2 = (diff > 0 ? v2 + String.Concat(Enumerable.Repeat("0", diff)) : v2);
            v1 = (diff < 0 ? v1 + String.Concat(Enumerable.Repeat("0", -diff)) : v1);

            return String.Compare(v1, v2);
        }
    }
}
