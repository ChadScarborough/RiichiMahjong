using static RMU.Globals.Enums;
using RMU.Games;
using RMU.Hands;

namespace RMU.Players
{
    public class FourPlayerTestPlayer : FourPlayerAbstractPlayer
    {
        public FourPlayerTestPlayer(AbstractFourPlayerHand hand) : base(EAST, hand, new FourPlayerNoRedFivesGame())
        {
        }
    }
}