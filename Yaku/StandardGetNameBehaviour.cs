using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku
{
    public class StandardGetNameBehaviour : IGetNameBehaviour
    {
        public string GetName(string name)
        {
            return name;
        }
    }
}
