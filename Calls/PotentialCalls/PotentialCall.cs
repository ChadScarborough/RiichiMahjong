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

    public override bool Equals(object obj)
    {
        if (!obj.GetType().IsAssignableTo(typeof(PotentialCall)))
            return false;
        var call = obj as PotentialCall;
        if (call.GetCallType() != this.GetCallType())
            return false;
        if (call.GetPlayerMakingCall() != this.GetPlayerMakingCall())
            return false;
        return true;
    }
}