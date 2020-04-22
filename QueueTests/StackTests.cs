using NUnit.Framework;
using TaskNamespace;


namespace QueueAndCompareTests
{
    [TestFixture]
    public class StackTests
    {
        Stack<string> emptyStack;
        Stack<string> filledStack;
        Stack<string> tmp;

        [SetUp]
        public void Setup()
        {
            emptyStack = new Stack<string>();

            filledStack = new Stack<string>();
            filledStack.Push("First");
            filledStack.Push("Second");
            filledStack.Push("Third");
            filledStack.Push("Fourth");
            filledStack.Push("Fifth");

            tmp = filledStack;
        }

        [TestCase(new string[] { "First" }, 1)]
        [TestCase(new string[] { "First", "Second" }, 2)]
        [TestCase(new string[] { "First", "Second", "Third", "Fourth", "Fifth" }, 5)]
        public void PushSomeElementsInStack(string[] items, int res)
        {
            for (int i = 0; i < items.Length; i++)
            {
                emptyStack.Push(items[i]);
            }
            Assert.AreEqual(emptyStack.Count(), res);
        }

        [TestCase(2, 3)]
        [TestCase(4, 1)]
        [TestCase(5, 0)]
        [TestCase(7, 0)]
        public void PopSomeElementsFromTheStack_StackSize(int num, int res)
        {
            for (int i = 0; i < num; i++)
            {
                filledStack.Pop();
            }
            Assert.AreEqual(filledStack.Count(), res);
        }

        [TestCase(2, "Fourth")]
        [TestCase(4, "Second")]
        [TestCase(5, "First")]
        [TestCase(7, default(string))]
        public void PopSomeElementsFromTheStack_PopedItem(int num, string res)
        {
            string item = "";
            for (int i = 0; i < num; i++)
            {
                item = filledStack.Pop();
            }
            Assert.AreEqual(item, res);
        }

        [TestCase(new string[] { "First" }, "First")]
        [TestCase(new string[] { "First", "Second" }, "Second")]
        [TestCase(new string[] { "First", "Second", "Third", "Fourth", "Fifth" }, "Fifth")]
        [TestCase(new string[] { }, default(string))]
        public void PickElementFromStack(string[] items, string res)
        {
            for (int i = 0; i < items.Length; i++)
            {
                emptyStack.Push(items[i]);
            }
            Assert.AreEqual(emptyStack.Peek(), res);
        }

    }
}