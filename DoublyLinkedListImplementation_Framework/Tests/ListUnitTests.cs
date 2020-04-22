using NUnit.Framework;
using DoublyLinkedList;


namespace ListAndCompareTests
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void GetCurrent_WhenListIsEmpty_ShouldReturnDefValue()
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            Assert.AreEqual(test_list.GetCurrent(), default(int));       
        }
        [Test]
        public void GetCurrent_WhenListIsNotEmpty_ShouldReturnValue()
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(14);

            Assert.AreEqual(test_list.GetCurrent(), 14);
        }

        [Test]
        public void GetNext_WhenCurrentIsLast_ShouldReturnDefValue()
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(14);

            Assert.AreEqual(test_list.GetNext(), default(int));
        }
        [TestCase(36, 9)]
        [TestCase(88, 14)]
        public void GetNext_WhenCurrentIsNotLast_ShouldReturnValue(int a, int b)
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(a);
            test_list.Add(b);

            Assert.AreEqual(test_list.GetNext(), b);
        }

        [Test]
        public void GetPrevious_WhenCurrentIsHead_ShouldReturnDefValue()
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(14);

            Assert.AreEqual(test_list.GetPrevious(), default(int));
        }
        [TestCase(36, 9)]
        [TestCase(88, 14)]
        public void GetPrevious_WhenCurrentIsNotHead_ShouldReturnValue(int a, int b)
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(a);
            test_list.Add(b);

            test_list.MoveForward();

            Assert.AreEqual(test_list.GetPrevious(), a);
        }

        [TestCase(36, 9)]
        [TestCase(88, 14)]
        public void MoveForward_WorksOnTwoElList(int a, int b)
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(a);
            test_list.Add(b);

            test_list.MoveForward();

            Assert.AreEqual(test_list.GetCurrent(), b);
        }

        [TestCase(36, 9)]
        [TestCase(88, 14)]
        public void MoveBackward_WorksOnTwoElList(int a, int b)
        {
            DoublyLinkedList<int> test_list = new DoublyLinkedList<int>();
            test_list.Add(a);
            test_list.Add(b);

            test_list.MoveForward();
            test_list.MoveBackward();

            Assert.AreEqual(test_list.GetCurrent(), a);
        }



    }
}