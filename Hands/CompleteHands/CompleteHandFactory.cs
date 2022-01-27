using System;
using System.Collections.Generic;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using static RMU.Globals.Functions;

namespace RMU.Hands.CompleteHands;

public static class CompleteHandFactory
{
    public static ICompleteHand CreateCompleteHand(ITenpaiHand hand, TileObject extraTile)
    {
        if (ContainsTile(hand.GetWaits(), extraTile) == false)
        {
            return null;
        }

        if (hand.GetType().IsSubclassOf(typeof(StandardTenpaiHand)))
        {
            return new StandardCompleteHand(hand, extraTile);
        }

        if (hand.GetType().IsSubclassOf(typeof(SevenPairsTenpaiHand)))
        {
            return new SevenPairsCompleteHand(hand, extraTile);
        }

        if (hand.GetType().IsSubclassOf(typeof(ThirteenOrphansTenpaiHand)))
        {
            return new ThirteenOrphansCompleteHand(hand, extraTile);
        }

        throw new Exception("I don't know how, but something went wrong");
    }

    private static bool ContainsTile(List<TileObject> tileList, TileObject tile)
    {
        foreach (TileObject t in tileList)
        {
            if (AreTilesEquivalent(t, tile))
            {
                return true;
            }
        }

        return false;
    }
}