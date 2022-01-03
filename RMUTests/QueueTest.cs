using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RMU.Globals.DataStructures;

namespace RMUTests
{
    [TestClass]
    public class QueueTest
    {
        readonly Queue<int> _queue = new Queue<int>();

        [TestMethod]
        public void QueueIsEmpty_OnInitialization()
        {
            Assert.IsTrue(_queue.IsEmpty());
        }

        [TestMethod]
        public void QueueHasSizeOne_AfterEnqueueingOneElement()
        {
            _queue.Enqueue(69);
            Assert.AreEqual(1, _queue.GetSize());
        }

        [TestMethod]
        public void QueueIsEmpty_AfterOneEnqueueAndOneDequeue()
        {
            _queue.Enqueue(69);
            _queue.Dequeue();
            Assert.IsTrue(_queue.IsEmpty());
        }

        [TestMethod]
        public void ReturnsX_AfterEnqueueingXAndThenDequeueing()
        {
            _queue.Enqueue(69);
            Assert.AreEqual(69, _queue.Dequeue());
        }

        [TestMethod]
        public void ThrowsException_WhenDequeueingAnEmptyQueue()
        {
            Exception ex = null;

            Assert.IsTrue(_queue.IsEmpty());

            try
            {
                _queue.Dequeue();
            }
            catch (Exception expectedException)
            {
                ex = expectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void PeekReturnsValueX_WithoutDequeueing()
        {
            _queue.Enqueue(69);
            Assert.AreEqual(69, _queue.Peek());
            Assert.IsFalse(_queue.IsEmpty());
            Assert.AreEqual(69, _queue.Dequeue());
            Assert.IsTrue(_queue.IsEmpty());
        }

        [TestMethod]
        public void DequeueReturnsXThenY_AfterEnqueueingXThenY()
        {
            _queue.Enqueue(69);
            _queue.Enqueue(420);
            _queue.Enqueue(666);
            Assert.AreEqual(69, _queue.Dequeue());
            Assert.AreEqual(420, _queue.Dequeue());
            Assert.AreEqual(666, _queue.Dequeue());
            Assert.IsTrue(_queue.IsEmpty());
        }

        [TestMethod]
        public void QueueIsEmpty_AfterClearing()
        {
            _queue.Enqueue(69);
            _queue.Enqueue(420);
            _queue.Clear();
            Assert.IsTrue(_queue.IsEmpty());
        }
    }
}
