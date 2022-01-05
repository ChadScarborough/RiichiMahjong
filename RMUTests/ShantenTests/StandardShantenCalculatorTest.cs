using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TestHands;
using static RMU.Shanten.StandardShantenCalculator;
using RMU.Shanten.HandSplitter;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class StandardShantenCalculatorTest
    {
        private Hand _hand;
        private List<TileCollection> _collections;

        [TestMethod]
        public void HandWithFourTripletsAndASingleTile_HasShantenValueZero()
        {
            _hand = new DragonTestHand();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(0, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryAllManTestHand_ReturnsShantenValueZero()
        {
            _hand = new ArbitraryAllManTestHand();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(0, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryAllPinTestHand_ReturnsShantenValueOne()
        {
            _hand = new ArbitraryAllPinTestHand();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(1, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryAllSouTestHand_ReturnsShantenValueZero()
        {
            _hand = new ArbitraryAllSouTestHand();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(0, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand1_ReturnsShantenValueFive()
        {
            _hand = new ArbitraryTestHand1();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand2_ReturnsShantenValueFour()
        {
            _hand = new ArbitraryTestHand2();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(4, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand3_ReturnsShantenValueTwo()
        {
            _hand = new ArbitraryTestHand3();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(2, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand4_ReturnsShantenValueThree()
        {
            _hand = new ArbitraryTestHand4();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand5_ReturnsShantenValueThree()
        {
            _hand = new ArbitraryTestHand5();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand6_ReturnsShantenValueFive()
        {
            _hand = new ArbitraryTestHand6();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand7_ReturnsShantenValueFive()
        {
            _hand = new ArbitraryTestHand7();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand8_ReturnsShantenValueFive()
        {
            _hand = new ArbitraryTestHand8();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(5, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand9_ReturnsShantenValueThree()
        {
            _hand = new ArbitraryTestHand9();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(_collections));
        }

        [TestMethod]
        public void ArbitraryTestHand10_ReturnsShantenValueThree()
        {
            _hand = new ArbitraryTestHand10();
            _collections = HandSplitter.SplitHandBySuit(_hand.GetClosedTiles());
            Assert.AreEqual(3, CalculateShanten(_collections));
        }
    }
}
