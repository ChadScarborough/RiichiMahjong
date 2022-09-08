

using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku
{
    public class FullyConcealedHandYaku : YakuBase
    {
        public FullyConcealedHandYaku(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Fully Concealed Hand";
            _value = 1;
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool Check()
        {
            if (_completeHand.GetPlayer().IsActivePlayer() == false) return false;
            if (_completeHand.IsOpen() == true) return false;
            return true;
        }
    }
}
