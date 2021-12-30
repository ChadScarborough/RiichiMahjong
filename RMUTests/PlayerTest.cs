using System;
using System.Collections.Generic;
using System.Text;
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
        private ISeatWindState _seatWind = new EastWindState();
        private IWall _wall = new StandardWall();

        [TestMethod]
        public void PlayerObject_ReturnsCorrectSeatWind()
        {
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
            Assert.AreEqual(Enums.Wind.East, player.GetSeatWind());
        }
        [TestMethod]
        public void PlayerObject_ReturnsCorrectSeatWind_AfterChangingWinds()
        {
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
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
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
            Assert.AreEqual(0, player.GetScore());
            player.SetScore(20000);
            Assert.AreEqual(20000, player.GetScore());
        }

        [TestMethod]
        public void GetPlayerOnLeft_ReturnsPlayerSetToLeft()
        {
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
            IHand _hand2 = new StandardHand(_wall, _deadWall);
            IPlayer player2 = new StandardPlayer(new NorthWindState(), _hand2);
            Assert.IsNull(player.GetPlayerOnLeft());
            player.SetPlayerOnLeft(player2);
            Assert.AreEqual(player2, player.GetPlayerOnLeft());
            Assert.AreEqual(Enums.Wind.North, player2.GetSeatWind());
        }

        [TestMethod]
        public void GetPlayerAcross_ReturnsPlayerSetAcross()
        {
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
            IHand _hand2 = new StandardHand(_wall, _deadWall);
            IPlayer player2 = new StandardPlayer(new WestWindState(), _hand2);
            Assert.IsNull(player.GetPlayerAcross());
            player.SetPlayerAcross(player2);
            Assert.AreEqual(player2, player.GetPlayerAcross());
            Assert.AreEqual(Enums.Wind.West, player2.GetSeatWind());
        }

        [TestMethod]
        public void GetPlayerOnRight_ReturnsPlayerSetToRight()
        {
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
            IHand _hand2 = new StandardHand(_wall, _deadWall);
            IPlayer player2 = new StandardPlayer(new SouthWindState(), _hand2);
            Assert.IsNull(player.GetPlayerOnRight());
            player.SetPlayerOnRight(player2);
            Assert.AreEqual(player2, player.GetPlayerOnRight());
            Assert.AreEqual(Enums.Wind.South, player2.GetSeatWind());
        }

        [TestMethod]
        public void SettingAPlayerInMultiplePositions_ThrowsAnExcpetion()
        {
            Exception ex = null;
            IDeadWall _deadWall = new StandardDeadWall(_wall);
            IHand _hand = new StandardHand(_wall, _deadWall);
            IPlayer player = new StandardPlayer(_seatWind, _hand);
            Assert.IsNull(ex);
            try
            {
                player.SetPlayerOnLeft(player);
            }
            catch(Exception ExpectedException)
            {
                ex = ExpectedException;
            }
            Assert.IsNotNull(ex);
        }
    }
}
