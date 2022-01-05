using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public static class CompleteHandIncompleteGroupFactory
    {
        public static ICompleteHandIncompleteGroup CreateCompleteHandIncompleteGroup
            (List<TileObject> tiles, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT:
                    return new IncompleteSequenceClosedWait(tiles);
                case Enums.INCOMPLETE_SEQUENCE_EDGE_WAIT:
                    return new IncompleteSequenceEdgeWait(tiles);
                case Enums.INCOMPLETE_SEQUENCE_OPEN_WAIT:
                    return new IncompleteSequenceOpenWait(tiles);
                default:
                    throw new ArgumentException("This error should be impossible");
            }
        }
    }
}
