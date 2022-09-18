using RMU.Games;
using RMU.Hands;

namespace RMU.Players;

public sealed class ThreePlayerStandardPlayer : ThreePlayerAbstractPlayer
{
    public ThreePlayerStandardPlayer(Wind seatWind, AbstractThreePlayerHand hand, AbstractGame game) : base(seatWind, hand, game)
    {

    }
}