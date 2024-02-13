using RMU.Games;
using RMU.Hands;

namespace RMU.Players
{
    public abstract partial class Player
    {
        private int _playerID;
        private Wind _seatWind;
        private readonly Hand _hand;
        private Player _playerOnLeft;
        private Player _playerAcross;
        private Player _playerOnRight;
        private int _score;
        protected readonly AbstractGame _game;

        public int GetPlayerID()
        {
            return _playerID;
        }

        public void SetPlayerID(int id)
        {
            _playerID = id;
        }

        public AbstractGame GetGame()
        {
            return _game;
        }

        public virtual bool IsActivePlayer()
        {
            return _game.GetActivePlayer().Equals(this);
        }

        public Hand GetHand()
        {
            return _hand;
        }

        public Wind GetSeatWind()
        {
            return _seatWind;
        }

        public void SetSeatWind(Wind seatWind)
        {
            _seatWind = seatWind;
        }

        public void SetScore(int score)
        {
            _score = score;
        }

        public int GetScore()
        {
            return _score;
        }

        public void SetPlayerOnLeft(Player player)
        {
            CheckForDuplicatePlayers(player, GetPlayerAcross(), GetPlayerOnRight());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerOnLeft = player;
        }

        public void SetPlayerAcross(Player player)
        {
            CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerOnRight());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerAcross = player;
        }

        public void SetPlayerOnRight(Player player)
        {
            CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerAcross());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerOnRight = player;
        }

        public Player GetPlayerOnLeft()
        {
            return _playerOnLeft;
        }

        public Player GetPlayerAcross()
        {
            return _playerAcross;
        }

        public Player GetPlayerOnRight()
        {
            return _playerOnRight;
        }

        public override string ToString()
        {
            return $"Player {_playerID}";
        }
    }
}
