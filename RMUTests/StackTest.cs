using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;

namespace RMUTests
{
    [TestClass]
    public class StackTest
    {
        Stack<int> stack = new Stack<int>(5);

        [TestMethod]
        public void StackIsEmpty_OnInitialization()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void StackContainsOneElement_AfterPushingOneElement()
        {
            stack.Push(69);
            Assert.AreEqual(1, stack.GetSize());
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void StackIsEmpty_AfterPushingOnceAndPoppingOnce()
        {
            stack.Push(69);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void StackReturnsValueOfX_AfterPoppingX()
        {
            stack.Push(69);
            Assert.AreEqual(69, stack.Pop());
        }

        [TestMethod]
        public void StackPopsYThenX_AfterPushingXThenY()
        {
            stack.Push(69);
            stack.Push(420);
            Assert.AreEqual(420, stack.Pop());
            Assert.AreEqual(69, stack.Pop());
        }

        [TestMethod]
        public void StackReturnsCorrectSize_AfterMultiplePushesAndPops()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Pop();
            stack.Pop();
            stack.Push(5);
            stack.Pop();
            stack.Pop();
            stack.Push(6);
            Assert.AreEqual(2, stack.GetSize());
        }

        [TestMethod]
        public void StackIsEmpty_AfterClearing()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());

        }
    }
}
