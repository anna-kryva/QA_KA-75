using System;

namespace QueueNamespace {
    public class Queue
    {
        int first;
        int last;
        int capacity;
        object[] queue_array;
        public Queue() : this(10) { }
        public Queue(int size)
        {
            capacity = size;
            first = last = -1;
            queue_array = new object[capacity];
        }
        public Queue(System.Collections.ICollection col)
        {
            capacity = col.Count;
            first = capacity==0?-1:0;
            last = capacity - 1;
            queue_array = new object[capacity];
            col.CopyTo(queue_array, 0);         
        }
        private void IncreaseCapacity()
        {
            capacity+=(capacity*2);
            object[] new_queue = new object[capacity];
            int k=0;
            for(int i = first; i <=last; i++,k++)
            {
                new_queue[k] = queue_array[i];
            }
            first = 0;
            last = k-1;
            queue_array = new_queue;
        }
        public int Count
        {
            get
            {
                if (first < 0) return 0;
                return last - first + 1;
            }
        }
        public void Enqueue(object ob)
        {
            
            if (last+1 == capacity)
            {
                this.IncreaseCapacity();
            }
            if (first < 0)
            {
                first++;
                last++;
                queue_array[first] = ob;
            }
            else
            {
                last++;
                queue_array[last] = ob;
            }   
        }
        public object Dequeue()
        {
            if (first < 0)
            {
                throw new ArgumentOutOfRangeException("first", first, "Queue is empty");
            }
            else
            {
                object ob = queue_array[first];
                first++;
                return ob;
            }
        }
        public object Peek()
        {
            if (first < 0)
            {
                throw new ArgumentOutOfRangeException("first", first, "Queue is empty");
            }
            else
            {
                return queue_array[first];
            }
        }
        public void Clear()
        {
            first = last = -1;
            queue_array = new object[capacity];
        }
        
    } 
}