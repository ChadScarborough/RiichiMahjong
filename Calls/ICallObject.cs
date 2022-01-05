using RMU.Players;

namespace RMU.Calls
{
    public interface ICallObject
    {
        public int GetPriority();
        public Player GetPlayerMakingCall();
        public void SetQueue(IPriorityQueue priorityQueue);
    }
}