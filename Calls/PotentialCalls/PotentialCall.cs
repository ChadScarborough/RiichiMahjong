using RMU.Players;

namespace RMU.Calls.PotentialCalls;

public abstract class PotentialCall : ICallObject
{
    private readonly Player _playerMakingCall;

    protected PotentialCall(Player playerMakingCall)
    {
        _playerMakingCall = playerMakingCall;
    }

    public abstract PotentialCallType GetCallType();

    public Player GetPlayerMakingCall()
    {
        return _playerMakingCall;
    }

    public void SetQueue(IPriorityQueue priorityQueue)
    {

    }

    public abstract int GetPriority();
}