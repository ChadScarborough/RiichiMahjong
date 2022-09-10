using RMU.Games;
using static RMU.Globals.Enums;
using RMU.Hands;
using RMU.Hands.TestHands;

namespace RMU.Players
{
    public class TestPlayer : Player
    {
        public TestPlayer(Wind wind, TestHand hand, OnePlayerTestGame game) : base(wind, hand, game)
        {
        }

        public override bool IsActivePlayer()
        {
            return true;
        }
    }
}
