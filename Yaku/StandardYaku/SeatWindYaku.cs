using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Yaku.StandardYaku
{
    public class SeatWindYaku : YakuBase
    {
        private readonly new StandardCompleteHand _completeHand;

        public SeatWindYaku(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Seat Wind";
            _value = 1;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null) return false;
            Wind seatWind = _completeHand.GetPlayer().GetSeatWind();
            return HandContainsSeatWindTriplet(seatWind);
        }

        private bool HandContainsSeatWindTriplet(Wind seatWind)
        {
            foreach (ICompleteHandComponent component in _completeHand.GetTriplets())
            {
                Tile tile = component.GetLeadTile();
                if (tile.GetSuit() is WIND)
                {
                    if (AreWindsEquivalent(tile, seatWind)) return true;
                }
            }
            return false;
        }
    }
}
