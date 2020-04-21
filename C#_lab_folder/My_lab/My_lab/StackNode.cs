using System;
using System.Collections.Generic;
using System.Text;

namespace My_lab
{
    class StackNode<T>
    {
        public T Data { get; set; }
        public StackNode<T> next { get; set; }
        public StackNode(T Data)
        {
            this.Data = Data;
        }
    }
}
