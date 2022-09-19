using RMU.Games;
using RMU.Hands.TestHands;

namespace RMU.Players;

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
