using System.Linq;
using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public sealed class AllHonorsYakuman : YakumanBase
{
    public AllHonorsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Honors";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return _completeHand.GetComponents().All(component => component.GetLeadTile().IsHonor());
    }
}