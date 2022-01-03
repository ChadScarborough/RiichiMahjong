using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RMU.Globals.DataStructures;

namespace RMUTests
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        DoublyLinkedList<int> _doublyLinkedList = new DoublyLinkedList<int>();

        [TestMethod]
        public void ListIsEmpty_WhenInitialized()
        {
            Assert.AreEqual(0, _doublyLinkedList.GetSize());
            Assert.IsTrue(_doublyLinkedList.IsEmpty());
        }

        [TestMethod]
        public void ListContainsOneElement_AfterAddingOneElement()
        {
            _doublyLinkedList.AddHead(69);
            Assert.IsFalse(_doublyLinkedList.IsEmpty());
            Assert.AreEqual(1, _doublyLinkedList.GetSize());
        }

        [TestMethod]
        public void ListReturnsValueOfNodeX_WhenNodeXIsRemovedFromHeadEnd()
        {
            _doublyLinkedList.AddHead(69);
            Assert.AreEqual(69, _doublyLinkedList.RemoveHead());
            Assert.IsTrue(_doublyLinkedList.IsEmpty());
        }

        [TestMethod]
        public void ListReturnsValueOfNodeX_WhenNodeXIsRemovedFromTailEnd()
        {
            _doublyLinkedList.AddTail(69);
            Assert.AreEqual(69, _doublyLinkedList.RemoveTail());
            Assert.IsTrue(_doublyLinkedList.IsEmpty());
        }

        [TestMethod]
        public void FirstNodeAddedRemainsAsTail_AfterAddingOnTheHeadEnd()
        {
            _doublyLinkedList.AddHead(69);
            _doublyLinkedList.AddHead(2);
            _doublyLinkedList.AddHead(420);
            Assert.AreEqual(69, _doublyLinkedList.GetTail().GetValue());
            Assert.AreEqual(420, _doublyLinkedList.GetHead().GetValue());
            Assert.AreEqual(3, _doublyLinkedList.GetSize());
        }

        [TestMethod]
        public void FirstNodeAddedRemainsAsHead_AfterAddingOnTheTailEnd()
        {
            _doublyLinkedList.AddTail(69);
            _doublyLinkedList.AddTail(2);
            _doublyLinkedList.AddTail(420);
            Assert.AreEqual(69, _doublyLinkedList.GetHead().GetValue());
            Assert.AreEqual(420, _doublyLinkedList.GetTail().GetValue());
            Assert.AreEqual(3, _doublyLinkedList.GetSize());
        }

        [TestMethod]
        public void GetNextMethod_ReturnsNextNodeInTheList()
        {
            _doublyLinkedList.AddHead(69);
            _doublyLinkedList.AddHead(420);
            Assert.AreEqual(69, _doublyLinkedList.GetHead().GetNext().GetValue());
        }

        [TestMethod]
        public void ListThrowsException_WhenAttemptingToRemoveElementFromEmptyList()
        {
            Exception ex = null;

            Assert.IsTrue(_doublyLinkedList.IsEmpty());

            try
            {
                _doublyLinkedList.RemoveHead();
            }
            catch(Exception expectedException)
            {
                ex = expectedException;
            }

            Assert.IsNotNull(ex);

            ex = null;

            try
            {
                _doublyLinkedList.RemoveTail();
            }
            catch (Exception expectedException)
            {
                ex = expectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void ListIsEmpty_AfterClearing()
        {
            _doublyLinkedList.AddHead(69);
            _doublyLinkedList.AddHead(420);
            Assert.IsFalse(_doublyLinkedList.IsEmpty());
            _doublyLinkedList.Clear();
            Assert.IsTrue(_doublyLinkedList.IsEmpty());
        }
    }
}
