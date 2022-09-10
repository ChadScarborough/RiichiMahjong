using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.CompleteHands;
using RMU.Hands.TenpaiHands;
using RMU.Hands.TestHands;
using RMU.Shanten;
using RMU.Tiles;
using static RMU.Hands.CompleteHands.CompleteHandFactory;
using static RMU.Globals.Enums;

namespace RMUTests;
/*
[TestClass]
public class CompleteHandTest
{
    [TestMethod]
    public void SevenPairsTenpaiHand_BecomesSevenPairsCompleteHand()
    {
        Hand hand = new SevenPairsTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(SEVEN_PAIRS, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void ThirteenOrphansSingleWaitTenpaiHand_BecomesThirteenOrphansCompleteHand()
    {
        Hand hand = new ThirteenOrphansSingleWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(THIRTEEN_ORPHANS, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void ThirteenOrphansThirteenWaitTenpaiHand_BecomesThirteenOrphansCompleteHand()
    {
        Hand hand = new ThirteenOrphansThirteenWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(THIRTEEN_ORPHANS, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void PairWaitTenpaiHand_BecomesStandardCompleteHand()
    {
        Hand hand = new PairWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(STANDARD, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void TwoSidedTripletWaitTenpaiHand_BecomesStandardCompleteHand()
    {
        Hand hand = new TwoSidedTripletWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(STANDARD, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void ClosedWaitTenpaiHand_BecomesStandardCompleteHand()
    {
        Hand hand = new ClosedWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(STANDARD, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void OpenWaitTenpaiHand_BecomesStandardCompleteHand()
    {
        Hand hand = new OpenWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(STANDARD, completeHand.GetCompleteHandType());
    }

    [TestMethod]
    public void EdgeWaitTenpaiHand_BecomesStandardCompleteHand()
    {
        Hand hand = new EdgeWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        foreach (TileObject tile in tenpaiHand.GetWaits())
        {
            Console.WriteLine(tile.GetValue() + " " + tile.GetSuit());
        }
        ICompleteHand completeHand = CreateCompleteHand(tenpaiHand, tenpaiHand.GetWaits()[0]);
        Assert.AreEqual(STANDARD, completeHand.GetCompleteHandType());
    }
}
*/