using RMU.Players;
using static RMU.Globals.Enums;

namespace RMU.Calls.PotentialCalls
{
    public abstract class PotentialCall : ICallObject
    {
        private readonly Player _playerMakingCall;
        private IPriorityQueue _priorityQueue;

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
            _priorityQueue = priorityQueue;
        }

        public abstract int GetPriority();
    }
}