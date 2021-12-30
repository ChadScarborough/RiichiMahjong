using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;

namespace RMUTests
{
    [TestClass]
    public class OpenMeldTest
    {
        [TestMethod]
        public void SuccessfullyCreates_OpenMeld()
        {
            TileObject tile = TileFactory.CreateTile(1, Enums.Suit.Man);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.Pon, tile);
            Assert.IsNotNull(openMeld);
        }

        [TestMethod]
        public void CallingPon_CreatesListOfThreeIdenticalTiles()
        {
            TileObject tile = TileFactory.CreateTile(6, Enums.Suit.Pin);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.Pon, tile);
            Assert.AreEqual(6, openMeld.GetTiles()[0].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[1].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[2].GetValue());
            Enums.Suit suit = Enums.Suit.Pin;
            Assert.AreEqual(suit, openMeld.GetTiles()[0].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[1].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingLowChii_CreatesListOfConsecutiveTiles_WhereCalledTileIsTheHighest()
        {
            TileObject tile = TileFactory.CreateTile(6, Enums.Suit.Pin);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.LowChii, tile);
            Assert.AreEqual(4, openMeld.GetTiles()[0].GetValue());
            Assert.AreEqual(5, openMeld.GetTiles()[1].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[2].GetValue());
            Enums.Suit suit = Enums.Suit.Pin;
            Assert.AreEqual(suit, openMeld.GetTiles()[0].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[1].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingMidChii_CreatesListOfConsecutiveTiles_WhereCalledTileIsTheMiddle()
        {
            TileObject tile = TileFactory.CreateTile(6, Enums.Suit.Pin);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.MidChii, tile);
            Assert.AreEqual(5, openMeld.GetTiles()[0].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[1].GetValue());
            Assert.AreEqual(7, openMeld.GetTiles()[2].GetValue());
            Enums.Suit suit = Enums.Suit.Pin;
            Assert.AreEqual(suit, openMeld.GetTiles()[0].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[1].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingHighChii_CreatesListOfConsecutiveTiles_WhereCalledTileIsTheLowest()
        {
            TileObject tile = TileFactory.CreateTile(6, Enums.Suit.Pin);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.HighChii, tile);
            Assert.AreEqual(6, openMeld.GetTiles()[0].GetValue());
            Assert.AreEqual(7, openMeld.GetTiles()[1].GetValue());
            Assert.AreEqual(8, openMeld.GetTiles()[2].GetValue());
            Enums.Suit suit = Enums.Suit.Pin;
            Assert.AreEqual(suit, openMeld.GetTiles()[0].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[1].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingClosedKan_CreatesListOfFourIdenticalTiles()
        {
            TileObject tile = TileFactory.CreateTile(6, Enums.Suit.Pin);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.ClosedKan, tile);
            Assert.AreEqual(6, openMeld.GetTiles()[0].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[1].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[2].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[3].GetValue());
            Enums.Suit suit = Enums.Suit.Pin;
            Assert.AreEqual(suit, openMeld.GetTiles()[0].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[1].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[2].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[3].GetSuit());
        }

        [TestMethod]
        public void CallingOpenKan1_CreatesListOfFourIdenticalTiles()
        {
            TileObject tile = TileFactory.CreateTile(6, Enums.Suit.Pin);
            OpenMeld openMeld = new OpenMeld(Enums.MeldType.OpenKan1, tile);
            Assert.AreEqual(6, openMeld.GetTiles()[0].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[1].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[2].GetValue());
            Assert.AreEqual(6, openMeld.GetTiles()[3].GetValue());
            Enums.Suit suit = Enums.Suit.Pin;
            Assert.AreEqual(suit, openMeld.GetTiles()[0].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[1].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[2].GetSuit());
            Assert.AreEqual(suit, openMeld.GetTiles()[3].GetSuit());
        }
    }
}
