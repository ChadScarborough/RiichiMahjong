using RMU.Hands.CompleteHands;

namespace RMU.Yaku;

public class StandardGetValueBehaviour : IGetValueBehaviour
{
    public int GetValue(ICompleteHand completeHand, int value)
    {
        return value;
    }
}