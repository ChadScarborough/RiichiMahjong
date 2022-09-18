using RMU.Hands.CompleteHands;

namespace RMU.Yaku;

public sealed class StandardGetValueBehaviour : IGetValueBehaviour
{
    public int GetValue(ICompleteHand completeHand, int value)
    {
        return value;
    }
}