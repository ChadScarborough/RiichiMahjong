using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TenpaiHands;

public class ThirteenOrphansTenpaiHandThirteenWait : ThirteenOrphansTenpaiHand
{
    public ThirteenOrphansTenpaiHandThirteenWait(List<ICompleteHandComponent> components) : base(components)
    {
    }

    public override Enums.CompleteHandWaitType GetWaitType()
    {
        return Enums.THIRTEEN_WAIT;
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