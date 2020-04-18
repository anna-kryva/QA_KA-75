using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ
{
    public class Stack<T>
    {
        StackNode<T> head;
        StackNode<T> tail;
        StackNode<T> current;
        int count;

        public Stack()
        {
            head = null;
            tail = null;
            current = null;
            count = 0;
        }

        public void Add(T data)
        {
            StackNode<T> node = new StackNode<T>(data);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            if(current == null)
            {
                current = tail;
            }
            count++;
        }
        public T GetCurrent()
        {
            return current.Data;
        }
        public T GetNext()
        {
            if(current == tail)
            {
                return default;
            }
            current = current.Next;
            return current.Next.Data;

        }
        public T GetPrevious()
        {
            if(current == head)
            {
                return default;
            }
            current = current.Previous;
            return current.Previous.Data;
        }

    }
}
