using static RMU.Globals.Enums;
using RMU.Players;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialMidChii : PotentialCall
    {
        public PotentialMidChii(Player playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return MID_CHII_POTENTIAL_CALL_TYPE;
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}