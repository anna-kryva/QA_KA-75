using NUnit.Framework;
using QueueNamespace;


namespace QueueAndCompareTests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowArgumentOutOfRange()
        {
            Fifo test_queue = new Fifo();
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
            Fifo test_queue = new Fifo();
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
            Fifo test_queue = new Fifo(added);
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
            Fifo test_queue = new Fifo(5);
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
        
     
    }
}