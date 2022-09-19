using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Yaku.StandardYaku
{
    public sealed class PinfuYaku : YakuBase
    {
        private new readonly ICompleteHand _completeHand;

        public PinfuYaku(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Pinfu";
            _value = 1;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null)
            {
                return false;
            }

            if (_completeHand.IsOpen())
            {
                return false;
            }

            if (_completeHand.GetTriplets().Count > 0)
            {
                return false;
            }

            return !HasYakuhaiPair(_completeHand);
        }

        private static bool HasYakuhaiPair(ICompleteHand completeHand)
        {
            Wind seatWind = completeHand.GetPlayer().GetSeatWind();
            Wind roundWind = completeHand.GetPlayer().GetGame().GetRoundWind();
            return HasDragons(completeHand) || HasWinds(completeHand, seatWind) || HasWinds(completeHand, roundWind);
        }

        private static bool HasDragons(ICompleteHand completeHand)
        {
            foreach(Tile tile in completeHand.GetTiles())
            {
                if (tile.GetSuit() is DRAGON)
                    return true;
            }
            return false;
        }

        private static bool HasWinds(ICompleteHand completeHand, Wind wind)
        {
            foreach(Tile tile in completeHand.GetTiles())
            {
                if (AreWindsEquivalent(tile, wind))
                    return true;
            }
            return false;
        }
    }
}
