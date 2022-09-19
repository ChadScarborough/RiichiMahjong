using RMU.Players;
using RMU.Tiles;
using RMU.Yaku.StandardYaku;
using System.Collections.Generic;

namespace RMU.Games.Scoring;

internal static class HanCalculator
{
    private static readonly object hanLock = new();

    public static int Calculate(Player winningPlayer, List<YakuBase> satisfiedYaku)
    {
        lock (hanLock)
        {
            return CalculateHanValue(winningPlayer, satisfiedYaku);
        }
    }

    private static int CalculateHanValue(Player winningPlayer, List<YakuBase> satisfiedYaku)
    {
        int hanValue = 0;
        foreach (YakuBase yaku in satisfiedYaku)
        {
            hanValue += yaku.GetValue();
        }
        foreach (Tile tile in winningPlayer.GetHand().GetAllTiles())
        {
            if (tile.IsRedFive())
            {
                hanValue++;
            }

            hanValue += tile.GetDoraValue();
            hanValue += tile.GetUraDoraValue();
        }
        return hanValue == 0 ? throw new System.Exception("Hand completed with 0 han") : hanValue;
    }
}
