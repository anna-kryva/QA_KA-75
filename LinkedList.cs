using System;
using System.Collections.Generic;
using System.Text;

namespace QA1
{
    public class Node
    {
        public Node next;
        public int data;
    }

    public class LinkedList
    {
        private Node head;

        public void Add(int newData)
        {
            if (head == null)
            {
                head = new Node();

                head.data = newData;
                head.next = null;
            }
            else
            {
                Node newNode = new Node();
                newNode.data = newData;
                Node currentNode = GetLast();
                currentNode.next = newNode;
            }
        }

        public Node GetCurrent()
        {
            return head;
        }

        public Node GetNext(Node currentNode)
        {
            return currentNode.next;
        }

        private Node GetLast()
        {
            Node currentNode = head;
            while (currentNode.next != null)
            {
                currentNode = GetNext(currentNode);
            }
            return currentNode;
        }
    }



}
