using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Player
{
    public class SouthWindState : ISeatWindState
    {
        public PlayerEnums.SeatWinds GetSeatWind()
        {
            return PlayerEnums.SeatWinds.South;
        }
    }
}
