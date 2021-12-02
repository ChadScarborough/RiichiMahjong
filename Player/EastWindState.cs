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
