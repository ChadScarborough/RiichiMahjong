using RMU.Calls.CreateMeldBehaviours;
using RMU.Shanten;
using RMU.Tiles;

namespace RMU.Hands.RiichiCheckHands
{
    internal static class RiichiChecker
    {
        internal static List<Tile> CheckRiichi(Hand hand)
        {
            List<Tile> tiles = hand.GetTilesInHand();
            List<OpenMeld> openMelds = hand.GetOpenMelds();
            List<Tile> canDiscard = new();

            for (int i = 0; i < tiles.Count; i++)
            {
                List<Tile> checkList = new();
                for (int j = 0; j < tiles.Count; j++)
                {
                    if (j == i)
                        continue;
                    checkList.Add(tiles[j]);
                }
                RiichiCheckHand checkHand = new(checkList, openMelds);
                int shanten = ShantenCalculator.CalculateShantenForRiichiCall(checkHand);
                if (shanten == 0)
                    canDiscard.Add(tiles[i]);
            }
            return canDiscard;
        }
    }
}
