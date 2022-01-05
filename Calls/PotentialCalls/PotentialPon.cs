using static RMU.Globals.Enums;
using RMU.Players;

namespace RMU.Calls.PotentialCalls
{
    public class PotentialPon : PotentialCall
    {
        public PotentialPon(Player playerMakingCall) : base(playerMakingCall)
        {
        }

        public override PotentialCallType GetCallType()
        {
            return PON_POTENTIAL_CALL_TYPE;
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}