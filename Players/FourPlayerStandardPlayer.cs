using RMU.Games;
using RMU.Hands;
using static RMU.Globals.Enums;

namespace RMU.Players
{
    public class FourPlayerStandardPlayer : FourPlayerAbstractPlayer
    {
        public FourPlayerStandardPlayer(Wind seatWind, AbstractFourPlayerHand hand, AbstractGame game) : base(seatWind, hand, game)
        {
            
        }
    }
}