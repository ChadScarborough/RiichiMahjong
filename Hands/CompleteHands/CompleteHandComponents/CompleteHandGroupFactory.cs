using RMU.Calls.CreateMeldBehaviours;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public static class CompleteHandGroupFactory
{
    public static ICompleteHandGroup CreateCompleteHandGroup(List<Tile> tiles, CompleteHandComponentType componentType)
    {
        return componentType switch
        {
            CLOSED_PON => new ClosedPon(tiles),
            CLOSED_CHII => new ClosedChii(tiles),
            _ => throw new ArgumentException("This error should be impossible"),
        };
    }

    public static ICompleteHandGroup CreateCompleteHandGroup(OpenMeld meld)
    {
        return meld.GetMeldType() switch
        {
            LOW_CHII or MID_CHII or HIGH_CHII => new OpenChii(meld),
            PON => new OpenPon(meld),
            OPEN_KAN_1 or OPEN_KAN_2 => new OpenKan(meld),
            CLOSED_KAN_MELD => new ClosedKan(meld),
            _ => throw new ArgumentException("This error should be impossible"),
        };
    }
}
