using System;
using System.Collections;

namespace Tasks
{
    public class UQueue
    {

        //////////////////////////////////////////////////
        // Q operations
        //////////////////////////////////////////////////

        public void Enqueue(object el)
        {
            lst.Add(el);
        }

        public object Dequeue()
        {
            var res = Peek();
            lst.RemoveAt(0);
            return res;
        }

        public void Clear()
        {
            lst.Clear();
        }

        public object Peek()
        {
            if (lst.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return lst[0];
        }

        //////////////////////////////////////////////////
        // Data members
        //////////////////////////////////////////////////

        private ArrayList lst = new ArrayList();

        public int Count
        {
            get
            {
                return lst.Count;
            }
        }

        //////////////////////////////////////////////////
        // Misc
        //////////////////////////////////////////////////

        public override string ToString()
        {
            return "Front [" + string.Join(" ,", lst.ToArray()) + "] Rear";
        }
    }
}
