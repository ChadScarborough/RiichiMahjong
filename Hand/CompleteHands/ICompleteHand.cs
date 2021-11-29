using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand.CompleteHands.CompleteHandComponents;

namespace RMU.Hand.CompleteHands
{
    public interface ICompleteHand
    {
        List<ICompleteHandComponent> GetCompleteHand();
    }
}
