using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Player
{
    public class WestWindState : ISeatWindState
    {
        public Enums.Wind GetSeatWind()
        {
            return Enums.Wind.West;
        }
    }
}
