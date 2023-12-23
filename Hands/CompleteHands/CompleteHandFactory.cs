using RMU.Hands.TenpaiHands;
using RMU.Players;
using RMU.Tiles;
using System;

namespace RMU.Hands.CompleteHands;

public static class CompleteHandFactory
{
    public static ICompleteHand CreateCompleteHand(ITenpaiHand hand, Tile extraTile, Player player)
    {
        return ContainsTile(hand.GetWaits(), extraTile) == false
            ? throw new Exception("Cannot create complete hand because the extra tile is not one of the hand's waits")
            : hand is StandardTenpaiHand
            ? new StandardCompleteHand(hand, extraTile, player)
            : hand is SevenPairsTenpaiHand
            ? new SevenPairsCompleteHand(hand, extraTile, player)
            : hand is ThirteenOrphansTenpaiHand
            ? new ThirteenOrphansCompleteHand(hand, extraTile, player)
            : throw new Exception("I don't know how, but something went wrong");
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