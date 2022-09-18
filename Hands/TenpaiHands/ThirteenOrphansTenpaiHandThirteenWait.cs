using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public sealed class ThirteenOrphansTenpaiHandThirteenWait : ThirteenOrphansTenpaiHand
{
    public ThirteenOrphansTenpaiHandThirteenWait(List<ICompleteHandComponent> components) : base(components)
    {
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return THIRTEEN_WAIT;
    }

    public override List<Tile> GetWaits()
    {
        return new List<Tile>
        {
            ONE_MAN, NINE_MAN,
            ONE_PIN, NINE_PIN,
            ONE_SOU, NINE_SOU,
            EAST_WIND, SOUTH_WIND,
            WEST_WIND, NORTH_WIND,
            GREEN_DRAGON,
            RED_DRAGON,
            WHITE_DRAGON
        };
    }
}