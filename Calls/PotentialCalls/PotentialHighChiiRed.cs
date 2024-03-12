using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialHighChiiRed : PotentialCall
{
    public PotentialHighChiiRed(Player playerMakingCall) : base(playerMakingCall)
    {
    }

    public override PotentialCallType GetCallType()
    {
        return HIGH_CHII_RED_POTENTIAL_CALL_TYPE;
    }

    public override int GetPriority()
    {
        return 1;
    }
}
