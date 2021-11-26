using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand;

namespace RMU.Yaku
{
    public class StandardGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value, IHand hand)
        {
            return value;
        }
    }
}
