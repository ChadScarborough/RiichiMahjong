using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Shanten;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.StandardTileList;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class ConsecutiveTaatsuExtractorTest
    {
        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsConsecutiveTaatsuFromCollection()
        {
            TileCollection man = new TileCollection(MAN, new List<TileObject> { FourMan(), FiveMan() });
            ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(man);
            Assert.AreEqual(0, man.GetSize());
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsConsecutiveTaatsu_ToNewConsecutiveTaatsuComponent()
        {
            TileCollection pin = new TileCollection(PIN, new List<TileObject> { EightPin(), NinePin() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(pin);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(2, components[0].GetTiles().Count);
            Assert.AreEqual(INCOMPLETE_SEQUENCE_EDGE_WAIT, components[0].GetComponentType());
            Assert.AreEqual(TAATSU, components[0].GetGeneralComponentType());
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsConsecutiveTaatsu_AndLeavesOneTile_WhenGivenThreeConsecutiveTiles()
        {
            TileCollection sou = new TileCollection(SOU, new List<TileObject> { ThreeSou(), FourSou(), FiveSou() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(sou);
            Assert.AreEqual(1, sou.GetSize());
            Assert.AreEqual(1, components.Count);
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_CreatesIncompleteSequenceEdgeWaitComponent_WhenBottomValueIsOne()
        {
            TileCollection man = new TileCollection(MAN, new List<TileObject> { OneMan(), TwoMan() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(man);
            Assert.AreEqual(INCOMPLETE_SEQUENCE_EDGE_WAIT, components[0].GetComponentType());
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_CreatesIncompleteSequenceOpenWaitComponent_WhenItDoesNotIncludeATerminalTile()
        {
            TileCollection pin = new TileCollection(PIN, new List<TileObject> { SevenPin(), EightPin() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(pin);
            Assert.AreEqual(INCOMPLETE_SEQUENCE_OPEN_WAIT, components[0].GetComponentType());
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsTwoConsectiveTaatsuComponents_WhenGivenFourConsecutiveTiles()
        {
            TileCollection sou = new TileCollection(SOU, new List<TileObject> { TwoSou(), ThreeSou(), FourSou(), FiveSou() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(sou);
            Assert.AreEqual(0, sou.GetSize());
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsTwoConsecutiveTaatsuComponents_WhenGivenTwoTaatsuSeparatedByAnUnusedTile()
        {
            TileCollection man = new TileCollection(MAN, new List<TileObject> { ThreeMan(), FourMan(), SixMan(), EightMan(), NineMan() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(man);
            Assert.AreEqual(1, man.GetSize());
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsTwoConsecutiveTaatsuComponents_WhenGivenTwoIdenticalConsecutiveTaatsu()
        {
            TileCollection pin = new TileCollection(PIN, new List<TileObject> { SixPin(), SixPin(), SevenPin(), SevenPin() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(pin);
            Assert.AreEqual(0, pin.GetSize());
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsThreeConsecutiveTaatsuComponents_WhenGivenThreeOverlappingConsecutiveTaatsu()
        {
            TileCollection sou = new TileCollection(SOU, new List<TileObject> { TwoSou(), ThreeSou(), ThreeSou(), FourSou(), FourSou(), FiveSou() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(sou);
            Assert.AreEqual(0, sou.GetSize());
            Assert.AreEqual(3, components.Count);
        }

        [TestMethod]
        public void ConsecutiveTaatsuExtractor_ExtractsOneConsecutiveTaatsu_WhenTheUpperTileHasADuplicate()
        {
            TileCollection man = new TileCollection(MAN, new List<TileObject> { FiveMan(), SixMan(), SixMan() });
            List<ICompleteHandComponent> components = ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(man);
            Assert.AreEqual(1, man.GetSize());
            Assert.AreEqual(1, components.Count);
        }
    }
}
