using static RMU.Globals.Enums;
using RMU.Player;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialHighChii : PotentialCall
    {
        public PotentialHighChii(AbstractPlayer playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return HIGH_CHII_POTENTIAL_CALL_TYPE;
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}