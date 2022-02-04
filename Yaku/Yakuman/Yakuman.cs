using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public abstract class Yakuman : StandardYaku.Yaku
{
    protected Yakuman(ICompleteHand completeHand) : base(completeHand)
    {
    }
}