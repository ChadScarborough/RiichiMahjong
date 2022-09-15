using System.Collections.Generic;
using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Functions;

namespace RMU.Yaku.StandardYaku;

public class TwicePureDoubleSequenceYaku : YakuBase
{
    private new readonly  StandardCompleteHand _completeHand;
    
    public TwicePureDoubleSequenceYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Twice Pure Double Sequence";
        _value = 3;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null) return false;
        if (_completeHand.IsOpen()) return false;

        List<ICompleteHandComponent> components = _completeHand.GetSequences();
        if (components.Count != 4) return false;
        int matchingSequences = 0;

        if (AreComponentsEquivalent(components[0], components[1]))
        {
            matchingSequences++;
        }

        if (AreComponentsEquivalent(components[2], components[3]))
        {
            matchingSequences++;
        }

        return matchingSequences == 2;
    }
}