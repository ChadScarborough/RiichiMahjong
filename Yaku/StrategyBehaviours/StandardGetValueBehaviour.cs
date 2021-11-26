using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku
{
    public class StandardGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value)
        {
            return value;
        }
    }
}
