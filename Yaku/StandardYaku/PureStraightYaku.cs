using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.StandardYaku;

public sealed class PureStraightYaku : YakuBase
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
        if (_completeHand is null)
        {
            return false;
        }

        if (_completeHand.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        List<ICompleteHandComponent> sequences = _completeHand.GetSequences();
        if (sequences.Count < 3)
        {
            return false;
        }

        for (int i = 0; i < sequences.Count - 2; i++)
        {
            for (int j = i + 1; j < sequences.Count - 1; j++)
            {
                for (int k = j + 1; k < sequences.Count; k++)
                {
                    if (ComponentsFormPureStraight(sequences, i, j, k))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool ComponentsFormPureStraight(List<ICompleteHandComponent> sequences, int i, int j, int k)
    {
        return ComponentsHaveCorrectValues(sequences, i, j, k) && ComponentsAreOfSameSuit(sequences, i, j, k);
    }

    private bool ComponentsAreOfSameSuit(List<ICompleteHandComponent> sequences, int i, int j, int k)
    {
        return sequences[i].GetLeadTile().GetSuit() == sequences[j].GetLeadTile().GetSuit() &&
               sequences[j].GetLeadTile().GetSuit() == sequences[k].GetLeadTile().GetSuit();
    }

    private bool ComponentsHaveCorrectValues(List<ICompleteHandComponent> sequences, int i, int j, int k)
    {
        return sequences[i].GetLeadTile().GetValue() is 1 &&
               sequences[j].GetLeadTile().GetValue() is 4 &&
               sequences[k].GetLeadTile().GetValue() is 7;
    }
}