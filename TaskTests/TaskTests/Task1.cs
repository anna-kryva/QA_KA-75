using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTests
{
    public class ListElement<T>
    {
        public ListElement(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public ListElement<T> Previous { get; set; }
        public ListElement<T> Next { get; set; }
    }

    public class Double_Linked_List<T>
    {
        ListElement<T> Head;
        int count;

        public Double_Linked_List()
        {
            Head = null;

            count = 0;
        }

        public ListElement<T> Add(T data)
        {
            ListElement<T> el = new ListElement<T>(data);

            el.Previous = Head;
            if (Head != null)
                Head.Next = el;
            el.Next = null;
            Head = el;

            count++;
            return el;
        }

        public ListElement<T> GetCurrent()
        {
            return Head;
        }

        public ListElement<T> GetNext()
        {
            return Head.Next;
        }

        public ListElement<T> GetPrevious()
        {
            return Head.Previous;
        }

    }
}
