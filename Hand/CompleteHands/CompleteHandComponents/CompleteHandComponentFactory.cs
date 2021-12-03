using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public static class CompleteHandComponentFactory
    {
        public static ICompleteHandComponent CreateCompleteHandComponent(List<TileObject> tiles, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.PAIR:
                    return new Pair(tiles);
                case Enums.CLOSED_CHII:
                case Enums.CLOSED_PON:
                    return CompleteHandGroupFactory.CreateCompleteHandGroup(tiles, componentType);
                case Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT:
                case Enums.INCOMPLETE_SEQUENCE_EDGE_WAIT:
                case Enums.INCOMPLETE_SEQUENCE_OPEN_WAIT:
                    return CompleteHandIncompleteGroupFactory.CreateCompleteHandIncompleteGroup(tiles, componentType);
                default:
                    return null;
            }
        }

        public static ICompleteHandComponent CreateCompleteHandComponent(TileObject tile, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.DRAW_TILE:
                    return new DrawTile(tile);
                case Enums.ISOLATED_TILE:
                    return new IsolatedTile(tile);
                default:
                    return null;
            }
        }

        public static ICompleteHandComponent CreateCompleteHandComponent(OpenMeld openMeld)
        {
            return CompleteHandGroupFactory.CreateCompleteHandGroup(openMeld);
        }
    }
}
