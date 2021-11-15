using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Player
{
    public class EastWindState : ISeatWindState
    {
        public PlayerEnums.SeatWinds GetSeatWind()
        {
            return PlayerEnums.SeatWinds.East;
        }
    }
}
