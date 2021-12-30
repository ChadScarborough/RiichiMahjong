using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Shanten;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using RMU.Hand.CompleteHands.CompleteHandComponents;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class PairExtractorTest
    {
        [TestMethod]
        public void PairExtractor_ExtractsPair_WhenGivenTwoIdenticalTiles()
        {
            TileCollection man = new TileCollection(MAN, new List<TileObject> { OneMan(), OneMan() });
            PairExtractor.ExtractPair(man);
            Assert.AreEqual(0, man.GetSize());
        }

        [TestMethod]
        public void PairExtractor_ExtractsPair_ToNewPairComponent()
        {
            TileCollection pin = new TileCollection(PIN, new List<TileObject> { ThreePin(), ThreePin() });
            List<ICompleteHandComponent> components = PairExtractor.ExtractPair(pin);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(2, components[0].GetTiles().Count);
            Assert.AreEqual(PAIR_COMPONENT, components[0].GetComponentType());
            Assert.AreEqual(PAIR, components[0].GetGeneralComponentType());
        }

        [TestMethod]
        public void PairExtractor_ExtractsPairAndLeavesOneTile_WhenGivenThreeIdenticalTiles()
        {
            TileCollection sou = new TileCollection(SOU, new List<TileObject> { FiveSou(), FiveSou(), FiveSou() });
            List<ICompleteHandComponent> components = PairExtractor.ExtractPair(sou);
            Assert.AreEqual(1, sou.GetSize());
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(2, components[0].GetTiles().Count);
        }

        [TestMethod]
        public void PairExtractor_ExtractsTwoPairs_WhenGivenTwoUniquePairs()
        {
            TileCollection wind = new TileCollection(WIND, new List<TileObject> { EastWind(), EastWind(), WestWind(), WestWind() });
            List<ICompleteHandComponent> components = PairExtractor.ExtractPair(wind);
            Assert.AreEqual(0, wind.GetSize());
            Assert.AreEqual(2, components.Count);
        }
        
        [TestMethod]
        public void PairExtractor_ExtractsThreePairs_WhenGivenThreeSetsOfTwoIdenticalTiles()
        {
            TileCollection dragon = new TileCollection(DRAGON, new List<TileObject> { GreenDragon(), GreenDragon(), RedDragon(), RedDragon(), WhiteDragon(), WhiteDragon() });
            List<ICompleteHandComponent> components = PairExtractor.ExtractPair(dragon);
            Assert.AreEqual(0, dragon.GetSize());
            Assert.AreEqual(3, components.Count);
        }

        [TestMethod]
        public void PairExtractor_ExtractsZeroPairs_WhenGivenNoIdenticalTiles()
        {
            TileCollection wind = new TileCollection(WIND, new List<TileObject> { EastWind(), SouthWind(), WestWind(), NorthWind() });
            List<ICompleteHandComponent> components = PairExtractor.ExtractPair(wind);
            Assert.AreEqual(4, wind.GetSize());
            Assert.AreEqual(0, components.Count);
        }
    }
}
