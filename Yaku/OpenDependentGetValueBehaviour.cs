using RMU.Hands.CompleteHands;

namespace RMU.Yaku;

public class OpenDependentGetValueBehaviour : IGetValueBehaviour
{
    public int GetValue(ICompleteHand completeHand, int value)
    {
        if (completeHand.IsOpen())
        {
            return value - 1;
        }

        return value;
    }
}