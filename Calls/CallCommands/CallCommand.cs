using RMU.Hands;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public abstract class CallCommand : ICallObject
{
    private readonly Player _playerMakingCall;
    protected readonly Hand _handMakingCall;
    protected readonly Tile _calledTile;
    protected IPriorityQueue _priorityQueue;

    protected CallCommand(Player playerMakingCall, Tile calledTile)
    {
        _playerMakingCall = playerMakingCall;
        _handMakingCall = playerMakingCall.GetHand();
        _calledTile = calledTile;
    }

    public abstract void Execute();
    public abstract int GetPriority();

    public Player GetPlayerMakingCall()
    {
        return _playerMakingCall;
    }

    public void SetQueue(IPriorityQueue priorityQueue)
    {
        _priorityQueue = priorityQueue;
    }
}