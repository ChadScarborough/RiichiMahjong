using RMU.Players;
using RMU.Tiles;
using RMU.Yaku.StandardYaku;
using System.Collections.Generic;

namespace RMU.Games.Scoring
{
    internal class HanCalculator
    {
        public static int CalculateHanValue(Player winningPlayer, List<YakuBase> satisfiedYaku)
        {
            int hanValue = 0;
            foreach(YakuBase yaku in satisfiedYaku)
            {
                hanValue += yaku.GetValue();
            }
            foreach(TileObject tile in winningPlayer.GetHand().GetAllTiles())
            {
                if (tile.IsRedFive()) hanValue++;
                hanValue += tile.GetDoraValue();
                hanValue += tile.GetUraDoraValue();
            }
            if (hanValue == 0)
                throw new System.Exception("Hand completed with 0 han");
            return hanValue;
        }
    }
}
