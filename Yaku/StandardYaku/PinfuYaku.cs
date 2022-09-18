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
            ICompleteHandComponent pair = completeHand.GetPairs()[0];
            Tile tile = pair.GetLeadTile();
            if (HasDragonPair(tile))
            {
                return true;
            }

            return HasSeatWindPair(completeHand, tile) || HasRoundWindPair(completeHand, tile);
        }

        private static bool HasDragonPair(Tile tile)
        {
            return tile.GetSuit() == DRAGON;
        }

        private static bool HasSeatWindPair(ICompleteHand completeHand, Tile tile)
        {
            Wind seatWind = completeHand.GetPlayer().GetSeatWind();
            return AreWindsEquivalent(tile, seatWind);
        }

        private static bool HasRoundWindPair(ICompleteHand completeHand, Tile tile)
        {
            Wind roundWind = completeHand.GetPlayer().GetGame().GetRoundWind();
            return AreWindsEquivalent(tile, roundWind);
        }
    }
}
