using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    [TestFixture]
    public class ListTests
    {
        [Test]
       
        public void testCreation()
        {
            //testing if list can be created
            var linkedList = new myLinkedList();
            int val = 1;

            linkedList.add(val);
            
            Assert.AreEqual(val, linkedList.getCurrent().val);
        }
        [Test]
        public void testGetNext()
        {

            int[] mas = { 1, 2, 3 };
            var linkedList = new myLinkedList(mas[0]);
            linkedList.add(mas[1]);

            Assert.AreEqual(mas[1], linkedList.getNext().val);

        }
    }
}
