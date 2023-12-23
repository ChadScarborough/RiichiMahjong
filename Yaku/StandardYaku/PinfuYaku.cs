using System.Linq;
using RMU.Hands.CompleteHands;

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
            
            if (_completeHand.GetWaitType() is not CompleteHandWaitType.OpenWait)
            {
                return false;
            }

            return !HasYakuhai(_completeHand);
        }

        private static bool HasYakuhai(ICompleteHand completeHand)
        {
            Wind seatWind = completeHand.GetPlayer().GetSeatWind();
            Wind roundWind = completeHand.GetPlayer().GetGame().GetRoundWind();
            return HasDragons(completeHand) || HasWinds(completeHand, seatWind) || HasWinds(completeHand, roundWind);
        }

        private static bool HasDragons(ICompleteHand completeHand)
        {
            return completeHand.GetTiles().Any(tile => tile.GetSuit() is DRAGON);
        }

        private static bool HasWinds(ICompleteHand completeHand, Wind wind)
        {
            return completeHand.GetTiles().Any(tile => AreWindsEquivalent(tile, wind));
        }
    }
}
