using System;
using RMU.Globals;
using RMU.Players;

namespace RMU.Calls.PotentialCalls
{
    public static class PotentialCallFactory
    {
        public static PotentialCall CreatePotentialCall(Player playerMakingCall, Enums.PotentialCallType callType)
        {
            switch (callType)
            {
                case Enums.PotentialCallType.Pon:
                    return new PotentialPon(playerMakingCall);
                case Enums.PotentialCallType.LowChii:
                    return new PotentialLowChii(playerMakingCall);
                case Enums.PotentialCallType.MidChii:
                    return new PotentialMidChii(playerMakingCall);
                case Enums.PotentialCallType.HighChii:
                    return new PotentialHighChii(playerMakingCall);
                case Enums.PotentialCallType.OpenKan1:
                    return new PotentialOpenKan1(playerMakingCall);
                case Enums.PotentialCallType.Ron:
                    return new PotentialRon(playerMakingCall);
            }

            throw new ArgumentException("Invalid call type");
        }
    }
}