using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;

namespace RMUTests
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

        [TestMethod]
        public void ListIsEmpty_WhenInitialized()
        {
            Assert.AreEqual(0, doublyLinkedList.GetSize());
            Assert.IsTrue(doublyLinkedList.IsEmpty());
        }

        [TestMethod]
        public void ListContainsOneElement_AfterAddingOneElement()
        {
            doublyLinkedList.AddHead(69);
            Assert.IsFalse(doublyLinkedList.IsEmpty());
            Assert.AreEqual(1, doublyLinkedList.GetSize());
        }

        [TestMethod]
        public void ListReturnsValueOfNodeX_WhenNodeXIsRemovedFromHeadEnd()
        {
            doublyLinkedList.AddHead(69);
            Assert.AreEqual(69, doublyLinkedList.RemoveHead());
            Assert.IsTrue(doublyLinkedList.IsEmpty());
        }

        [TestMethod]
        public void ListReturnsValueOfNodeX_WhenNodeXIsRemovedFromTailEnd()
        {
            doublyLinkedList.AddTail(69);
            Assert.AreEqual(69, doublyLinkedList.RemoveTail());
            Assert.IsTrue(doublyLinkedList.IsEmpty());
        }

        [TestMethod]
        public void FirstNodeAddedRemainsAsTail_AfterAddingOnTheHeadEnd()
        {
            doublyLinkedList.AddHead(69);
            doublyLinkedList.AddHead(2);
            doublyLinkedList.AddHead(420);
            Assert.AreEqual(69, doublyLinkedList.GetTail().GetValue());
            Assert.AreEqual(420, doublyLinkedList.GetHead().GetValue());
            Assert.AreEqual(3, doublyLinkedList.GetSize());
        }

        [TestMethod]
        public void FirstNodeAddedRemainsAsHead_AfterAddingOnTheTailEnd()
        {
            doublyLinkedList.AddTail(69);
            doublyLinkedList.AddTail(2);
            doublyLinkedList.AddTail(420);
            Assert.AreEqual(69, doublyLinkedList.GetHead().GetValue());
            Assert.AreEqual(420, doublyLinkedList.GetTail().GetValue());
            Assert.AreEqual(3, doublyLinkedList.GetSize());
        }

        [TestMethod]
        public void GetNextMethod_ReturnsNextNodeInTheList()
        {
            doublyLinkedList.AddHead(69);
            doublyLinkedList.AddHead(420);
            Assert.AreEqual(69, doublyLinkedList.GetHead().GetNext().GetValue());
        }

        [TestMethod]
        public void ListThrowsException_WhenAttemptingToRemoveElementFromEmptyList()
        {
            Exception ex = null;

            Assert.IsTrue(doublyLinkedList.IsEmpty());

            try
            {
                doublyLinkedList.RemoveHead();
            }
            catch(Exception ExpectedException)
            {
                ex = ExpectedException;
            }

            Assert.IsNotNull(ex);

            ex = null;

            try
            {
                doublyLinkedList.RemoveTail();
            }
            catch (Exception ExpectedException)
            {
                ex = ExpectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void ListIsEmpty_AfterClearing()
        {
            doublyLinkedList.AddHead(69);
            doublyLinkedList.AddHead(420);
            Assert.IsFalse(doublyLinkedList.IsEmpty());
            doublyLinkedList.Clear();
            Assert.IsTrue(doublyLinkedList.IsEmpty());
        }
    }
}
