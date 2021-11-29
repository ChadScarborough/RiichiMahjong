using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public interface ICompleteHandComponent
    {
        Enums.CompleteHandComponentType GetComponentType();
    }
}
