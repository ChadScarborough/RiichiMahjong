using System.Collections.Generic;
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
                case Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT:
                    return new IncompleteSequenceClosedWait(tiles);
                case Enums.INCOMPLETE_SEQUENCE_EDGE_WAIT:
                    return new IncompleteSequenceEdgeWait(tiles);
                case Enums.INCOMPLETE_SEQUENCE_OPEN_WAIT:
                    return new IncompleteSequenceOpenWait(tiles);
                default:
                    return null;
            }
        }
    }
}
