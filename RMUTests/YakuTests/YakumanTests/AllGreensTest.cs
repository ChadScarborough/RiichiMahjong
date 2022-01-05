using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TestHands;
using static RMU.Yaku.YakuLists.YakumanList;
using static RMU.Globals.StandardTileList;

namespace RMUTests.YakuTests.YakumanTests
{
    [TestClass]
    public class AllGreensTest
    {
        private Hand _hand;

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsOnlyGreenTiles()
        {
            _hand = new AllGreensTestHand();
            Assert.IsTrue(ALL_GREENS.CheckYaku(_hand, GreenDragon()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOneNonGreenTile()
        {
            _hand = new AllGreensTestHand();
            Assert.IsFalse(ALL_GREENS.CheckYaku(_hand, RedDragon()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsArbitraryAssortmentOfSouTiles()
        {
            _hand = new ArbitraryAllSouTestHand();
            Assert.IsFalse(ALL_GREENS.CheckYaku(_hand, NINE_SOU));
        }
    }
}