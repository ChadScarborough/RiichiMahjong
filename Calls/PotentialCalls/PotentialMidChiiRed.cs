using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialMidChiiRed : PotentialCall
{
    public PotentialMidChiiRed(Player playerMakingCall) : base(playerMakingCall)
    {
    }

    public override PotentialCallType GetCallType()
    {
        return MID_CHII_RED_POTENTIAL_CALL_TYPE;
    }

    public override int GetPriority()
    {
        return 1;
    }
}
