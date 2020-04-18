using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListSpace
{
    public class Node
    {
        public Node next;
        public Object data;
        public Node GetNext()                   // GetNext method   
        {
            return this.next;
        }
        public Object GetData()                   // GetData method   
        {
            return this.data;
        }
    }
    public class LinkedList
    {
        private Node head;
        private Node current;
        public void AddFirst(Object data)       //AddFirst method
        {
            Node toAdd = new Node();

            toAdd.data = data;
            toAdd.next = head;
            if (head == null)      // setting current node
            {
                current = head;
            }
            head = toAdd;
        }
        public void AddLast(Object data)        // AddLast method
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;

                current = head;  // setting current node
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;

                Node currentnode = head;
                while (currentnode.next != null)
                {
                    currentnode = currentnode.next;
                }
                currentnode.next = toAdd;
            }
        }
        public Node GetCurrent()                // GetCurrent method
        {
            return current;
        }
        public Node GetHead()                   // GetHead method   
        {
            return head;
        }
    }
}
