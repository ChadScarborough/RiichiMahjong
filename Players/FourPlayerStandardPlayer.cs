using RMU.Games;
using RMU.Hands;

namespace RMU.Players;

public sealed class FourPlayerStandardPlayer : FourPlayerAbstractPlayer
{
    public FourPlayerStandardPlayer(Wind seatWind, AbstractFourPlayerHand hand, AbstractGame game) : base(seatWind, hand, game)
    {

    }
}