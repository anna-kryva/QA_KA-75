using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTests
{
    public class Task2
    {
        public static int Ver_comp(string ver1, string ver2)
        {

            List<string> ver1lsit = ver1.Split('.').ToList<string>();
            List<string> ver2lsit = ver2.Split('.').ToList<string>();

            int lengthdiff = ver1lsit.Count - ver2lsit.Count;
            if (lengthdiff > 0)
            {
                for (int i = 0; i < lengthdiff; i++)
                {
                    ver2lsit.Add("0");
                }

            }
            else if (lengthdiff < 0)
            {
                for (int i = 0; i > lengthdiff; i--)
                {
                    ver1lsit.Add("0");
                }
            }

            int size = ver1lsit.Count;

            int[] ver1arr = Array.ConvertAll(ver1lsit.ToArray(), int.Parse);
            int[] ver2arr = Array.ConvertAll(ver2lsit.ToArray(), int.Parse);

            for (int i = 0; i < size; i++)
            {
                if (ver1arr[i] > ver2arr[i])
                    return 1;
                if (ver1arr[i] < ver2arr[i])
                    return -1;
            }

            return 0;

        }
    }
}
