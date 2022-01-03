using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand;
using RMU.Hand.TestHands;
using static RMU.Yaku.YakuLists.YakuList;
using static RMU.Globals.StandardTileList;

namespace RMUTests.YakuTests
{
    [TestClass]
    public class AllTerminalsAndHonorsTest
    {
        private AbstractHand _hand;

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsOnlyTerminalsAndHonors()
        {
            _hand = new AllTerminalsAndHonorsTestHand();
            Assert.IsTrue(ALL_TERMINALS_AND_HONORS.CheckYaku(_hand, WhiteDragon()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOnlyHonorTiles()
        {
            _hand = new DragonTestHand();
            Assert.IsFalse(ALL_TERMINALS_AND_HONORS.CheckYaku(_hand, SouthWind()));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOnlyTerminalTiles()
        {
            _hand = new AllTerminalsTestHand();
            Assert.IsFalse(ALL_TERMINALS_AND_HONORS.CheckYaku(_hand, NINE_SOU));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_OnArbitraryHand()
        {
            _hand = new ArbitraryTestHand1();
            Assert.IsFalse(ALL_TERMINALS_AND_HONORS.CheckYaku(_hand, SevenPin()));
        }
    }
}