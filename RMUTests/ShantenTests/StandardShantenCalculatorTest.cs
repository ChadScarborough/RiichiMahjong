using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static RMU.Shanten.StandardShantenCalculator;
using RMU.Shanten;
using RMU.Hand.TestHands;
using RMU.Hand;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class StandardShantenCalculatorTest
    {
        private IHand hand;
        private List<TileCollection> collections;

        [TestMethod]
        public void HandWithFourTripletsAndASingleTile_HasShantenValueZero()
        {
            hand = new DragonTestHand();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(0, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryAllManTestHand_ReturnsShantenValueZero()
        {
            hand = new ArbitraryAllManTestHand();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(0, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryAllPinTestHand_ReturnsShantenValueOne()
        {
            hand = new ArbitraryAllPinTestHand();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(1, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryAllSouTestHand_ReturnsShantenValueZero()
        {
            hand = new ArbitraryAllSouTestHand();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(0, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand1_ReturnsShantenValueFive()
        {
            hand = new ArbitraryTestHand1();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand2_ReturnsShantenValueFour()
        {
            hand = new ArbitraryTestHand2();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(4, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand3_ReturnsShantenValueTwo()
        {
            hand = new ArbitraryTestHand3();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(2, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand4_ReturnsShantenValueThree()
        {
            hand = new ArbitraryTestHand4();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand5_ReturnsShantenValueThree()
        {
            hand = new ArbitraryTestHand5();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand6_ReturnsShantenValueFive()
        {
            hand = new ArbitraryTestHand6();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand7_ReturnsShantenValueFive()
        {
            hand = new ArbitraryTestHand7();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand8_ReturnsShantenValueFive()
        {
            hand = new ArbitraryTestHand8();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand9_ReturnsShantenValueThree()
        {
            hand = new ArbitraryTestHand9();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(collections));
        }

        [TestMethod]
        public void ArbitraryTestHand10_ReturnsShantenValueThree()
        {
            hand = new ArbitraryTestHand10();
            collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(collections));
        }
    }
}
