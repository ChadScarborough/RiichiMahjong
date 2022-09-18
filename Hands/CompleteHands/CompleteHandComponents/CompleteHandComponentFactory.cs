using RMU.Calls.CreateMeldBehaviours;
using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public static class CompleteHandComponentFactory
{
    public static ICompleteHandComponent CreateCompleteHandComponent(List<Tile> tiles, CompleteHandComponentType componentType)
    {
        return componentType switch
        {
            PAIR_COMPONENT => new PairComponent(tiles),
            CLOSED_CHII or CLOSED_PON => CompleteHandGroupFactory.CreateCompleteHandGroup(tiles, componentType),
            INCOMPLETE_SEQUENCE_CLOSED_WAIT or INCOMPLETE_SEQUENCE_EDGE_WAIT or INCOMPLETE_SEQUENCE_OPEN_WAIT => CompleteHandIncompleteGroupFactory.CreateCompleteHandIncompleteGroup(tiles, componentType),
            _ => throw new ArgumentException("Incorrect input data type"),
        };
    }

    public static ICompleteHandComponent CreateCompleteHandComponent(Tile tile, Enums.CompleteHandComponentType componentType)
    {
        return componentType switch
        {
            DRAW_TILE => new DrawTile(tile),
            ISOLATED_TILE => new IsolatedTile(tile),
            _ => throw new ArgumentException("Incorrect input data type"),
        };
    }

    public static ICompleteHandComponent CreateCompleteHandComponent(OpenMeld openMeld)
    {
        return CompleteHandGroupFactory.CreateCompleteHandGroup(openMeld);
    }
}
