using RMU.Hand;
using RMU.Tiles;
using RMU.Hand.Calls;

namespace RMU.Player
{
    public class FourPlayerStandardPlayer : FourPlayerAbstractPlayer
    {
        public FourPlayerStandardPlayer(ISeatWindState seatWind, AbstractFourPlayerHand hand) : base(seatWind, hand)
        {
            
        }
    }
}