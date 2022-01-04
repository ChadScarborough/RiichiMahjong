using System;
using RMU.Hand;
using RMU.Globals;
using RMU.Tiles;
using RMU.Hand.Calls;

namespace RMU.Player
{
    public abstract class AbstractPlayer
    {
        private ISeatWindState _seatWind;
        private readonly AbstractHand _hand;
        private AbstractPlayer _playerOnLeft;
        private AbstractPlayer _playerAcross;
        private AbstractPlayer _playerOnRight;
        private int _score;

        protected AbstractPlayer(ISeatWindState seatWind, AbstractHand hand)
        {
            _seatWind = seatWind;
            _hand = hand;
        }

        public Enums.Wind GetSeatWind()
        {
            return _seatWind.GetSeatWind();
        }

        public void SetSeatWind(ISeatWindState seatWindState)
        {
            this._seatWind = seatWindState;
        }

        public void SetScore(int score)
        {
            this._score = score;
        }

        public int GetScore()
        {
            return this._score;
        }

        public void SetPlayerOnLeft(AbstractPlayer player)
        {
            CheckForDuplicatePlayers(player, GetPlayerAcross(), GetPlayerOnRight());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerOnLeft = player;
        }
        
        public void SetPlayerAcross(AbstractPlayer player)
        {
            CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerOnRight());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerAcross = player;
        }

        public void SetPlayerOnRight(AbstractPlayer player)
        {
            CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerAcross());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerOnRight = player;
        }

        public AbstractPlayer GetPlayerOnLeft()
        {
            return _playerOnLeft;
        }

        public AbstractPlayer GetPlayerAcross()
        {
            return _playerAcross;
        }

        public AbstractPlayer GetPlayerOnRight()
        {
            return _playerOnRight;
        }

        private void CheckForDuplicatePlayers(AbstractPlayer player, AbstractPlayer existingPlayer1, AbstractPlayer existingPlayer2)
        {
            if (player == existingPlayer1 || player == existingPlayer2)
            {
                throw new ArgumentException("Attempted to set the same player in two locations");
            }
        }

        private void CheckThatThisPlayerIsNotDuplicated(AbstractPlayer player)
        {
            if(player == this)
            {
                throw new ArgumentException("Attempted to set this player to multiple locations");
            }
        }

        public void CallPon(TileObject calledTile)
        {
            ICallCommand callPon = new CallPonCommand(_hand, calledTile);
            callPon.Execute();
        }

        public void CallClosedKan(TileObject calledTile)
        {
            ICallCommand callClosedKan = new CallClosedKanCommand(_hand, calledTile);
            callClosedKan.Execute();
        }

        public void CallOpenKan1(TileObject calledTile)
        {
            ICallCommand callOpenKan1 = new CallOpenKan1Command(_hand, calledTile);
            callOpenKan1.Execute();
        }

        public void CallOpenKan2(TileObject calledTile)
        {
            ICallCommand callOpenKan2 = new CallOpenKan2Command(_hand, calledTile);
            callOpenKan2.Execute();
        }
    }
}
