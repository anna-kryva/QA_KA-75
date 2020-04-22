using System;
using System.Collections.Generic;
using System.Text;

namespace MyLab
{
    public class Stack<T>
    {
        StackNode<T> head;
        int size;

        public Stack()
        {
            head = null;
            size = 0;
        }

        public void Push(T el)
        {
            var newHead = new StackNode<T>(el);
            newHead.next = head;
            head = newHead;
            size++;
        }

        public T Pop()
        {
            if (size != 0)
            {
                var item = head.Data;
                head = head.next;
                size--;
                return item;
            }
            return (default(T));
        }

        public T Peek()
        {
            if (size != 0)
            {
                return head.Data;
            }
            return default(T);
        }

        public int Count()
        {
            return size;
        }

    }
}
