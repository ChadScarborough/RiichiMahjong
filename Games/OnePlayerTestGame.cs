using RMU.Globals;
using RMU.Players;
using RMU.Hands.TestHands;
using RMU.Wall;

namespace RMU.Games
{
    public class OnePlayerTestGame : AbstractGame
    {
        public OnePlayerTestGame(TestHand hand)
        {
            _players = new Player[1];
            _players[0] = new TestPlayer(Enums.Wind.East, hand, this);
            _wallObject = new FourPlayerWallObjectNoRedFives();
            _wall = _wallObject.GetWall();
            _deadWall = _wallObject.GetDeadWall();
        }

        protected override Enums.Wind GetNewWind(Enums.Wind originalWind)
        {
            return Enums.Wind.East;
        }
    }
}
