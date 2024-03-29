using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using System.Collections.Generic;

namespace RMU.Yaku.StandardYaku;

public sealed class PureDoubleSequenceYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;

    public PureDoubleSequenceYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Pure Double Sequence";
        _value = 1;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand?.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        if (_completeHand.IsOpen())
        {
            return false;
        }

        List<ICompleteHandComponent> components = _completeHand.GetSequences();

        for (int i = 0; i < components.Count - 1; i++)
        {
            if (AreComponentsEquivalent(components[i], components[i + 1]))
            {
                return true;
            }
        }

        return false;
    }
}