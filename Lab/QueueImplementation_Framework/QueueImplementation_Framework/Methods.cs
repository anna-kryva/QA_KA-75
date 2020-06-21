using System;
using System.Collections.Generic;
using System.Text;

namespace QueueNamespace
{
    public class Methods
    {
       
        private static int ComparePieces(string str1,string str2)
        {
            str1 = str1.Length > 0 ? str1 : "0";
            str2 = str2.Length > 0 ? str2 : "0";
            if (str1 == str2)
            {
                return 0;
            }
            return Int16.Parse(str1)> Int16.Parse(str2)?1:-1;
        }
       private static void RemoveCharacters(ref string str1,ref string str2)
        {
            string[] trimchars = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " " };
            foreach(var c in trimchars)
            {
                str1=str1.Replace(c, string.Empty);
                str2 = str2.Replace(c, string.Empty);
            }
            if (str1.Replace(".", string.Empty).Length > 0)
            {
                throw new ArgumentException("First string has incorrect format","str1");               
            }
            if(str2.Replace(".", string.Empty).Length > 0)
            {
                throw new ArgumentException("Second string has incorrect parameter");
            }

        }
        
        public static int CompareVersions(string str1,string str2)
        {
            
            string s1_trimmed = str1.Substring(0);
            string s2_trimmed=str2.Substring(0);
            string s1_full = str1.Substring(0);
            string s2_full = str2.Substring(0);
            RemoveCharacters(ref s1_trimmed, ref s2_trimmed);
            int result,ind1,ind2;
            int diff = s1_trimmed.Length - s2_trimmed.Length;
            int max;
            if (diff < 0)
            {
                max = s2_trimmed.Length;
                for (int i = 0; i < -diff; i++)
                {
                    s1_full += ".";                    
                }
            }
            else
            {
                max = s1_trimmed.Length;
                for (int i = 0; i < diff; i++)
                {
                    s2_full += ".";                 
                }
            }
           
            for(int i = 0; i < max+1; i++)
            {
                ind1 = s1_full.IndexOf(".");
                ind2 = s2_full.IndexOf(".");                
                if (ind1 == -1)
                {
                    result = ComparePieces(s1_full.Substring(0), s2_full.Substring(0));
                    return result;
                }
                else
                {
                    result = ComparePieces(s1_full.Substring(0, ind1), s2_full.Substring(0, ind2));
                    if (result == 0)
                    {
                        s1_full = s1_full.Remove(0, ind1 + 1);
                        s2_full = s2_full.Remove(0, ind2 + 1);
                    }
                    else
                    {
                        return result;
                    }
                }
                
            }
            return 0;
        }
    }
}
