using RMU.Games;
using RMU.Hands;
using RMU.Players;

namespace RMU.TestObjects.TestPlayers;

public sealed class FourPlayerTestPlayer : FourPlayerAbstractPlayer
{
    public FourPlayerTestPlayer(Hand hand) : base(EAST, hand, new FourPlayerNoRedFivesGame())
    {
    }
}