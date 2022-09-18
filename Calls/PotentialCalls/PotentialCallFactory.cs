using RMU.Players;
using System;

namespace RMU.Calls.PotentialCalls
{
    public static class PotentialCallFactory
    {
        public static PotentialCall CreatePotentialCall(Player playerMakingCall, PotentialCallType callType)
        {
            return callType switch
            {
                PotentialCallType.Pon => new PotentialPon(playerMakingCall),
                PotentialCallType.LowChii => new PotentialLowChii(playerMakingCall),
                PotentialCallType.MidChii => new PotentialMidChii(playerMakingCall),
                PotentialCallType.HighChii => new PotentialHighChii(playerMakingCall),
                PotentialCallType.OpenKan1 => new PotentialOpenKan1(playerMakingCall),
                PotentialCallType.Ron => new PotentialRon(playerMakingCall),
                _ => throw new ArgumentException("Invalid call type"),
            };
        }
    }
}