using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Yaku.StandardYaku;

public class AllTerminalsAndHonorsYaku : YakuBase
{
    public AllTerminalsAndHonorsYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Terminals and Honors";
        _value = 2;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        foreach (ICompleteHandComponent component in _completeHand.GetComponents())
        {
            if (component.GetComponentType() is OPEN_CHII or CLOSED_CHII)
            {
                return false;
            }

            if (component.GetLeadTile().IsHonor() is false || component.GetLeadTile().IsTerminal() is false)
            {
                return false;
            }
        }

        return true;
    }
}