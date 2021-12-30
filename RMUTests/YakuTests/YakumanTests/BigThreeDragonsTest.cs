using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Yaku.Yakuman;
using RMU.Hand.TestHands;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.YakuLists;

namespace RMUTests.YakuTests.YakumanTests
{
    [TestClass]
    public class BigThreeDragonsTest
    {
        private AbstractYakuman _bigThreeDragons = YakumanList.BIG_THREE_DRAGONS;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("Big Three Dragons", _bigThreeDragons.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(13, _bigThreeDragons.GetValue(TestHandList.DRAGON_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsThreeOfEachDragon()
        {
            TileObject tile = StandardTileList.SOUTH_WIND;
            Assert.IsTrue(_bigThreeDragons.CheckYaku(TestHandList.DRAGON_TEST_HAND, tile));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandOnlyContainsTerminalTiles()
        {
            TileObject tile = StandardTileList.ONE_SOU;
            Assert.IsFalse(_bigThreeDragons.CheckYaku(TestHandList.ALL_TERMINALS_TEST_HAND, tile));
        }
    }
}
