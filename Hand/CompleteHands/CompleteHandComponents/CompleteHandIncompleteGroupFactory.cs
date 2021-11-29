using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public static class CompleteHandIncompleteGroupFactory
    {
        public static ICompleteHandIncompleteGroup CreateCompleteHandIncompleteGroup(List<TileObject> tiles, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.CompleteHandComponentType.IncompleteSequenceClosedWait:
                    return new IncompleteSequenceClosedWait(tiles);
                case Enums.CompleteHandComponentType.IncompleteSequenceEdgeWait:
                    return new IncompleteSequenceEdgeWait(tiles);
                case Enums.CompleteHandComponentType.IncompleteSequenceOpenWait:
                    return new IncompleteSequenceOpenWait(tiles);
                default:
                    return null;
            }
        }
    }
}
