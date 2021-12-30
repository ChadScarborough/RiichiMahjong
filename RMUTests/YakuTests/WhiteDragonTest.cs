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
    public class WhiteDragonTest
    {
        private AbstractYaku _whiteDragon = YakuList.WHITE_DRAGON;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("White Dragon", _whiteDragon.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(1, _whiteDragon.GetValue(TestHandList.DRAGON_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsAtLeastThreeWhiteDragons()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsTrue(_whiteDragon.CheckYaku(TestHandList.DRAGON_TEST_HAND, extraTile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsNoGreenDragons()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsFalse(_whiteDragon.CheckYaku(TestHandList.ALL_SIMPLES_TEST_HAND, extraTile));
        }
    }
}
