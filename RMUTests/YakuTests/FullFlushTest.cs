using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.TestHands;
using RMU.Yaku;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.YakuLists;

namespace RMUTests.YakuTests
{
    [TestClass]
    public class FullFlushTest
    {
        private AbstractYaku _fullFlush = YakuList.FULL_FLUSH;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("Full Flush", _fullFlush.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(6, _fullFlush.GetValue(TestHandList.NINE_GATES_TEST_HAND));
        }

        [TestMethod]
        public void ReturnsValueMinusOne_WhenHandIsOpen()
        {
            Assert.AreEqual(5, _fullFlush.GetValue(TestHandList.OPEN_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandOnlyContainsOneSuit()
        {
            Assert.IsTrue(_fullFlush.CheckYaku(TestHandList.NINE_GATES_TEST_HAND, StandardTileList.FIVE_MAN));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOneTileOfAnotherSuit()
        {
            Assert.IsFalse(_fullFlush.CheckYaku(TestHandList.NINE_GATES_TEST_HAND, StandardTileList.FIVE_PIN));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOnlyHonorTiles()
        {
            Assert.IsFalse(_fullFlush.CheckYaku(TestHandList.DRAGON_TEST_HAND, StandardTileList.SOUTH_WIND));
        }
    }
}
