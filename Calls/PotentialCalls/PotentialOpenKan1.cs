using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public sealed class PotentialOpenKan1 : PotentialCall
{
    public PotentialOpenKan1(Player playerMakingCall) : base(playerMakingCall)
    {
    }

    public override PotentialCallType GetCallType()
    {
        return OPEN_KAN_1_POTENTIAL_CALL_TYPE;
    }

    public override int GetPriority()
    {
        return 2;
    }
}