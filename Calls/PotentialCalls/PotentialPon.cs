using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialPon : PotentialCall
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