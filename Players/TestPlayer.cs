using RMU.Games;
using static RMU.Globals.Enums;
using RMU.Hands;
using RMU.Hands.TestHands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMU.Players
{
    public class TestPlayer : Player
    {
        public TestPlayer(Wind wind, TestHand hand, OnePlayerTestGame game) : base(wind, hand, game)
        {
        }
    }
}
