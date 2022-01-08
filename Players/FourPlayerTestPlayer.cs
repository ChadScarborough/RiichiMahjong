using static RMU.Globals.Enums;
using RMU.Hands;

namespace RMU.Players
{
    public class FourPlayerTestPlayer : FourPlayerAbstractPlayer
    {
        public FourPlayerTestPlayer(AbstractFourPlayerHand hand) : base(EAST, hand)
        {
        }
    }
}