using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Player
{
    public class WestWindState : ISeatWindState
    {
        public PlayerEnums.SeatWinds GetSeatWind()
        {
            return PlayerEnums.SeatWinds.West;
        }
    }
}
