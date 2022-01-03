using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Shanten;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.StandardTileList;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class NonconsecutiveTaatsuExtractorTest
    {
        TileCollection man, pin, sou;
        List<ICompleteHandComponent> components;

        [TestMethod]
        public void NonconsecutiveTaatsuExtract_ExtractsNonconsecutiveTaatsu()
        {
            man = new TileCollection(MAN, new List<TileObject> { OneMan(), ThreeMan() });
            NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(man);
            Assert.AreEqual(0, man.GetSize());
        }

        [TestMethod]
        public void NonconsecutiveTaatsuExtractor_ExtractsTilesToNewNonconsecutiveTaatsuComponent()
        {
            pin = new TileCollection(PIN, new List<TileObject> { TwoPin(), FourPin() });
            components = NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(pin);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(2, components[0].GetTiles().Count);
            Assert.AreEqual(INCOMPLETE_SEQUENCE_CLOSED_WAIT, components[0].GetComponentType());
            Assert.AreEqual(TAATSU, components[0].GetGeneralComponentType());
        }

        [TestMethod]
        public void NonconsecutiveTaatsuExtractor_ExtractsOneNonconsecutiveTaatsu_AndLeavesOneTile_WhenGivenThreeConsecutiveTiles()
        {
            sou = new TileCollection(SOU, new List<TileObject> { FourSou(), FiveSou(), SixSou() });
            components = NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(sou);
            Assert.AreEqual(1, sou.GetSize());
            Assert.AreEqual(1, components.Count);
        }

        [TestMethod]
        public void NonconsecutiveTaatsuExtractor_ExtractsTwoNonconsecutiveTaatsu_WhenGivenFourConsecutiveTiles()
        {
            man = new TileCollection(MAN, new List<TileObject> { SixMan(), SevenMan(), EightMan(), NineMan() });
            components = NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(man);
            Assert.AreEqual(0, man.GetSize());
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void NonconsecutiveTaatsuExtractor_ExtractsTwoNonconsecutiveTaatsu_WhenGivenTwoIdenticalNonconsecutiveTaatsu()
        {
            pin = new TileCollection(PIN, new List<TileObject> { SevenPin(), SevenPin(), NinePin(), NinePin() });
            components = NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(pin);
            Assert.AreEqual(0, pin.GetSize());
            Assert.AreEqual(2, components.Count);
        }
    }
}
