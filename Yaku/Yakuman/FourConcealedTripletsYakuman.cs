using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman
{
    public sealed class FourConcealedTripletsYakuman : Yakuman
    {
        private readonly new StandardCompleteHand _completeHand;

        public FourConcealedTripletsYakuman(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Four Concealed Triplets";
            _value = 13;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null) return false;
            if (_completeHand.IsOpen()) return false;
            if (_completeHand.GetSequences().Count > 0) return false;
            WinningCallType winningCall = GetWinningCall();
            foreach(ICompleteHandComponent component in _completeHand.GetTriplets())
                if (component.GetComponentType() is OPEN_PON or OPEN_KAN) return false;
            if (winningCall is RON && _completeHand.GetWaitType() is TWO_SIDED_TRIPLET_WAIT) // This might be redundant; if you successfully call Ron for Four Concealed Triplets, I think you necessarily satisfy the double yakuman
                return false;
            return true;
        }

        private WinningCallType GetWinningCall()
        {
            return _completeHand.GetPlayer().GetGame().GetWinningCall();
        }
    }
}
