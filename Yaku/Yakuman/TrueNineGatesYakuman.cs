using RMU.Hands.CompleteHands;
using RMU.Hands.TenpaiHands;

namespace RMU.Yaku.Yakuman
{
    public sealed class TrueNineGatesYakuman : YakumanBase
    {
        private readonly ITenpaiHand _tenpaiHand;

        public TrueNineGatesYakuman(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "True Nine Gates";
            _value = 26;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _tenpaiHand = completeHand.GetTenpaiHand();
        }

        public override bool Check()
        {
            return _tenpaiHand.GetWaits().Count == 9;
        }
    }
}
