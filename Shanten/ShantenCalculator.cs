using RMU.Hands;
using RMU.Shanten.HandSplitter;
using System.Collections.Generic;

namespace RMU.Shanten;

public static class ShantenCalculator
{
    public static int CalculateShanten(Hand hand)
    {
        List<TileCollection> collections = HandSplitter.HandSplitter.SplitHandBySuit(hand.GetTilesInHand());
        int numberOfOpenMelds = hand.GetOpenMelds().Count;
        int sevenPairsShanten = 6, thirteenOrphansShanten = 6;

        int standardShanten = StandardShantenCalculator.CalculateShanten(hand, collections, numberOfOpenMelds);

        if (numberOfOpenMelds == 0)
        {
            sevenPairsShanten = SevenPairsShantenCalculator.CalculateShanten(hand, collections);
            thirteenOrphansShanten = ThirteenOrphansShantenCalculator.CalculateShanten(hand, collections);
        }

        return MinOfThree(standardShanten, sevenPairsShanten, thirteenOrphansShanten);
    }
}