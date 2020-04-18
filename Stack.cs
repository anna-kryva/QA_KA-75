using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ
{
    public class Stack<T>
    {
        StackNode<T> Head;
        int count;

        public Stack()
        {
            Head = null;
            count = 0;
        }

        public T Push(T data)
        {
            var el = new StackNode<T>(data);
            el.Previous = Head;
            Head = el;
            count++;
            return Head.Data;
        }

        public T Pop()
        {
            if (count != 0)
            {
                Head = Head.Previous;
                count--;
                if (count != 0)
                {
                    return Head.Data;
                }
            }
            return default(T);
        }

        public T Peek()
        {
            if (count != 0)
            {
                return Head.Data;
            }
            return default(T);
        }
        public int GetCount()
        {
            return count;
        }


        

    }
}
