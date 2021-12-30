using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;

namespace RMUTests
{
    [TestClass]
    public class QueueTest
    {
        Queue<int> queue = new Queue<int>();

        [TestMethod]
        public void QueueIsEmpty_OnInitialization()
        {
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void QueueHasSizeOne_AfterEnqueueingOneElement()
        {
            queue.Enqueue(69);
            Assert.AreEqual(1, queue.GetSize());
        }

        [TestMethod]
        public void QueueIsEmpty_AfterOneEnqueueAndOneDequeue()
        {
            queue.Enqueue(69);
            queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void ReturnsX_AfterEnqueueingXAndThenDequeueing()
        {
            queue.Enqueue(69);
            Assert.AreEqual(69, queue.Dequeue());
        }

        [TestMethod]
        public void ThrowsException_WhenDequeueingAnEmptyQueue()
        {
            Exception ex = null;

            Assert.IsTrue(queue.IsEmpty());

            try
            {
                queue.Dequeue();
            }
            catch (Exception ExpectedException)
            {
                ex = ExpectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void PeekReturnsValueX_WithoutDequeueing()
        {
            queue.Enqueue(69);
            Assert.AreEqual(69, queue.Peek());
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(69, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void DequeueReturnsXThenY_AfterEnqueueingXThenY()
        {
            queue.Enqueue(69);
            queue.Enqueue(420);
            queue.Enqueue(666);
            Assert.AreEqual(69, queue.Dequeue());
            Assert.AreEqual(420, queue.Dequeue());
            Assert.AreEqual(666, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void QueueIsEmpty_AfterClearing()
        {
            queue.Enqueue(69);
            queue.Enqueue(420);
            Assert.IsFalse(queue.IsEmpty());
            queue.Clear();
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
