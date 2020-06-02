using NUnit.Framework;
using Stack;

namespace Tests
{
    [TestFixture]
    public class StackShould
    {
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<int>();
        }

        private Stack<int> _stack;

        [TestCase(10)]
        public void Stack_Push_ReturnTrue(int count)
        {
            for (var i = 0; i < count; i++) _stack.Push(i);

            Assert.AreEqual(count, _stack.Count);
        }

        [TestCase]
        public void Stack_Pop_ReturnTrue()
        {
            var expected = 255;

            _stack.Push(expected);
            var actual = _stack.Pop();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5)]
        public void Stack_PopLength_ReturnTrue(int length)
        {
            for (var i = 0; i < length * 2; i++) _stack.Push(i);
            for (var i = 0; i < length; i++) _stack.Pop();

            Assert.AreEqual(length, _stack.Count);
        }

        [TestCase]
        public void Stack_Peek_ReturnTrue()
        {
            var expected = 255;

            _stack.Push(expected);
            var actual = _stack.Peek();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5)]
        public void Stack_PeekLength_ReturnTrue(int length)
        {
            for (var i = 0; i < length * 2; i++) _stack.Push(i);
            for (var i = 0; i < length; i++) _stack.Peek();

            Assert.AreEqual(length * 2, _stack.Count);
        }

        [TestCase(2)]
        public void Stack_PopMoreThanLength_ReturnTrue(int length)
        {
            for (var i = 0; i < length; i++) _stack.Push(i);
            for (var i = 0; i < _stack.Count + 2; i++) _stack.Pop();

            Assert.AreEqual(0, _stack.Count);
        }
    }
}