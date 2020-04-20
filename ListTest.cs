using NUnit.Framework;

namespace QA1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetCurrentTest()
        {
            LinkedList list = new LinkedList();
            list.Add(4);
            Assert.AreEqual(4, list.GetCurrent().data);
        }

        [Test]
        public void GetNextTest()
        {
            LinkedList list = new LinkedList();
            list.Add(4);
            list.Add(34);
            Node current = list.GetCurrent();
            current = list.GetNext(current);
            Assert.AreEqual(34, current.data);
        }
    }
}