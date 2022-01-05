using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;
using static RMU.Globals.StandardTileList;
using RMU.Tiles;
using RMU.Shanten;
using RMU.Shanten.HandSplitter;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class PonExtractorTest
    {
        [TestMethod]
        public void PonExtractor_ExtractsPonFromTileCollection()
        {
            TileCollection man = new TileCollection(MAN, new List<TileObject> { OneMan(), OneMan(), OneMan() });
            PonExtractor.ExtractPon(man);
            Assert.AreEqual(0, man.GetTiles().Count);
        }

        [TestMethod]
        public void PonExtractor_ReturnsClosedPonCompleteHandComponent()
        {
            TileCollection dragon = new TileCollection(DRAGON, new List<TileObject> { GreenDragon(), GreenDragon(), GreenDragon() });
            List<ICompleteHandComponent> components;
            components = PonExtractor.ExtractPon(dragon);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(3, components[0].GetTiles().Count);
            Assert.AreEqual(CLOSED_PON, components[0].GetComponentType());
            Assert.AreEqual(GROUP, components[0].GetGeneralComponentType());
        }

        [TestMethod]
        public void PonExtractor_ExtractsThreeTilesAndLeavesOne_WhenGivenAListOfFourIdenticalTiles()
        {
            TileCollection wind = new TileCollection(WIND, new List<TileObject> { EastWind(), EastWind(), EastWind(), EastWind() });
            List<ICompleteHandComponent> components = PonExtractor.ExtractPon(wind);
            Assert.AreEqual(1, wind.GetTiles().Count);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(3, components[0].GetTiles().Count);
        }

        [TestMethod]
        public void PonExtractor_ExtractsTwoClosedPonComponents_WhenGivenTwoSetsOfThreeIdenticalTiles()
        {
            TileCollection pin = new TileCollection(PIN, new List<TileObject> { OnePin(), OnePin(), OnePin(), TwoPin(), TwoPin(), TwoPin() });
            List<ICompleteHandComponent> components = PonExtractor.ExtractPon(pin);
            Assert.AreEqual(0, pin.GetTiles().Count);
            Assert.AreEqual(2, components.Count);
            Assert.AreEqual(3, components[0].GetTiles().Count);
            Assert.AreEqual(3, components[1].GetTiles().Count);
        }

        [TestMethod]
        public void PonExtractor_DoesNotExtactPon_WhenOneDoesNotExist()
        {
            TileCollection sou = new TileCollection(SOU, new List<TileObject> { OneSou(), TwoSou(), ThreeSou() });
            List<ICompleteHandComponent> components = PonExtractor.ExtractPon(sou);
            Assert.AreEqual(3, sou.GetTiles().Count);
            Assert.AreEqual(0, components.Count);
        }
    }
}
