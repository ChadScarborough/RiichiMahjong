using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Shanten;
using RMU.Hands;
using RMU.Hands.TestHands;
using RMU.Shanten.HandSplitter;

namespace RMUTests.ShantenTests;

[TestClass]
public class SevenPairsShantenCalculatorTest
{
    [TestMethod]
    public void SevenPairsTestHand_HasShantenValueZero()
    {
        Hand hand = new SevenPairsTestHand();
        List<TileCollection> collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
        int shanten = SevenPairsShantenCalculator.CalculateShanten(hand, collections);
        Assert.AreEqual(0, shanten);
    }

    [TestMethod]
    public void SevenPairsWithOneDuplicatePairTestHand_HasShantenValueOne()
    {
        Hand hand = new SevenPairsWithOneDuplicatePairTestHand();
        List<TileCollection> collections = HandSplitter.SplitHandBySuit(hand.GetClosedTiles());
        int shanten = SevenPairsShantenCalculator.CalculateShanten(hand, collections);
        Assert.AreEqual(1, shanten);
    }
}