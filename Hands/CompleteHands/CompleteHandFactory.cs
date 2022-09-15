using System;
using System.Collections.Generic;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using RMU.Players;
using static RMU.Globals.Functions;

namespace RMU.Hands.CompleteHands;

public static class CompleteHandFactory
{
    public static ICompleteHand CreateCompleteHand(ITenpaiHand hand, Tile extraTile, Player player)
    {
        if (ContainsTile(hand.GetWaits(), extraTile) == false)
        {
            throw new Exception("Cannot create complete hand because the extra tile is not one of the hand's waits");
        }

        if (hand.GetType().IsSubclassOf(typeof(StandardTenpaiHand)))
        {
            return new StandardCompleteHand(hand, extraTile, player);
        }

        if (hand.GetType() == typeof(SevenPairsTenpaiHand))
        {
            return new SevenPairsCompleteHand(hand, extraTile, player);
        }

        if (hand.GetType().IsSubclassOf(typeof(ThirteenOrphansTenpaiHand)))
        {
            return new ThirteenOrphansCompleteHand(hand, extraTile, player);
        }

        throw new Exception("I don't know how, but something went wrong");
    }

    private static bool ContainsTile(List<Tile> tileList, Tile tile)
    {
        foreach (Tile t in tileList)
        {
            if (AreTilesEquivalent(t, tile))
            {
                return true;
            }
        }

        return false;
    }
}