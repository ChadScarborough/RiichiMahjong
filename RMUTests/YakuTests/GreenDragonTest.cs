using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Yaku;
using RMU.Tiles;
using RMU.Globals;
using RMU.Hands.TestHands;
using RMU.Yaku.YakuLists;

namespace RMUTests.YakuTests
{
    [TestClass]
    public class GreenDragonTest
    {
        private readonly AbstractYaku _greenDragon = YakuList.GREEN_DRAGON;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("Green Dragon", _greenDragon.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(1, _greenDragon.GetValue(TestHandList.DRAGON_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsAtLeastThreeGreenDragons()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsTrue(_greenDragon.CheckYaku(TestHandList.DRAGON_TEST_HAND, extraTile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsNoGreenDragons()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsFalse(_greenDragon.CheckYaku(TestHandList.ALL_SIMPLES_TEST_HAND, extraTile));
        }
    }
}
