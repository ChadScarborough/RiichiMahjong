using System;
using System.Collections.Generic;
using RMU.Players;

namespace RMU.Calls.PotentialCalls
{
    public class PriorityQueueForPotentialCalls : IPriorityQueue
    {
        private readonly List<PotentialCall> _priorityQueue;

        public PriorityQueueForPotentialCalls()
        {
            _priorityQueue = new List<PotentialCall>();
        }

        private void AddPotentialCall(PotentialCall potentialCall)
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

        public void AddCall(ICallObject callObject)
        {
            if (callObject.GetType() == typeof(PotentialCall))
            {
                AddPotentialCall((PotentialCall)callObject);
                return;
            }

            throw new ArgumentException("Invalid type");
        }

        public void Clear()
        {
            _priorityQueue.Clear();
        }

        public void RemoveByPlayer(Player player)
        {
            for (int i = _priorityQueue.Count - 1; i >= 0; i--)
            {
                if (_priorityQueue[i].GetPlayerMakingCall() == player)
                {
                    _priorityQueue.RemoveAt(i);
                }
            }
        }

        public void RemoveByPriority(int priority)
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