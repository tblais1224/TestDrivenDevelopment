using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    class ImmutableStackTests
    {


        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var emptyStack = ImmutableStack<int>.Empty;

            Assert.IsTrue(emptyStack.IsEmpty);
        }
        [Test]
        public void PeekAndPop_EmptyStack_ThrowsException()
        {
            var emptyStack = ImmutableStack<int>.Empty;

            Assert.Throws<InvalidOperationException>(() => { emptyStack.Peek(); });
            Assert.Throws<InvalidOperationException>(() => { emptyStack.Pop(); });
        }
        [Test]
        public void PushOnEmptyStackTwoItems_PeekOneElement_ReturnsCorrectValue()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);

            int result = stack.Peek();

            Assert.AreEqual(2, result);
        }
        [Test]
        public void PushOnEmptyStackOneItem_PopOneItem_ReturnsEmptyStack()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);

            var result = stack.Pop();

            Assert.IsTrue(result.IsEmpty);
        }
    }
}
