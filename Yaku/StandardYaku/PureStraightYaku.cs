using System.Collections.Generic;
using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Yaku.StandardYaku;

public class PureStraightYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;
    
    public PureStraightYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Pure Straight";
        _value = 2;
        _getValueBehaviour = new OpenDependentGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null) return false;
        if (_completeHand.GetCompleteHandType() is not STANDARD) return false;
        List<ICompleteHandComponent> components = _completeHand.GetSequences();
        if (components.Count < 3) return false;
        for (int i = 0; i < 2; i++)
        {
            for (int j = i + 1; j < 3; j++)
            {
                for (int k = j + 1; k < 4; k++)
                {
                    if (ComponentsFormPureStraight(components, i, j, k))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool ComponentsFormPureStraight(List<ICompleteHandComponent> components, int i, int j, int k)
    {
        return ComponentsHaveCorrectValues(components, i, j, k) && ComponentsAreOfSameSuit(components, i, j, k);
    }
    
    private bool ComponentsAreOfSameSuit(List<ICompleteHandComponent> components, int i, int j, int k)
    {
        return components[i].GetLeadTile().GetSuit() == components[j].GetLeadTile().GetSuit() &&
               components[j].GetLeadTile().GetSuit() == components[k].GetLeadTile().GetSuit();
    }

    private bool ComponentsHaveCorrectValues(List<ICompleteHandComponent> components, int i, int j, int k)
    {
        return components[i].GetLeadTile().GetValue() is 1 &&
               components[j].GetLeadTile().GetValue() is 4 &&
               components[k].GetLeadTile().GetValue() is 7;
    }
}