using System;

using NUnit.Framework;

namespace Tasks.Tests
{
    [TestFixture()]
    public class TestUQueue
    {
        [Test]
        public void TestEmpty()
        {
            var q = new UQueue();
            Assert.Throws(
                typeof(InvalidOperationException), 
                delegate { q.Peek(); }
            );

            Assert.Throws(
                typeof(InvalidOperationException),
                delegate { q.Dequeue(); }
            );
        }

        [TestCase()]
        public void TestEnqueueDequeue(params object[] args)
        {
            var q = new UQueue();
            for (int i = 0; i < args.Length;  ++i)
            {
                q.Enqueue(args[i]);
                Assert.AreEqual(q.Count, i + 1);
            }

            for (int i = 0; i < args.Length; ++i)
            {
                Assert.AreEqual(args[i], q.Dequeue());
                Assert.AreEqual(q.Count, args.Length - i - 1);
            }
        }
    }
}
