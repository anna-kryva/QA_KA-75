using System;

namespace Task2_CompareVersions
{
    public class VersionCompare
    {
        public int versionCompare(string v1, string v2)
        {
            int numPart1 = 0, numPart2 = 0;

            for (int i = 0, j = 0; i < v1.Length || j < v2.Length;)
            {
                while (i < v1.Length && v1[i] != '.')
                {
                    int digit = v1[i] == '0' ? 0 : v1[i] - '0';
                    numPart1 = numPart1 * 10 + digit;
                    i++;
                }
                
                while (j < v2.Length && v2[j] != '.')
                {
                    int digit = v2[j] == '0' ? 0 : v2[j] - '0';
                    numPart2 = numPart2 * 10 + digit;
                    j++;
                }

                if (numPart1 > numPart2)
                    return 1;
                if (numPart1 < numPart2)
                    return -1;
                
                numPart1 = numPart2 = 0;
                i++;
                j++;
            }
            return 0;
        }
    }
}
