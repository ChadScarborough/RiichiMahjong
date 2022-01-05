using static RMU.Globals.Enums;
using RMU.Player;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialRon : PotentialCall
    {
        public PotentialRon(AbstractPlayer playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return RON_POTENTIAL_CALL_TYPE;
        }

        public override int GetPriority()
        {
            return 3;
        }
    }
}