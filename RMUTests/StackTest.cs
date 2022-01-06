using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Globals.DataStructures;

namespace RMUTests
{
    [TestClass]
    public class StackTest
    {
        readonly Stack<int> _stack = new Stack<int>();

        [TestMethod]
        public void StackIsEmpty_OnInitialization()
        {
            Assert.IsTrue(_stack.IsEmpty());
        }

        [TestMethod]
        public void StackContainsOneElement_AfterPushingOneElement()
        {
            _stack.Push(69);
            Assert.AreEqual(1, _stack.GetSize());
            Assert.IsFalse(_stack.IsEmpty());
        }

        [TestMethod]
        public void StackIsEmpty_AfterPushingOnceAndPoppingOnce()
        {
            _stack.Push(69);
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty());
        }

        [TestMethod]
        public void StackReturnsValueOfX_AfterPoppingX()
        {
            _stack.Push(69);
            Assert.AreEqual(69, _stack.Pop());
        }

        [TestMethod]
        public void StackPopsYThenX_AfterPushingXThenY()
        {
            _stack.Push(69);
            _stack.Push(420);
            Assert.AreEqual(420, _stack.Pop());
            Assert.AreEqual(69, _stack.Pop());
        }

        [TestMethod]
        public void StackReturnsCorrectSize_AfterMultiplePushesAndPops()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _stack.Push(4);
            _stack.Pop();
            _stack.Pop();
            _stack.Push(5);
            _stack.Pop();
            _stack.Pop();
            _stack.Push(6);
            Assert.AreEqual(2, _stack.GetSize());
        }

        [TestMethod]
        public void StackIsEmpty_AfterClearing()
        {
            _stack.Push(1);
            Assert.IsFalse(_stack.IsEmpty());
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty());

        }
    }
}
