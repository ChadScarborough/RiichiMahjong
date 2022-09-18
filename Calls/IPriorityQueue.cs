using RMU.Players;

namespace RMU.Calls;

public interface IPriorityQueue
{
    void AddCall(ICallObject callObject);
    void Clear();
    void RemoveByPlayer(Player player);
    void RemoveByPriority(int priority);
}