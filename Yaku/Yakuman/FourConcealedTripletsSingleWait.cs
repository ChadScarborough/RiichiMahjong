using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman
{
    public class FourConcealedTripletsSingleWait : Yakuman
    {
        private readonly new StandardCompleteHand _completeHand;

        public FourConcealedTripletsSingleWait(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Four Concealed Triplets Single Wait";
            _value = 26;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null) return false;
            if (_completeHand.IsOpen()) return false;
            if (_completeHand.GetTriplets().Count < 4) return false;
            if (_completeHand.GetWaitType() is not PAIR_WAIT) return false;
            return true;
        }
    }
}
