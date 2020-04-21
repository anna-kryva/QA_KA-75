using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ
{
    public class StackNode<T>
    {
        public StackNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public StackNode<T> Previous { get; set; }
    }
}
