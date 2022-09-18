using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public static class CompleteHandIncompleteGroupFactory
{
    public static ICompleteHandIncompleteGroup CreateCompleteHandIncompleteGroup
        (List<Tile> tiles, CompleteHandComponentType componentType)
    {
        return componentType switch
        {
            INCOMPLETE_SEQUENCE_CLOSED_WAIT => new IncompleteSequenceClosedWait(tiles),
            INCOMPLETE_SEQUENCE_EDGE_WAIT => new IncompleteSequenceEdgeWait(tiles),
            INCOMPLETE_SEQUENCE_OPEN_WAIT => new IncompleteSequenceOpenWait(tiles),
            _ => throw new ArgumentException("This error should be impossible"),
        };
    }
}
