using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class Methods
    {
        public static int CompareVersions(string str0, string str1)
        {
            Char[] separator = { '.' };
            List<String> splitted0 = new List<String>(str0.Split(separator));
            List<String> splitted1 = new List<String>(str1.Split(separator));
            if (splitted0.Count != 3)
            {
                throw new ArgumentException("Invalid version format: " + str0);
            }

            if (splitted1.Count != 3)
            {
                throw new ArgumentException("Invalid version format: " + str1);
            }

            List<int> splittedInt0 = splitted0.ConvertAll(
                new Converter<string, int>(s =>
                {
                    try
                    {
                        int x = Int32.Parse(s);
                        if (x < 0)
                        {
                            throw new ArgumentException("Invalid version format: " + str0);
                        }
                        return x;
                    }
                    catch (FormatException e)
                    {
                        throw new ArgumentException("Invalid version format: " + str0);
                    }
                }
                )
            );

            List<int> splittedInt1 = splitted1.ConvertAll(
                new Converter<string, int>(s =>
                {
                    try
                    {
                        int x = Int32.Parse(s);
                        if (x < 0)
                        {
                            throw new ArgumentException("Invalid version format: " + str1);
                        }
                        return x;
                    }
                    catch (FormatException e)
                    {
                        throw new ArgumentException("Invalid version format: " + str1);
                    }
                }
                )
            );

            int result = 0;

            for (int i = 0; i < 3; ++i)
            {
                result =
                    splittedInt0[i] == splittedInt1[i]
                    ?
                    0
                    :
                    splittedInt0[i] > splittedInt1[i]
                    ?
                    1
                    :
                    -1;
                if (result != 0)
                    return result;
            }

            return result;
        }

       
        
    }
}
