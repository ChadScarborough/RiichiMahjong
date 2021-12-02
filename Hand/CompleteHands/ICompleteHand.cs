using System.Collections.Generic;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Globals;

namespace RMU.Hand.CompleteHands
{
    public interface ICompleteHand
    {
        List<ICompleteHandComponent> GetCompleteHand();
        Enums.CompleteHandWaitType GetWaitType();
        Enums.CompleteHandType GetCompleteHandType();
    }
}
