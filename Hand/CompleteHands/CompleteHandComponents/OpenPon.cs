using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class OpenPon : ICompleteHandGroup
    {
        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.OpenPon;
        }
    }
}
