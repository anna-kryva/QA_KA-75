using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCI
{
    public class Task2
    {
        public static int CompareVersions(string str1, string str2)
        {
            string[] s1 = str1.Split('.');
            string[] s2 = str2.Split('.');

            for(int i = 0; true; i++)
            {
                if (i < s1.Length && i < s2.Length)
                {
                    if (int.Parse(s1[i]) > int.Parse(s2[i])) return 1;
                    if (int.Parse(s1[i]) < int.Parse(s2[i])) return -1;
                }
                else if (i < s1.Length && i == s2.Length)
                {
                    if (int.Parse(s1[i]) > 0) return 1;
                    else return 0;
                }
                else if (i == s1.Length && i < s2.Length)
                {
                    if (int.Parse(s2[i]) > 0) return -1;
                    else return 0;
                }
                else return 0;
            }

        }
    }
}
