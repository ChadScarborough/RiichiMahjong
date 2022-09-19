using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System;

namespace RMU.Games.Scoring;

internal static class FuCalculator
{
    private static readonly object fuLock = new();

    public static int Calculate(ICompleteHand completeHand, WinningCallType winningCallType)
    {
        lock (fuLock)
        {
            return CalculateFuValue(completeHand, winningCallType);
        }
    }

    private static int CalculateFuValue(ICompleteHand completeHand, WinningCallType winningCallType)
    {
        if (completeHand.GetCompleteHandType() == SEVEN_PAIRS)
        {
            return 25;
        }

        if (completeHand.GetCompleteHandType() == THIRTEEN_ORPHANS)
        {
            return 0;
        }

        int fu = 20;
        fu += FuFromTripletsAndQuads(completeHand);
        fu += FuFromWinningCall(completeHand, winningCallType);
        fu += FuFromYakuhaiPair(completeHand);
        fu += FuFromWaitType(completeHand);
        fu = RoundUpToNearestTen(fu);
        return fu;
    }

    private static int FuFromTripletsAndQuads(ICompleteHand completeHand)
    {
        int fu = 0;
        foreach (ICompleteHandComponent component in completeHand.GetTriplets())
        {
            if (component.GetLeadTile().IsTerminalOrHonor())
            {
                fu += FuFromTerminalOrHonorTripletOrQuad(component);
                continue;
            }
            fu += FuFromSimpleTripletOrQuad(component);
        }
        return fu;
    }

    private static int FuFromTerminalOrHonorTripletOrQuad(ICompleteHandComponent component)
    {
        return component.GetComponentType() switch
        {
            OPEN_PON => 4,
            CLOSED_PON => 8,
            OPEN_KAN => 16,
            CLOSED_KAN_COMPONENT => 32,
            _ => throw new Exception("Invalid component type")
        };
    }

    private static int FuFromSimpleTripletOrQuad(ICompleteHandComponent component)
    {
        return component.GetComponentType() switch
        {
            OPEN_PON => 2,
            CLOSED_PON => 4,
            OPEN_KAN => 8,
            CLOSED_KAN_COMPONENT => 16,
            _ => throw new Exception("Invalid component type")
        };
    }

    private static int FuFromWinningCall(ICompleteHand completeHand, WinningCallType winningCallType)
    {
        return winningCallType == TSUMO ? 2 :
            winningCallType == RON && (completeHand.IsOpen() == false) ? 10 : 0;
    }

    private static int FuFromYakuhaiPair(ICompleteHand completeHand)
    {
        ICompleteHandComponent pair = completeHand.GetPairs()[0];
        Tile tile = pair.GetLeadTile();
        Wind wind = completeHand.GetPlayer().GetSeatWind();
        return tile.GetSuit() switch
        {
            DRAGON => 2,
            WIND => FuFromWind(wind, tile),
            _ => 0
        };
    }

    private static int FuFromWind(Wind seatWind, Tile windTile)
    {
        return AreWindsEquivalent(windTile, seatWind) ? 2 : 0;
    }

    private static int FuFromWaitType(ICompleteHand completeHand)
    {
        CompleteHandWaitType waitType = completeHand.GetWaitType();
        return waitType switch
        {
            EDGE_WAIT or PAIR_WAIT or CLOSED_WAIT or TWO_SIDED_TRIPLET_WAIT => 2,
            _ => 0,
        };
    }

    private static int RoundUpToNearestTen(int fu)
    {
        while (fu % 10 != 0)
        {
            fu++;
        }
        return fu;
    }
}
