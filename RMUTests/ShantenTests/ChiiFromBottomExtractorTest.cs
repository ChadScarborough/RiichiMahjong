using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;
using RMU.Shanten.HandSplitter;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class ChiiExtractorFromBottomTest
    {
        [TestMethod]
        public void ChiiExtractor_ExtractsChii_WhenGivenThreeConsecutiveTiles()
        {
            TileCollection man = new TileCollection(MAN, new List<Tile> { OneMan(), TwoMan(), ThreeMan() });
            ChiiFromBottomExtractor.ExtractChii(man);
            Assert.AreEqual(0, man.GetTiles().Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsChiiToNewClosedChiiComponent()
        {
            TileCollection man = new TileCollection(MAN, new List<Tile> { OneMan(), TwoMan(), ThreeMan() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(man);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(3, components[0].GetTiles().Count);
            Assert.AreEqual(CLOSED_CHII, components[0].GetComponentType());
            Assert.AreEqual(GROUP, components[0].GetGeneralComponentType());
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsChii_WhenThereIsADuplicateTile_InTheMiddleOfTheSequence()
        {
            TileCollection pin = new TileCollection(PIN, new List<Tile> { OnePin(), TwoPin(), TwoPin(), ThreePin() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(pin);
            Assert.AreEqual(1, pin.GetTiles().Count);
            Assert.IsTrue(AreTilesEquivalent(TWO_PIN, pin.GetTiles()[0]));
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(3, components[0].GetTiles().Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsTwoChiis_WhenThereAreTwoSeparateSequences()
        {
            TileCollection sou = new TileCollection(SOU, new List<Tile> { OneSou(), TwoSou(), ThreeSou(), FiveSou(), SixSou(), SevenSou() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(sou);
            Assert.AreEqual(0, sou.GetTiles().Count);
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsTwoChiis_WhenTheTwoSequencesAreIdentical()
        {
            TileCollection man = new TileCollection(MAN, new List<Tile> { OneMan(), OneMan(), TwoMan(), TwoMan(), ThreeMan(), ThreeMan() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(man);
            Assert.AreEqual(0, man.GetTiles().Count);
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsZeroChiis_WhenNoSequencesAreGiven()
        {
            TileCollection pin = new TileCollection(PIN, new List<Tile> { OnePin(), ThreePin(), FivePin(), SevenPin(), NinePin() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(pin);
            Assert.AreEqual(5, pin.GetSize());
            Assert.AreEqual(0, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsTwoChiis_WhenGivenTwoSequencesSeparatedByAnotherTile()
        {
            TileCollection sou = new TileCollection(SOU, new List<Tile> { OneSou(), TwoSou(), ThreeSou(), FiveSou(), SevenSou(), EightSou(), NineSou() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(sou);
            Assert.AreEqual(1, sou.GetSize());
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsTwoChiis_WhenGivenTwoPartiallyOverlappingSequences()
        {
            TileCollection man = new TileCollection(MAN, new List<Tile> { OneMan(), TwoMan(), TwoMan(), ThreeMan(), ThreeMan(), FourMan() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(man);
            Assert.AreEqual(0, man.GetSize());
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsThreeChiis_WhenGivenThreeIdenticalSequences()
        {
            TileCollection pin = new TileCollection(PIN, new List<Tile> { FourPin(), FourPin(), FourPin(), FivePin(), FivePin(), FivePin(), SixPin(), SixPin(), SixPin() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(pin);
            Assert.AreEqual(0, pin.GetSize());
            Assert.AreEqual(3, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsThreeChiis_WhenGivenThreeConsecutiveSequences()
        {
            TileCollection sou = new TileCollection(SOU, new List<Tile> { OneSou(), TwoSou(), ThreeSou(), FourSou(), FiveSou(), SixSou(), SevenSou(), EightSou(), NineSou() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(sou);
            Assert.AreEqual(0, sou.GetSize());
            Assert.AreEqual(3, components.Count);
        }

        [TestMethod]
        public void ChiiExtractor_ExtractsFourChiis_WhenGivenFourPartiallyOverlappingSequences()
        {
            TileCollection man = new TileCollection(MAN, new List<Tile> { OneMan(), TwoMan(), TwoMan(), ThreeMan(), ThreeMan(), ThreeMan(), FourMan(), FourMan(), FourMan(), FiveMan(), FiveMan(), SixMan() });
            List<ICompleteHandComponent> components = ChiiFromBottomExtractor.ExtractChii(man);
            Assert.AreEqual(0, man.GetSize());
            Assert.AreEqual(4, components.Count);
        }
    }
}
