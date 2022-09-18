using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.StandardYaku;

public sealed class HalfFlushYaku : YakuBase
{
    public HalfFlushYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Half Flush";
        _value = 3;
        _getValueBehaviour = new OpenDependentGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetCompleteHandType() is THIRTEEN_ORPHANS)
        {
            return false;
        }

        Suit suit = _completeHand.GetConstructedHandComponents()[0].GetLeadTile().GetSuit();
        if (suit is not MAN and not PIN and not SOU)
        {
            return false;
        }

        foreach (ICompleteHandComponent component in _completeHand.GetConstructedHandComponents())
        {
            if (component.GetLeadTile().GetSuit() != suit && component.GetLeadTile().IsHonor() == false)
            {
                return false;
            }
        }

        foreach (ICompleteHandComponent component in _completeHand.GetConstructedHandComponents())
        {
            if (component.GetLeadTile().IsHonor())
            {
                return true;
            }
        }

        return false;
    }
}