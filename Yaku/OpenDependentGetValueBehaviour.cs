using RMU.Hands.CompleteHands;

namespace RMU.Yaku;

public sealed class OpenDependentGetValueBehaviour : IGetValueBehaviour
{
    public int GetValue(ICompleteHand completeHand, int value)
    {
        return completeHand.IsOpen() ? value - 1 : value;
    }
}