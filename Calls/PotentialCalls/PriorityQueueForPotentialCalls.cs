using System.Collections.Generic;
using RMU.Player;

namespace RMU.Calls.PotentialCalls
{
    public class PriorityQueueForPotentialCalls
    {
        private readonly List<PotentialCall> _priorityQueue;

        public PriorityQueueForPotentialCalls()
        {
            _priorityQueue = new List<PotentialCall>();
        }

        public void AddPotentialCallToQueue(PotentialCall potentialCall)
        {
            for (int i = 0; i < _priorityQueue.Count; i++)
            {
                if (potentialCall.GetPriority() >= _priorityQueue[i].GetPriority())
                {
                    _priorityQueue.Insert(i, potentialCall);
                    return;
                }
                _priorityQueue.Add(potentialCall);
            }
        }

        public void Clear()
        {
            _priorityQueue.Clear();
        }

        public void RemoveAllCallsFromGivenPlayer(AbstractPlayer player)
        {
            for (int i = _priorityQueue.Count - 1; i >= 0; i--)
            {
                if (_priorityQueue[i].GetPlayerMakingCall() == player)
                {
                    _priorityQueue.RemoveAt(i);
                }
            }
        }

        public void RemoveAllCallsBelowGivenPriority(int priority)
        {
            for (int i = _priorityQueue.Count - 1; i >= 0; i--)
            {
                if (_priorityQueue[i].GetPriority() < priority)
                {
                    _priorityQueue.RemoveAt(i);
                }
            }
        }
    }
}