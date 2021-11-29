using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceOpenWait : ICompleteHandIncompleteGroup
    {
        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.IncompleteSequenceOpenWait;
        }
    }
}
