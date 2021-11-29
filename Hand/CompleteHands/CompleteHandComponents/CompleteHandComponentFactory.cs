using System;
using System.Collections.Generic;
using System.Text;
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
                case Enums.CompleteHandComponentType.Pair:
                    return new Pair(tiles);
                case Enums.CompleteHandComponentType.ClosedChii:
                case Enums.CompleteHandComponentType.ClosedPon:
                    return CompleteHandGroupFactory.CreateCompleteHandGroup(tiles, componentType);
                case Enums.CompleteHandComponentType.IncompleteSequenceClosedWait:
                case Enums.CompleteHandComponentType.IncompleteSequenceEdgeWait:
                case Enums.CompleteHandComponentType.IncompleteSequenceOpenWait:
                    return CompleteHandIncompleteGroupFactory.CreateCompleteHandIncompleteGroup(tiles, componentType);
                default:
                    return null;
            }
        }

        public static ICompleteHandComponent CreateCompleteHandComponent(TileObject tile, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.CompleteHandComponentType.DrawTile:
                    return new DrawTile(tile);
                case Enums.CompleteHandComponentType.IsolatedTile:
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
