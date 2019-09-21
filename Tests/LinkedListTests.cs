using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void CreateNode_SetsValueAndNextIsNull()
        {
            ListNode<int> node = new ListNode<int>(1);

            Assert.AreEqual(1, node.Value);
            Assert.IsNull(node.Next);
        }

        [Test]
        public void AddFirst_HeadAndTailAreSame()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFirst(1);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
            Assert.AreSame(list.Head, list.Tail);
        }
        [Test]
        public void AddFirstTwoElements_ListIsInCorrectState()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);

            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(list.Head.Next, list.Tail);
        }
        [Test]
        public void AddLast_HeadAndTailAreSame()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddLast(1);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
            Assert.AreSame(list.Head, list.Tail);
        }
        [Test]
        public void AddLastTwoElements_ListIsInCorrectState()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(list.Head.Next, list.Tail);
        }

        [Test]
        public void RemoveFirst_OneElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);

            list.RemoveFirst();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }
        [Test]
        public void RemoveLast_OneElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);

            list.RemoveLast();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }
        [Test]
        public void RemoveLast_TwoElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.RemoveLast();

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(list.Head, list.Tail);
        }
        [Test]
        public void RemoveFirst_EmptyList_Throws()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => { list.RemoveFirst(); });
        }
        [Test]
        public void RemoveLast_EmptyList_Throws()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => { list.RemoveLast(); });
        }
    }
}
