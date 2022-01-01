using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand;
using RMU.Hand.TestHands;
using RMU.Yaku;
using static RMU.Yaku.YakuLists.YakuList;
using static RMU.Globals.StandardTileList;

namespace RMUTests.YakuTests
{
    [TestClass]
    public class LittleThreeDragonsTest
    {
        private IHand _hand;

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenGivenThreeRedAndGreenDragons_AndTwoWhiteDragons()
        {
            _hand = new LittleThreeDragonsTwoWhiteTestHand();
            Assert.IsTrue(LITTLE_THREE_DRAGONS.CheckYaku(_hand, OneSou()));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenGivenThreeRedAndWhiteDragons_AndTwoGreenDragons()
        {
            _hand = new LittleThreeDragonsTwoGreenTestHand();
            Assert.IsTrue(LITTLE_THREE_DRAGONS.CheckYaku(_hand, OneSou()));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenGivenThreeGreenAndWhiteDragons_AndTwoRedDragons()
        {
            _hand = new LittleThreeDragonsTwoRedTestHand();
            Assert.IsTrue(LITTLE_THREE_DRAGONS.CheckYaku(_hand, OneSou()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenGivenThreeOfEachDragon()
        {
            _hand = new DragonTestHand();
            Assert.IsFalse(LITTLE_THREE_DRAGONS.CheckYaku(_hand, SouthWind()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenGivenNoDragons()
        {
            _hand = new ArbitraryAllManTestHand();
            Assert.IsFalse(LITTLE_THREE_DRAGONS.CheckYaku(_hand, ONE_MAN));
        }
    }
}