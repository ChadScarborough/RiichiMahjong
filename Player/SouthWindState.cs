using RMU.Globals;

namespace RMU.Player
{
    public class SouthWindState : ISeatWindState
    {
        public Enums.Wind GetSeatWind()
        {
            return Enums.SOUTH;
        }
    }
}
