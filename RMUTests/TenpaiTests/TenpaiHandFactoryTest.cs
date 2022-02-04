using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TenpaiHands;
using RMU.Hands.TestHands;
using RMU.Shanten;
using static RMU.Globals.Enums;

namespace RMUTests.TenpaiTests;

[TestClass]
public class TenpaiHandFactoryTest
{
    [TestMethod]
    public void ThirteenOrphansSingleWaitTestHand_BecomesThirteenOrphansTenpaiHand()
    {
        Hand hand = new ThirteenOrphansSingleWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(THIRTEEN_ORPHANS, tenpaiHand.GetHandType());
    }

    [TestMethod]
    public void ThirteenOrphansThirteenWaitTestHand_BecomesThirteenOrphansTenpaiHand()
    {
        Hand hand = new ThirteenOrphansThirteenWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(THIRTEEN_ORPHANS, tenpaiHand.GetHandType());
    }

    [TestMethod]
    public void SevenPairsTestHand_BecomesSevenPairsTenpaiHand()
    {
        Hand hand = new SevenPairsTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(SEVEN_PAIRS, tenpaiHand.GetHandType());
    }

    [TestMethod]
    public void PairWaitTestHand_BecomesStandardTenpaiHandWithPairWait()
    {
        Hand hand = new PairWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(STANDARD, tenpaiHand.GetHandType());
        Assert.AreEqual(PAIR_WAIT, tenpaiHand.GetWaitType());
    }

    [TestMethod]
    public void TwoSidedTripletWaitTestHand_BecomesStandardHandWithTwoSidedTripletWait()
    {
        Hand hand = new TwoSidedTripletWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(STANDARD, tenpaiHand.GetHandType());
        Assert.AreEqual(TWO_SIDED_TRIPLET_WAIT, tenpaiHand.GetWaitType());
    }

    [TestMethod]
    public void ClosedWaitTestHand_BecomesStandardHandWithClosedWait()
    {
        Hand hand = new ClosedWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(STANDARD, tenpaiHand.GetHandType());
        Assert.AreEqual(CLOSED_WAIT, tenpaiHand.GetWaitType());
    }

    [TestMethod]
    public void OpenWaitTestHand_BecomesStandardHandWithOpenWait()
    {
        Hand hand = new OpenWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(STANDARD, tenpaiHand.GetHandType());
        Assert.AreEqual(OPEN_WAIT, tenpaiHand.GetWaitType());
    }

    [TestMethod]
    public void EdgeWaitTestHand_BecomesStandardHandWithEdgeWait()
    {
        Hand hand = new EdgeWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(STANDARD, tenpaiHand.GetHandType());
        Assert.AreEqual(EDGE_WAIT, tenpaiHand.GetWaitType());
    }
}