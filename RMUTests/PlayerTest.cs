using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Players;
using RMU.Wall;
using RMU.Wall.DeadWall;
using static RMU.Globals.Enums;

namespace RMUTests
{
    [TestClass]
    public class PlayerTest
    {
        private readonly Wind _seatWind = EAST;
        private readonly WallObject _wallObject = new FourPlayerWallObjectNoRedFives();

        [TestMethod]
        public void PlayerObject_ReturnsCorrectSeatWind()
        {
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            Assert.AreEqual(Wind.East, player.GetSeatWind());
        }
        [TestMethod]
        public void PlayerObject_ReturnsCorrectSeatWind_AfterChangingWinds()
        {
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            player.SetSeatWind(NORTH);
            Assert.AreEqual(Wind.North, player.GetSeatWind());
            player.SetSeatWind(WEST);
            Assert.AreEqual(Wind.West, player.GetSeatWind());
            player.SetSeatWind(SOUTH);
            Assert.AreEqual(Wind.South, player.GetSeatWind());
        }

        [TestMethod]
        public void GettingScore_ReturnsSetScore()
        {
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            Assert.AreEqual(0, player.GetScore());
            player.SetScore(20000);
            Assert.AreEqual(20000, player.GetScore());
        }

        [TestMethod]
        public void GetPlayerOnLeft_ReturnsPlayerSetToLeft()
        {
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            AbstractFourPlayerHand hand2 = new StandardFourPlayerHand(_wallObject);
            Player player2 = new FourPlayerStandardPlayer(NORTH, hand2);
            Assert.IsNull(player.GetPlayerOnLeft());
            player.SetPlayerOnLeft(player2);
            Assert.AreEqual(player2, player.GetPlayerOnLeft());
            Assert.AreEqual(Wind.North, player2.GetSeatWind());
        }

        [TestMethod]
        public void GetPlayerAcross_ReturnsPlayerSetAcross()
        {
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            AbstractFourPlayerHand hand2 = new StandardFourPlayerHand(_wallObject);
            Player player2 = new FourPlayerStandardPlayer(WEST, hand2);
            Assert.IsNull(player.GetPlayerAcross());
            player.SetPlayerAcross(player2);
            Assert.AreEqual(player2, player.GetPlayerAcross());
            Assert.AreEqual(Wind.West, player2.GetSeatWind());
        }

        [TestMethod]
        public void GetPlayerOnRight_ReturnsPlayerSetToRight()
        {
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            AbstractFourPlayerHand hand2 = new StandardFourPlayerHand(_wallObject);
            Player player2 = new FourPlayerStandardPlayer(SOUTH, hand2);
            Assert.IsNull(player.GetPlayerOnRight());
            player.SetPlayerOnRight(player2);
            Assert.AreEqual(player2, player.GetPlayerOnRight());
            Assert.AreEqual(Wind.South, player2.GetSeatWind());
        }

        [TestMethod]
        public void SettingAPlayerInMultiplePositions_ThrowsAnException()
        {
            Exception ex = null;
            AbstractFourPlayerHand hand = new StandardFourPlayerHand(_wallObject);
            Player player = new FourPlayerStandardPlayer(_seatWind, hand);
            Assert.IsNull(ex);
            try
            {
                player.SetPlayerOnLeft(player);
            }
            catch(Exception expectedException)
            {
                ex = expectedException;
            }
            Assert.IsNotNull(ex);
        }
    }
}
