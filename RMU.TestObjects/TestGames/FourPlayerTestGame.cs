using RMU.Games;
using RMU.Hands;
using RMU.Players;
using RMU.TestObjects.TestPlayers;
using RMU.Walls;

namespace RMU.TestObjects.TestGames;

public sealed class FourPlayerTestGame : FourPlayerGame
{
    public FourPlayerTestGame(Hand hand1, Hand hand2, Hand hand3, Hand hand4)
    {
        _players[0] = new FourPlayerTestPlayer(hand1);
        _players[1] = new FourPlayerTestPlayer(hand2);
        _players[2] = new FourPlayerTestPlayer(hand3);
        _players[3] = new FourPlayerTestPlayer(hand4);
        _wallObject = new FourPlayerWallObjectNoRedFives();
        Init();
    }
}