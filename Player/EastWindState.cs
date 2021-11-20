using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Player
{
    public class EastWindState : ISeatWindState
    {
        public Enums.Wind GetSeatWind()
        {
            return Enums.Wind.East;
        }
    }
}
