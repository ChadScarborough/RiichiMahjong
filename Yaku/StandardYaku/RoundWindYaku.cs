using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Yaku.StandardYaku
{
    public class RoundWindYaku : YakuBase
    {
        private readonly new StandardCompleteHand _completeHand;

        public RoundWindYaku(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Round wind"; //Prevailing wind?
            _value = 1;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null) return false;
            Wind roundWind = _completeHand.GetPlayer().GetGame().GetRoundWind();
            return HandContainsRoundWindTriplet(roundWind);
        }

        private bool HandContainsRoundWindTriplet(Wind roundWind)
        {
            foreach (ICompleteHandComponent component in _completeHand.GetTriplets())
            {
                Tile tile = component.GetLeadTile();
                if (tile.GetSuit() is WIND)
                {
                    if (AreWindsEquivalent(tile, roundWind)) return true;
                }
            }
            return false;
        }
    }
}
