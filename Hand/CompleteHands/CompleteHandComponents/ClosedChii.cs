using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedChii : ICompleteHandGroup
    {
        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.ClosedChii;
        }
    }
}
