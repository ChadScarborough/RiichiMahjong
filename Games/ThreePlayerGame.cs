using RMU.Hands;
using RMU.Players;

namespace RMU.Games;

public abstract class ThreePlayerGame : AbstractGame
{
    protected void Init()
    {
        _players = new ThreePlayerAbstractPlayer[3];
        _players[0] = new ThreePlayerStandardPlayer(EAST, new StandardThreePlayerHand(_wallObject), this);
        _players[0].SetPlayerID(0);
        _players[1] = new ThreePlayerStandardPlayer(SOUTH, new StandardThreePlayerHand(_wallObject), this);
        _players[1].SetPlayerID(1);
        _players[2] = new ThreePlayerStandardPlayer(WEST, new StandardThreePlayerHand(_wallObject), this);
        _players[2].SetPlayerID(2);
        _wallObject.GenerateDeadWall();
        _wall = _wallObject.GetWall();
        _deadWall = _wallObject.GetDeadWall();
        ArrangePlayers();
        _firstGoAroundCounter = 3;
        Start();
    }

    private void ArrangePlayers()
    {
        _players[0].SetPlayerOnRight(_players[1]);
        _players[0].SetPlayerAcross(_players[2]);

        _players[1].SetPlayerOnLeft(_players[0]);
        _players[1].SetPlayerOnRight(_players[2]);

        _players[2].SetPlayerOnLeft(_players[1]);
        _players[2].SetPlayerAcross(_players[0]);
    }

    protected override Wind GetNewWind(Wind originalWind)
    {
        return originalWind switch
        {
            EAST => WEST,
            SOUTH => EAST,
            WEST => SOUTH,
            _ => throw new System.Exception("Invalid Wind")
        };
    }
}
