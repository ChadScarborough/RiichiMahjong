using RMU.Hand;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.TestHands;
using static RMU.Yaku.YakuLists.YakumanList;
using static RMU.Globals.StandardTileList;

namespace RMUTests.YakuTests.YakumanTests
{
    [TestClass]
    public class FourBigWindsTest
    {
        private AbstractHand _hand;

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenGivenAtLeastThreeOfEachWind()
        {
            _hand = new FourBigWindsTestHand();
            Assert.IsTrue(FOUR_BIG_WINDS.CheckYaku(_hand, GreenDragon()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenGivenOnlyTwoEastWinds()
        {
            _hand = new FourLittleWindsTwoEastsTestHand();
            Assert.IsFalse(FOUR_BIG_WINDS.CheckYaku(_hand, GreenDragon()));
        }
        
        [TestMethod]
        public void CheckYakuReturnsFalse_WhenGivenOnlyTwoSouthWinds()
        {
            _hand = new FourLittleWindsTwoSouthsTestHand();
            Assert.IsFalse(FOUR_BIG_WINDS.CheckYaku(_hand, GreenDragon()));
        }
        
        [TestMethod]
        public void CheckYakuReturnsFalse_WhenGivenOnlyTwoWestWinds()
        {
            _hand = new FourLittleWindsTwoWestsTestHand();
            Assert.IsFalse(FOUR_BIG_WINDS.CheckYaku(_hand, GreenDragon()));
        }
        
        [TestMethod]
        public void CheckYakuReturnsFalse_WhenGivenOnlyTwoNorthWinds()
        {
            _hand = new FourLittleWindsTwoNorthsTestHand();
            Assert.IsFalse(FOUR_BIG_WINDS.CheckYaku(_hand, GreenDragon()));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenExtraTileCompletesYaku()
        {
            _hand = new FourLittleWindsTwoEastsTestHand();
            Assert.IsTrue(FOUR_BIG_WINDS.CheckYaku(_hand, EastWind()));
        }
    }
}