using RMU.Tiles;
using RMU.Players;
using RMU.Hands;

namespace RMU.Calls.CallCommands
{
    public abstract class CallCommand : ICallObject
    {
        private readonly Player _playerMakingCall;
        protected readonly Hand _handMakingCall;
        protected readonly TileObject _calledTile;
        protected IPriorityQueue _priorityQueue;
        
        protected CallCommand(Player playerMakingCall, TileObject calledTile)
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
}