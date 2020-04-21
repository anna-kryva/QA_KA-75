using System;

namespace Stack
{
    public class Stack<T>
    {
        private T[] _array;

        public Stack()
        {
            Count = 0;
            _array = new T[10];
        }

        public int Count { get; private set; }

        public T Peek()
        {
            return Count > 0 ? _array[Count] : default;
        }

        public T Pop()
        {
            var result = Peek();
            if (Count > 0) Count -= 1;
            return result;
        }

        public void Push(T item)
        {
            Count += 1;
            if (_array.Length <= Count) Array.Resize(ref _array, Count * 2);
            _array[Count] = item;
        }
    }
}