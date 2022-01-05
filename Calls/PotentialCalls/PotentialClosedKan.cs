using static RMU.Globals.Enums;
using RMU.Player;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialClosedKan : PotentialCall
    {
        public PotentialClosedKan(AbstractPlayer playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return CLOSED_KAN_POTENTIAL_CALL_TYPE;
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}