using RMU.Games;
using RMU.Hands;
using RMU.Players;
using RMU.TestObjects.TestGames;

namespace RMU.TestObjects.TestPlayers;

public sealed class FourPlayerTestPlayer : FourPlayerAbstractPlayer
{
    public FourPlayerTestPlayer(Wind wind, Hand hand, FourPlayerTestGame game) : base(wind, hand, game)
    {
    }
}