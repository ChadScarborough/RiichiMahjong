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
                PON_POTENTIAL_CALL_TYPE => new PotentialPon(playerMakingCall),
                LOW_CHII_POTENTIAL_CALL_TYPE => new PotentialLowChii(playerMakingCall),
                LOW_CHII_RED_POTENTIAL_CALL_TYPE => new PotentialLowChiiRed(playerMakingCall),
                MID_CHII_POTENTIAL_CALL_TYPE => new PotentialMidChii(playerMakingCall),
                MID_CHII_RED_POTENTIAL_CALL_TYPE => new PotentialMidChiiRed(playerMakingCall),
                HIGH_CHII_POTENTIAL_CALL_TYPE => new PotentialHighChii(playerMakingCall),
                HIGH_CHII_RED_POTENTIAL_CALL_TYPE => new PotentialHighChiiRed(playerMakingCall),
                OPEN_KAN_1_POTENTIAL_CALL_TYPE => new PotentialOpenKan1(playerMakingCall),
                RON_POTENTIAL_CALL_TYPE => new PotentialRon(playerMakingCall),
                _ => throw new ArgumentException("Invalid call type"),
            };
        }
    }
}