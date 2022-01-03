using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.TestHands;
using RMU.Yaku;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.YakuLists;
using static RMU.Hand.TestHands.TestHandList;

namespace RMUTests.YakuTests
{
    [TestClass]
    public class RedDragonTest
    {
        private readonly AbstractYaku _redDragon = YakuList.RED_DRAGON;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("Red Dragon", _redDragon.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(1, _redDragon.GetValue(DRAGON_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsAtLeastThreeRedDragons()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsTrue(_redDragon.CheckYaku(DRAGON_TEST_HAND, extraTile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsNoGreenDragons()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsFalse(_redDragon.CheckYaku(ALL_SIMPLES_TEST_HAND, extraTile));
        }
    }
}
