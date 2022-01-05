using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Yaku;
using RMU.Yaku.YakuLists;
using RMU.Tiles;
using RMU.Globals;
using RMU.Hands.TestHands;


namespace RMUTests.YakuTests
{
    [TestClass]
    public class HalfFlushTest
    {
        private readonly AbstractYaku _halfFlush = YakuList.HALF_FLUSH;

        [TestMethod]
        public void GetName_ReturnsCorrectName()
        {
            Assert.AreEqual("Half Flush", _halfFlush.GetName());
        }

        [TestMethod]
        public void GetValue_ReturnsThreeWithClosedHand()
        {
            Assert.AreEqual(3, _halfFlush.GetValue(TestHandList.HALF_FLUSH_TEST_HAND));
        }

        [TestMethod]
        public void GetValue_ReturnsTwoWithOpenHand()
        {
            Assert.AreEqual(2, _halfFlush.GetValue(TestHandList.OPEN_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_IfHandContainsOneSuitPlusHonorTiles()
        {
            Assert.IsTrue(_halfFlush.CheckYaku(TestHandList.HALF_FLUSH_TEST_HAND, StandardTileList.SOUTH_WIND));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_IfHandContainsOneSuitAndNoHonorTiles()
        {
            Assert.IsFalse(_halfFlush.CheckYaku(TestHandList.NINE_GATES_TEST_HAND, StandardTileList.NINE_MAN));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_IfHandContainsOnlyHonorTiles()
        {
            Assert.IsFalse(_halfFlush.CheckYaku(TestHandList.DRAGON_TEST_HAND, StandardTileList.SOUTH_WIND));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_IfOneTileIsOfADifferentSuit()
        {
            Assert.IsFalse(_halfFlush.CheckYaku(TestHandList.HALF_FLUSH_TEST_HAND, StandardTileList.FIVE_SOU));
        }
    }
}
