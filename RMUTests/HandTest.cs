using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;
using RMU.Hand;
using RMU.Globals;

namespace RMUTests
{
    [TestClass]
    public class HandTest
    {
        private IWall wall = new StandardWall();
        private IWall testWall = new TestWall();
        private IDeadWall deadWall;
        private IHand hand;

        [TestMethod]
        public void DrawingTileFromWall_RemovesTileFromWall_AndAddsItToHand()
        {
            deadWall = new StandardDeadWall(wall);
            hand = new StandardHand(wall, deadWall);

            Assert.IsNull(hand.GetDrawTile());

            hand.DrawTileFromWall();
            Assert.AreEqual(121, wall.GetSize());
            Assert.IsNotNull(hand.GetDrawTile());
        }

        [TestMethod]
        public void DrawingTileFromDeadWall_RemovesTileFromDeadWall_AndAddsItToHand()
        {
            deadWall = new StandardDeadWall(wall);
            hand = new StandardHand(wall, deadWall);

            Assert.IsNull(hand.GetDrawTile());
            Assert.AreEqual(4, deadWall.GetDrawableTiles().Count);

            hand.DrawTileFromDeadWall();

            Assert.IsNotNull(hand.GetDrawTile());
            Assert.AreEqual(3, deadWall.GetDrawableTiles().Count);
        }

        [TestMethod]
        public void CallingPon_CreatesNewOpenMeldObject_AndRemovesTilesFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);

            DrawTilesFromTestWall(hand);
            Assert.AreEqual(7, hand.GetClosedTiles().Count);

            hand.CallPon(TileFactory.CreateTile(1, Enums.Suit.Man));

            Assert.AreEqual(5, hand.GetClosedTiles().Count);
            Assert.IsNotNull(hand.GetOpenMelds()[0]);
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[0].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[0].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[1].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[1].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[2].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[2].GetSuit());
        }

        private void DrawTilesFromTestWall(IHand hand)
        {
            for (int i = 0; i < 8; i++)
            {
                hand.DrawTileFromWall();
            }
        }

        [TestMethod]
        public void CallingLowChii_CreatesNewOpenMeldObject_AndRemovesTilesFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);
            DrawTilesFromTestWall(hand);
            Assert.AreEqual(7, hand.GetClosedTiles().Count);
            hand.CallLowChii(TileFactory.CreateTile(3, Enums.Suit.Sou));
            Assert.AreEqual(5, hand.GetClosedTiles().Count);
            Assert.IsNotNull(hand.GetOpenMelds()[0]);
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[0].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[0].GetSuit());
            Assert.AreEqual(2, hand.GetOpenMelds()[0].GetTiles()[1].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[1].GetSuit());
            Assert.AreEqual(3, hand.GetOpenMelds()[0].GetTiles()[2].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingMidChii_CreatesNewOpenMeldObject_AndRemovesTilesFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);
            DrawTilesFromTestWall(hand);
            Assert.AreEqual(7, hand.GetClosedTiles().Count);
            hand.CallMidChii(TileFactory.CreateTile(3, Enums.Suit.Sou));
            Assert.AreEqual(5, hand.GetClosedTiles().Count);
            Assert.IsNotNull(hand.GetOpenMelds()[0]);
            Assert.AreEqual(2, hand.GetOpenMelds()[0].GetTiles()[0].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[0].GetSuit());
            Assert.AreEqual(3, hand.GetOpenMelds()[0].GetTiles()[1].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[1].GetSuit());
            Assert.AreEqual(4, hand.GetOpenMelds()[0].GetTiles()[2].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingHighChii_CreatesNewOpenMeldObject_AndRemovesTilesFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);
            DrawTilesFromTestWall(hand);
            hand.AddDrawTileToHand();
            Assert.AreEqual(8, hand.GetClosedTiles().Count);
            hand.CallHighChii(TileFactory.CreateTile(3, Enums.Suit.Sou));
            Assert.AreEqual(6, hand.GetClosedTiles().Count);
            Assert.IsNotNull(hand.GetOpenMelds()[0]);
            Assert.AreEqual(3, hand.GetOpenMelds()[0].GetTiles()[0].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[0].GetSuit());
            Assert.AreEqual(4, hand.GetOpenMelds()[0].GetTiles()[1].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[1].GetSuit());
            Assert.AreEqual(5, hand.GetOpenMelds()[0].GetTiles()[2].GetValue());
            Assert.AreEqual(Enums.Suit.Sou, hand.GetOpenMelds()[0].GetTiles()[2].GetSuit());
        }

        [TestMethod]
        public void CallingClosedKan_CreatesNewOpenMeldObject_AndRemovesTilesFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);

            DrawTilesFromTestWall(hand);
            Assert.AreEqual(7, hand.GetClosedTiles().Count);

            hand.CallClosedKan(TileFactory.CreateTile(1, RMU.Globals.Enums.Suit.Man));

            Assert.AreEqual(4, hand.GetClosedTiles().Count);
            Assert.IsNotNull(hand.GetOpenMelds()[0]);
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[0].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[0].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[1].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[1].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[2].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[2].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[3].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[3].GetSuit());
        }

        [TestMethod]
        public void CallingOpenKan1_CreatesNewOpenMeldObject_AndRemovesTilesFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);

            DrawTilesFromTestWall(hand);
            Assert.AreEqual(7, hand.GetClosedTiles().Count);

            hand.CallOpenKan1(TileFactory.CreateTile(1, Enums.Suit.Man));

            Assert.AreEqual(4, hand.GetClosedTiles().Count);
            Assert.IsNotNull(hand.GetOpenMelds()[0]);
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[0].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[0].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[1].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[1].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[2].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[2].GetSuit());
            Assert.AreEqual(1, hand.GetOpenMelds()[0].GetTiles()[3].GetValue());
            Assert.AreEqual(Enums.Suit.Man, hand.GetOpenMelds()[0].GetTiles()[3].GetSuit());
        }

        [TestMethod]
        public void CallingOpenKan2_CreatesNewOpenMeldObject_AndRemovesTileFromHand()
        {
            deadWall = new NullDeadWall();
            hand = new StandardHand(testWall, deadWall);

            DrawTilesFromTestWall(hand);
            Assert.AreEqual(7, hand.GetClosedTiles().Count);

            hand.CallPon(TileFactory.CreateTile(1, Enums.Suit.Man));
            Assert.AreEqual(1, hand.GetOpenMelds().Count);

            Assert.AreEqual(Enums.MeldType.Pon, hand.GetOpenMelds()[0].GetMeldType());

            hand.CallOpenKan2(TileFactory.CreateTile(1, Enums.Suit.Man));
            Assert.AreEqual(1, hand.GetOpenMelds().Count);
            Assert.AreEqual(4, hand.GetOpenMelds()[0].GetTiles().Count);
            Assert.AreEqual(Enums.MeldType.OpenKan2, hand.GetOpenMelds()[0].GetMeldType());
        }
    }
}
