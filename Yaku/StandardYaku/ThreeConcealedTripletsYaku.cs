using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.StandardYaku
{
    public class ThreeConcealedTripletsYaku : YakuBase
    {
        private readonly new StandardCompleteHand _completeHand;

        public ThreeConcealedTripletsYaku(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Three Concealed Triplets";
            _value = 2;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null) return false;
            int t = 0;
            foreach(ICompleteHandComponent component in _completeHand.GetTriplets())
            {
                CompleteHandComponentType type = component.GetComponentType();
                if (type is CLOSED_PON or CLOSED_KAN_COMPONENT)
                    t++;
            }
            return t >= 3;
        }
    }
}
