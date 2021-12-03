using RMU.Globals;

namespace RMU.Player
{
    public class NorthWindState : ISeatWindState
    {
        public Enums.Wind GetSeatWind()
        {
            return Enums.NORTH;
        }
    }
}
