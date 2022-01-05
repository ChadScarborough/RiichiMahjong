using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Hands.CompleteHands
{
    public interface ICompleteHand
    {
        List<ICompleteHandComponent> GetCompleteHand();
        Enums.CompleteHandWaitType GetWaitType();
        Enums.CompleteHandType GetCompleteHandType();
    }
}
