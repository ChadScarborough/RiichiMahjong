using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Player;
using RMU.Hand;
using RMU.Wall;
using RMU.Wall.DeadWall;
using RMU.Globals;

namespace RMUTests
{
    [TestClass]
    public class PlayerTest
    {
        private readonly ISeatWindState _seatWind = new EastWindState();
        private readonly AbstractWall _wall = new FourPlayerWallNoRedFives();

        [TestMethod]
        public void PlayerObject_ReturnsCorrectSeatWind()
        {
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
            Assert.AreEqual(Enums.Wind.East, player.GetSeatWind());
        }
        [TestMethod]
        public void PlayerObject_ReturnsCorrectSeatWind_AfterChangingWinds()
        {
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
            player.SetSeatWind(new NorthWindState());
            Assert.AreEqual(Enums.Wind.North, player.GetSeatWind());
            player.SetSeatWind(new WestWindState());
            Assert.AreEqual(Enums.Wind.West, player.GetSeatWind());
            player.SetSeatWind(new SouthWindState());
            Assert.AreEqual(Enums.Wind.South, player.GetSeatWind());
        }

        [TestMethod]
        public void GettingScore_ReturnsSetScore()
        {
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
            Assert.AreEqual(0, player.GetScore());
            player.SetScore(20000);
            Assert.AreEqual(20000, player.GetScore());
        }

        [TestMethod]
        public void GetPlayerOnLeft_ReturnsPlayerSetToLeft()
        {
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
            AbstractHand hand2 = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player2 = new StandardPlayer(new NorthWindState(), hand2);
            Assert.IsNull(player.GetPlayerOnLeft());
            player.SetPlayerOnLeft(player2);
            Assert.AreEqual(player2, player.GetPlayerOnLeft());
            Assert.AreEqual(Enums.Wind.North, player2.GetSeatWind());
        }

        [TestMethod]
        public void GetPlayerAcross_ReturnsPlayerSetAcross()
        {
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
            AbstractHand hand2 = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player2 = new StandardPlayer(new WestWindState(), hand2);
            Assert.IsNull(player.GetPlayerAcross());
            player.SetPlayerAcross(player2);
            Assert.AreEqual(player2, player.GetPlayerAcross());
            Assert.AreEqual(Enums.Wind.West, player2.GetSeatWind());
        }

        [TestMethod]
        public void GetPlayerOnRight_ReturnsPlayerSetToRight()
        {
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
            AbstractHand hand2 = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player2 = new StandardPlayer(new SouthWindState(), hand2);
            Assert.IsNull(player.GetPlayerOnRight());
            player.SetPlayerOnRight(player2);
            Assert.AreEqual(player2, player.GetPlayerOnRight());
            Assert.AreEqual(Enums.Wind.South, player2.GetSeatWind());
        }

        [TestMethod]
        public void SettingAPlayerInMultiplePositions_ThrowsAnException()
        {
            Exception ex = null;
            IDeadWall deadWall = new StandardDeadWall(_wall);
            AbstractHand hand = new StandardFourPlayerHand(_wall, deadWall);
            IPlayer player = new StandardPlayer(_seatWind, hand);
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
