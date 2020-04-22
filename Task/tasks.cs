using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
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


namespace ClassLibrary2
{
    public class VersionComparer
    {
        public int CompareVersion(string version1, string version2)
        {
            string[] arr1 = version1.Split('.');
            string[] arr2 = version2.Split('.');

            string[] larger = arr1.Length > arr2.Length ? arr1 : arr2;
            string[] smaller = arr1.Length < arr2.Length ? arr1 : arr2;

            for (var i = 0; i < smaller.Length; i++)
            {
                if (Convert.ToInt32(arr1[i]) > Convert.ToInt32(arr2[i]))
                {
                    return 1;
                }
                else if (Convert.ToInt32(arr1[i]) < Convert.ToInt32(arr2[i]))
                {
                    return -1;
                }
            }

            for (var i = smaller.Length; i < larger.Length; i++)
            {
                if (Convert.ToInt32(larger[i]) != 0) return larger == arr1 ? 1 : -1;
            }

            return 0;
        }
    }
}