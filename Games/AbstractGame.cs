using RMU.Players;
using RMU.Wall;
using RMU.Wall.DeadWall;
using static RMU.Globals.Enums;

namespace RMU.Games
{
    public class AbstractGame
    {
        protected Player[] _players;
        protected WallObject _wallObject;
        protected Wall.Wall _wall;
        protected IDeadWall _deadWall;

        private Player _activePlayer;

        protected void Start()
        {
            _activePlayer = GetEastPlayer();
            _activePlayer.GetHand().DrawTileFromWall();
        }

        public void NextPlayer()
        {
            if (_activePlayer.GetPlayerOnRight() != null)
                SetActivePlayer(_activePlayer.GetPlayerOnRight());
            else
                SetActivePlayer(_activePlayer.GetPlayerAcross());
        }

        private void SetActivePlayer(Player player)
        {
            _activePlayer = player;
            _activePlayer.DrawTile();
        }

        public Player GetActivePlayer()
        {
            return _activePlayer;
        }

        public Player[] GetPlayers()
        {
            return _players;
        }

        public Player GetEastPlayer()
        {
            return GetPlayerByWind(EAST);
        }

        public Player GetSouthPlayer()
        {
            return GetPlayerByWind(SOUTH);
        }

        public Player GetWestPlayer()
        {
            return GetPlayerByWind(WEST);
        }

        public Player GetNorthPlayer()
        {
            return GetPlayerByWind(NORTH);
        }

        public Wall.Wall GetWall()
        {
            return _wall;
        }

        public IDeadWall GetDeadWall()
        {
            return _deadWall;
        }

        public WallObject GetWallObject()
        {
            return _wallObject;
        }

        private Player GetPlayerByWind(Wind wind)
        {
            foreach (Player p in _players)
            {
                if (p.GetSeatWind() == wind)
                    return p;
            }
            return null;
        }
    }
}
