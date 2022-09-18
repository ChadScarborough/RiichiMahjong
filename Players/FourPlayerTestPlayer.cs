using static RMU.Globals.Enums;
using RMU.Games;
using RMU.Hands;

namespace RMU.Players;

public sealed class FourPlayerTestPlayer : FourPlayerAbstractPlayer
{
    public FourPlayerTestPlayer(Hand hand) : base(EAST, hand, new FourPlayerNoRedFivesGame())
    {
    }
}