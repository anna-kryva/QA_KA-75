using System;

namespace Utils
{
    public static class Functions
    {
        public static int CompareVersions(string v1, string v2)
        {
            v1 = v1.Replace(".", string.Empty);
            v2 = v2.Replace(".", string.Empty);
            if (v1.Length > v2.Length) v2 = v2.PadRight(v1.Length, '0');
            else if (v1.Length < v2.Length) v1 = v1.PadRight(v2.Length, '0');
            
            int v1Numeric = int.Parse(v1);
            int v2Numeric = int.Parse(v2);

            if (v1Numeric > v2Numeric) return 1;
            if (v1Numeric < v2Numeric) return -1;
            return 0;
        }

        public static string Pad(string v, int length, char value)
        {
            for (int i = 0; i < length; i++) v += value;
            return v;
        }
    }
}