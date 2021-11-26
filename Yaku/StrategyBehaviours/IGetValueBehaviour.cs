using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand;

namespace RMU.Yaku
{
    public interface IGetValueBehaviour
    {
        int GetValue(int value, IHand hand);
    }
}
