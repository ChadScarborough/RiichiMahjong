using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialLowChii : PotentialCall
{
    public PotentialLowChii(Player playerMakingCall) : base(playerMakingCall)
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