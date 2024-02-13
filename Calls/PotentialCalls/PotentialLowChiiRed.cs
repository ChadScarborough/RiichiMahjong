using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialLowChiiRed : PotentialCall
{
    public PotentialLowChiiRed(Player playerMakingCall) : base(playerMakingCall)
    {
    }

    public override PotentialCallType GetCallType()
    {
        return LOW_CHII_RED_POTENTIAL_CALL_TYPE;
    }

    public override int GetPriority()
    {
        return 1;
    }
}