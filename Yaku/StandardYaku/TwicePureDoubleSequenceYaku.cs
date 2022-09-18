using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using System.Collections.Generic;

namespace RMU.Yaku.StandardYaku;

public sealed class TwicePureDoubleSequenceYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;

    public TwicePureDoubleSequenceYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Twice Pure Double Sequence";
        _value = 3;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null)
        {
            return false;
        }

        if (_completeHand.IsOpen())
        {
            return false;
        }

        List<ICompleteHandComponent> components = _completeHand.GetSequences();
        return components.Count == 4
               && AreComponentsEquivalent(components[0], components[1])
               && AreComponentsEquivalent(components[2], components[3]);
    }
}