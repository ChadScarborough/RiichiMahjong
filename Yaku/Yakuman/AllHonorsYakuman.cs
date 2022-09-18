using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman;

public sealed class AllHonorsYakuman : Yakuman
{
    public AllHonorsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Honors";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        foreach (ICompleteHandComponent component in _completeHand.GetComponents())
        {
            if (component.GetLeadTile().IsHonor() is false)
            {
                return false;
            }
        }

        return true;
    }
}