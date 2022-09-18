using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialRon : PotentialCall
{
    public PotentialRon(Player playerMakingCall) : base(playerMakingCall)
    {
    }

    public override PotentialCallType GetCallType()
    {
        return RON_POTENTIAL_CALL_TYPE;
    }

    public override int GetPriority()
    {
        return 3;
    }
}