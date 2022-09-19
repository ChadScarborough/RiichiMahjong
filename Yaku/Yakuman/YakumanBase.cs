using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public abstract class YakumanBase : YakuBase
{
    protected YakumanBase(ICompleteHand completeHand) : base(completeHand)
    {
    }
}