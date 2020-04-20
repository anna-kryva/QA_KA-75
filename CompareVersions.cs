using System;
using System.Collections.Generic;
using System.Text;

namespace QA1
{
    class Comparer
    {
        public int CompareVersions(string v1, string v2)
        {
            string[] numArr1 = v1.Split('.');
            string[] numArr2 = v2.Split('.');
            LinkedList numList1 = new LinkedList();
            LinkedList numList2 = new LinkedList();
            foreach(string num in numArr1)
            {
                numList1.Add(Int32.Parse(num));
            }
            foreach (string num in numArr2)
            {
                numList2.Add(Int32.Parse(num));
            }
            Node currentNode1 = numList1.GetCurrent();
            Node currentNode2 = numList2.GetCurrent();
            bool solved = false;
            int result = -10;
            while (!solved)
            {
                if (currentNode1.data > currentNode2.data)
                {
                    solved = true;
                    result = 1;
                }
                else if (currentNode1.data < currentNode2.data)
                {
                    solved = true;
                    result = -1;
                }
                else if (currentNode1.data == currentNode2.data)
                {
                    if (numList1.GetNext(currentNode1) == null && numList2.GetNext(currentNode2) == null)
                    {
                        solved = true;
                        result = 0;
                    }
                    else if (numList1.GetNext(currentNode1) == null && numList2.GetNext(currentNode2) != null)
                    {
                        currentNode2 = numList2.GetNext(currentNode2);
                        if (currentNode2.data == 0)
                        {
                            solved = true;
                            result = 0;
                        }
                        else
                        {
                            solved = true;
                            result = 1;
                        }
                    }
                    else if (numList1.GetNext(currentNode1) != null && numList2.GetNext(currentNode2) == null)
                    {
                        currentNode1 = numList1.GetNext(currentNode1);
                        if (currentNode1.data == 0)
                        {
                            solved = true;
                            result = 0;
                        }
                        else
                        {
                            solved = true;
                            result = 1;
                        }
                    }
                    else if (numList1.GetNext(currentNode1) != null && numList2.GetNext(currentNode2) != null)
                    {
                        currentNode1 = numList1.GetNext(currentNode1);
                        currentNode2 = numList2.GetNext(currentNode2);
                    }

                }
            }
            return result;


        }
    }
}
