using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCI
{
    public class MyStack<T>
    {
        private T[] stack;
        private int count = 0;
        public int Count { get { return count; } }

        public MyStack(){
            stack = new T[10];
        }

        public MyStack<T> Push(T t)
        {
            if(stack.Length == count)
            {
                Array.Resize(ref stack, count + 10);
            }
            stack[count] = t;
            count++;
            return this;
        }
        public T Pop()
        {
            count--;
            return stack[count];
        }
        public T Peek()
        {
            return stack[0];
        }
    }
}
