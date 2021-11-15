using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Player
{
    public class NorthWindState : ISeatWindState
    {
        public PlayerEnums.SeatWinds GetSeatWind()
        {
            return PlayerEnums.SeatWinds.North;
        }
    }
}
