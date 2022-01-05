using System;
using System.Collections.Generic;
using RMU.Calls.CreateMeldBehaviours;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public static class CompleteHandComponentFactory
    {
        public static ICompleteHandComponent CreateCompleteHandComponent(List<TileObject> tiles, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.PAIR_COMPONENT:
                    return new PairComponent(tiles);
                case Enums.CLOSED_CHII:
                case Enums.CLOSED_PON:
                    return CompleteHandGroupFactory.CreateCompleteHandGroup(tiles, componentType);
                case Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT:
                case Enums.INCOMPLETE_SEQUENCE_EDGE_WAIT:
                case Enums.INCOMPLETE_SEQUENCE_OPEN_WAIT:
                    return CompleteHandIncompleteGroupFactory.CreateCompleteHandIncompleteGroup(tiles, componentType);
                default:
                    throw new ArgumentException("Incorrect input data type");
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
                    throw new ArgumentException("Incorrect input data type");
            }
        }

        public static ICompleteHandComponent CreateCompleteHandComponent(OpenMeld openMeld)
        {
            return CompleteHandGroupFactory.CreateCompleteHandGroup(openMeld);
        }
    }
}
