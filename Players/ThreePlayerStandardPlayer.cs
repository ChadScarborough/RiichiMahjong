using RMU.Games;
using RMU.Hands;
using static RMU.Globals.Enums;

namespace RMU.Players
{
    public class ThreePlayerStandardPlayer : ThreePlayerAbstractPlayer
    {
        public ThreePlayerStandardPlayer(Wind seatWind, AbstractThreePlayerHand hand, AbstractGame game) : base(seatWind, hand, game)
        {
            
        }
    }
}