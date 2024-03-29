using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using System;
using System.Collections.Generic;

namespace RMU.Yaku.StandardYaku;

public sealed class MixedTripleSequenceYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;

    public MixedTripleSequenceYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Mixed Triple Sequence";
        _value = 2;
        _getValueBehaviour = new OpenDependentGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null)
        {
            return false;
        }

        List<ICompleteHandComponent> components = _completeHand.GetSequences();
        if (components.Count < 3)
        {
            return false;
        }

        try
        {
            for (int i = 0; i < components.Count -2; i++)
            {
                if (components[i].GetLeadTile().GetSuit() is not MAN)
                {
                    break;
                }
                for (int j = i + 1; j < components.Count - 1; j++)
                {
                    if (components[j].GetLeadTile().GetSuit() is not PIN)
                    {
                        break;
                    }
                    for (int k = j + 1; k < components.Count; k++)
                    {
                        if (components[k].GetLeadTile().GetSuit() is not SOU)
                        {
                            break;
                        }

                        if (ComponentsFormMixedTripleSequence(components, i, j, k))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    private static bool ComponentsFormMixedTripleSequence(List<ICompleteHandComponent> components, int i, int j, int k)
    {
        return LeadTileValue(components[i]) == LeadTileValue(components[j]) &&
               LeadTileValue(components[j]) == LeadTileValue(components[k]);
    }

    private static int LeadTileValue(ICompleteHandComponent component)
    {
        return component.GetLeadTile().GetValue();
    }
}