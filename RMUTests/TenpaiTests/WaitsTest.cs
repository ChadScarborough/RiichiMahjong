using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TenpaiHands;
using RMU.Hands.TestHands;
using RMU.Shanten;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Functions;

namespace RMUTests.TenpaiTests;

[TestClass]
public class WaitsTest
{
    [TestMethod]
    public void SevenPairsTestHand_HasRedDragonWait()
    {
        Hand hand = new SevenPairsTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(1, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(RED_DRAGON, tenpaiHand.GetWaits()[0]));
    }

    [TestMethod]
    public void ThirteenOrphansSingleWaitTestHand_HasWhiteDragonWait()
    {
        Hand hand = new ThirteenOrphansSingleWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(1, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(WHITE_DRAGON, tenpaiHand.GetWaits()[0]));
    }

    [TestMethod]
    public void ThirteenOrphansThirteenWaitTestHand_HasThirteenWaits()
    {
        Hand hand = new ThirteenOrphansThirteenWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(13, tenpaiHand.GetWaits().Count);
    }

    [TestMethod]
    public void PairWaitTestHand_HasRedDragonWait()
    {
        Hand hand = new PairWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(1, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(RED_DRAGON, tenpaiHand.GetWaits()[0]));
    }

    [TestMethod]
    public void TwoSidedTripletWaitTestHand_HasEastWindAndWhiteDragonWaits()
    {
        Hand hand = new TwoSidedTripletWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(2, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(EAST_WIND, tenpaiHand.GetWaits()[0]));
        Assert.IsTrue(AreTilesEquivalent(WHITE_DRAGON, tenpaiHand.GetWaits()[1]));
    }

    [TestMethod]
    public void ClosedWaitTestHand_HasFivePinWait()
    {
        Hand hand = new ClosedWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(1, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(FIVE_PIN, tenpaiHand.GetWaits()[0]));
    }

    [TestMethod]
    public void OpenWaitTestHand_HasOnePinAndFourPinWaits()
    {
        Hand hand = new OpenWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(2, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(ONE_PIN, tenpaiHand.GetWaits()[0]));
        Assert.IsTrue(AreTilesEquivalent(FOUR_PIN, tenpaiHand.GetWaits()[1]));
    }

    [TestMethod]
    public void EdgeWaitTestHand_HasThreeManWait()
    {
        Hand hand = new EdgeWaitTestHand();
        ShantenCalculator.CalculateShanten(hand);
        ITenpaiHand tenpaiHand = hand.GetTenpaiHands()[0];
        Assert.AreEqual(1, tenpaiHand.GetWaits().Count);
        Assert.IsTrue(AreTilesEquivalent(THREE_MAN, tenpaiHand.GetWaits()[0]));
    }
}