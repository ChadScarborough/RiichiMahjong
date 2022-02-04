using RMU.Hands.CompleteHands;

namespace RMU.Yaku;

public interface IGetValueBehaviour
{
    int GetValue(ICompleteHand completeHand, int value);
}