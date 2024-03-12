using RMU.Games;
using RMU.Players;
using RMU.TestObjects.TestHands;
using RMU.TestObjects.TestPlayers;
using RMU.Walls;

namespace RMU.TestObjects.TestGames;

public sealed class OnePlayerTestGame : AbstractGame
{
    public OnePlayerTestGame(TestHand hand)
    {
        _players = new Player[1];
        _players[0] = new TestPlayer(EAST, hand, this);
        _players[0].SetPlayerID(1);
        _wallObject = new FourPlayerWallObjectNoRedFives();
        _wall = _wallObject.GetWall();
        _deadWall = _wallObject.GetDeadWall();
    }

    protected override Wind GetNewWind(Wind originalWind)
    {
        return EAST;
    }

    public override void NextPlayer()
    {

    }
}
