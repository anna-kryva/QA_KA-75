using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class myLinkedList
    {
        Node head;
        Node current;
        public myLinkedList(int val)
        {
            head =new Node(val);
            current = head;
        }
        public myLinkedList()
        {
            head = null;
            current = head;
        }
        public Node getHead()
        {
            return head;
        }
        public Node getNext()
        {
            try
            {
                current = current.next;
                return current;
            }
            catch(Exception _)
            {
                return null;
            }
        }
        public myLinkedList add(int val)
        {
            //test
            if (head != null)
            {
                Node end = head;
                while (end.next != null)
                {
                    end = end.next;
                }
                end.next = new Node(val);
                
            }
            else
            {
                head = new Node(val);
                current = head;
            }
            return this;

        }
        public Node getCurrent()
        {
            return current;
        }

    }
    class Node
    {
        public int val;
        public Node next=null;
        public Node(int a)
        {
            val = a;
        }
        public Node()
        {
        }
    }
}
