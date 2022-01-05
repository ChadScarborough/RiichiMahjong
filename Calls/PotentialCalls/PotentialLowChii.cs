using static RMU.Globals.Enums;
using RMU.Player;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialLowChii : PotentialCall
    {
        public PotentialLowChii(AbstractPlayer playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return LOW_CHII_POTENTIAL_CALL_TYPE;
        }
        
        public override int GetPriority()
        {
            return 1;
        }
    }
}