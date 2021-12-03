using RMU.Globals;

namespace RMU.Player
{
    public class WestWindState : ISeatWindState
    {
        public Enums.Wind GetSeatWind()
        {
            return Enums.WEST;
        }
    }
}
