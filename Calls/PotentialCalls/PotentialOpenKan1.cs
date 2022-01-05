using static RMU.Globals.Enums;
using RMU.Player;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialOpenKan1 : PotentialCall
    {
        public PotentialOpenKan1(AbstractPlayer playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return OPEN_KAN_1_POTENTIAL_CALL_TYPE;
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}