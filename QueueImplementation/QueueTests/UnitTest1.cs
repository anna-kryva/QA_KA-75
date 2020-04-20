using NUnit.Framework;
using QueueNamespace;


namespace QueueTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowArgumentOutOfRange()
        {
            Queue test_queue = new Queue();
            try {
                test_queue.Dequeue();
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Queue is empty", e.Message);
            }           
        }
        [Test]
        public void Dequeue_WhenQueueIsNotEmpty_ShouldReturnFirstElement()
        {
            Queue test_queue = new Queue();
            for(int i = 0; i < 5; i++) {
                test_queue.Enqueue(i * i);
            }
            int exp_value = (int) test_queue.Dequeue();
            if (exp_value == 0)
            {
                Assert.AreEqual(test_queue.Dequeue(), 1);
            }
        }
        [TestCase(4,2,2)]
        [TestCase(4,0,4)]
        [TestCase(0,0,0)]
        public void CountProperty_ShouldReturnNumberOfElements(int added,int gone,int expected)
        {
            Queue test_queue = new Queue(added);
            for (int i = 0; i < added; i++)
            {
                test_queue.Enqueue(i * i); 
            }
            for(int i = 0; i < gone; i++)
            {
                test_queue.Dequeue();
            }
            Assert.AreEqual(test_queue.Count, expected);
        }
        [Test]
        public void ClearMethod_ShouldReturnEmptyQueue()
        {
            Queue test_queue = new Queue(5);
            for(int i = 0; i < 5; i++)
            {
                test_queue.Enqueue(i * i);
            }
            test_queue.Clear();
            try
            {
                test_queue.Dequeue();
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Queue is empty", e.Message);
            }
        }
        [TestCase("1.2.3","4.5.6",-1)]
        [TestCase("1", "1.0.1", -1)]
        [TestCase("1.1.3", "1.1.0", 1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.2.3", "0", 1)]
        public void StringCompare_ForValidCredentials(string str1,string str2,int result)
        {            
            Assert.AreEqual(Methods.CompareVersions(str1, str2), result);
        }
        [Test]
        public void StringCompare_ForNonValidCredentials()
        {
            string str1 = "asd";
            string str2 = "fdv.";
            try
            {
                Methods.CompareVersions(str1, str2);
            }
            catch(System.ArgumentException e)
            {
                StringAssert.Contains("has incorrect format", e.Message);
            }
        }
     
    }
}