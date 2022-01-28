using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TestHands;
using RMU.Shanten;

namespace RMUTests.ShantenTests;

[TestClass]
public class ShantenCalculatorTest
{
    [TestMethod]
    public void SevenPairsTestHand_HasShantenValueZero()
    {
        Hand hand = new SevenPairsTestHand();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(0, shanten);
    }

    [TestMethod]
    public void SevenPairsWithOneDuplicatePairTestHand_HasShantenValueOne()
    {
        Hand hand = new SevenPairsWithOneDuplicatePairTestHand();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(1, shanten);
    }

    [TestMethod]
    public void ThirteenOrphansSingleWaitTestHand_HasShantenValueZero()
    {
        Hand hand = new ThirteenOrphansSingleWaitTestHand();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(0, shanten);
    }

    [TestMethod]
    public void ThirteenOrphansThirteenWaitTestHand_HasShantenValueZero()
    {
        Hand hand = new ThirteenOrphansThirteenWaitTestHand();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(0, shanten);
    }

    [TestMethod]
    public void DragonTestHand_HasShantenValueZero()
    {
        Hand hand = new DragonTestHand();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(0, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand1_HasShantenValueThree()
    {
        Hand hand = new ArbitraryTestHand1();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(3, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand2_HasShantenValueFour()
    {
        Hand hand = new ArbitraryTestHand2();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(4, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand3_HasShantenValueTwo()
    {
        Hand hand = new ArbitraryTestHand3();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(2, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand4_HasShantenValueThree()
    {
        Hand hand = new ArbitraryTestHand4();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(3, shanten);
    }
    
    [TestMethod]
    public void ArbitraryTestHand5_HasShantenValueThree()
    {
        Hand hand = new ArbitraryTestHand5();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(3, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand6_HasShantenValueFive()
    {
        Hand hand = new ArbitraryTestHand6();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(4, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand7_HasShantenValueFive()
    {
        Hand hand = new ArbitraryTestHand7();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(5, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand8_HasShantenValueFive()
    {
        Hand hand = new ArbitraryTestHand8();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(5, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand9_HasShantenValueThree()
    {
        Hand hand = new ArbitraryTestHand9();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(3, shanten);
    }

    [TestMethod]
    public void ArbitraryTestHand10_HasShantenValueThree()
    {
        Hand hand = new ArbitraryTestHand10();
        int shanten = ShantenCalculator.CalculateShanten(hand);
        Assert.AreEqual(3, shanten);
    }
}