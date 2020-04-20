using System;
using System.Collections;
using System.Collections.Generic;

namespace Tas1_DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private DoublyNode<T> _head;
        private DoublyNode<T> _tail;
		private DoublyNode<T> current;
        private int _count;

        public int Count
        {
            get 
            {
                return _count;
            }
        }

        public DoublyLinkedList()
        {
            _head = null;
			current = _head;
            _tail = null;
            _count = 0;
        }

        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (_head == null)
            {
                _head = node;
                current = _head;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            _count++;
        }

        public DoublyNode<T> GetNth(int index)
        {
            DoublyNode<T> currentNode = _head;
            int i = 0; 

            while (currentNode != null)
            {
                if (i == index)
                    return currentNode;
                i++;
                currentNode = currentNode.Next;
            }

            throw new InvalidOperationException();
        }

		public T GetCurrent()
		{
			if (current != null)
			    return current.Data;
            else
                return default(T);			
		}

		public T GetNext()
		{
			if (current.Next != null)
                return current.Next.Data;
            else
                return default(T);
		}

		public T GetPrevious()
		{
            if (current.Previous != null)
                return current.Previous.Data;
            else
                return default(T);
        }

		public void MoveNext()
		{
            if (current.Next != null)
                current = current.Next;
            else
                throw new InvalidOperationException();

        }
		public void MovePrevious()
		{
            if (current.Previous != null)
                current = current.Previous;
            else
                throw new InvalidOperationException();
        }


		IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> currentNode = _head;
            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> currentNode = _tail;
            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Previous;
            }
        }
    }
}
