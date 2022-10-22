using RMU.Players;
using RMU.TestObjects.TestGames;
using RMU.TestObjects.TestHands;

namespace RMU.TestObjects.TestPlayers;

public sealed class TestPlayer : Player
{
    public TestPlayer(Wind wind, TestHand hand, OnePlayerTestGame game) : base(wind, hand, game)
    {
    }

    public override bool IsActivePlayer()
    {
        return true;
    }
}
