using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TestHands;
using RMU.Shanten;
using RMU.Shanten.HandSplitter;

namespace RMUTests.ShantenTests;

[TestClass]
public class ThirteenOrphansShantenCalculatorTest
{
    [TestMethod]
    public void ThirteenOrphansSingleWaitTestHand_HasShantenValueZero()
    {
        Hand hand = new ThirteenOrphansSingleWaitTestHand();
        List<TileCollection> collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
        int shanten = ThirteenOrphansShantenCalculator.CalculateShanten(hand, collections);
        Assert.AreEqual(0, shanten);
    }

    [TestMethod]
    public void ThirteenOrphansThirteenWaitTestHand_HasShantenValueZero()
    {
        Hand hand = new ThirteenOrphansThirteenWaitTestHand();
        List<TileCollection> collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
        int shanten = ThirteenOrphansShantenCalculator.CalculateShanten(hand, collections);
        Assert.AreEqual(0, shanten);
    }
}