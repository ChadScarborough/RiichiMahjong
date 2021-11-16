using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand;

namespace RMU.Player
{
    public class StandardPlayer : IPlayer
    {
        private ISeatWindState _seatWind;
        private IHand _hand;
        private IPlayer _playerOnLeft;
        private IPlayer _playerAcross;
        private IPlayer _playerOnRight;
        private int _score;

        public StandardPlayer(ISeatWindState _seatWind, IHand _hand)
        {
            this._seatWind = _seatWind;
            this._hand = _hand;
        }

        public PlayerEnums.SeatWinds GetSeatWind()
        {
            return _seatWind.GetSeatWind();
        }

        public void SetSeatWind(ISeatWindState seatWindState)
        {
            this._seatWind = seatWindState;
        }

        public void SetScore(int _score)
        {
            this._score = _score;
        }

        public int GetScore()
        {
            return this._score;
        }

        public void SetPlayerOnLeft(IPlayer player)
        {
            if(player != this)
            {
                _playerOnLeft = player;
                return;
            }
            throw new ArgumentException("Attempted to set this player to sit on their own left");
        }

        public void SetPlayerAcross(IPlayer player)
        {
            if(player != this)
            {
                _playerAcross = player;
                return;
            }
            throw new ArgumentException("Attempted to set this player to sit across from themself");
        }

        public void SetPlayerOnRight(IPlayer player)
        {
            if(player != this)
            {
                _playerOnRight = player;
                return;
            }
            throw new ArgumentException("Attempted to set this player to sit on their own right");
        }

        public IPlayer GetPlayerOnLeft()
        {
            return _playerOnLeft;
        }

        public IPlayer GetPlayerAcross()
        {
            return _playerAcross;
        }

        public IPlayer GetPlayerOnRight()
        {
            return _playerOnRight;
        }
    }
}
