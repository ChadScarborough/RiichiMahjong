using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public abstract class Yakuman : StandardYaku.YakuBase
{
    protected Yakuman(ICompleteHand completeHand) : base(completeHand)
    {
    }
}