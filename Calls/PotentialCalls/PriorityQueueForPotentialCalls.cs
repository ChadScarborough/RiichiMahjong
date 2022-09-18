using RMU.Players;
using System;
using System.Collections.Generic;

namespace RMU.Calls.PotentialCalls;

public sealed class PriorityQueueForPotentialCalls : IPriorityQueue
{
    private readonly List<PotentialCall> _priorityQueue;

    public PriorityQueueForPotentialCalls()
    {
        _priorityQueue = new List<PotentialCall>();
    }

    public bool IsEmpty()
    {
        return _priorityQueue.Count == 0;
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
        }
        _priorityQueue.Add(potentialCall);
    }

    public void AddCall(ICallObject callObject)
    {
        Type type = callObject.GetType();
        if (type.IsSubclassOf(typeof(PotentialCall)))
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

    public List<PotentialCall> GetCallsByPlayer(Player player)
    {
        List<PotentialCall> outputList = new();
        foreach (PotentialCall call in _priorityQueue)
        {
            if (call.GetPlayerMakingCall() == player)
            {
                outputList.Add(call);
            }
        }

        return outputList;
    }
}