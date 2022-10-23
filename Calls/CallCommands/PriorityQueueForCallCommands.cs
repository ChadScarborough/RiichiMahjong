using RMU.Games;
using RMU.Players;
using System;
using System.Collections.Generic;

namespace RMU.Calls.CallCommands;

public sealed class PriorityQueueForCallCommands : IPriorityQueue
{
    private readonly List<CallCommand> _priorityQueue;
    private readonly AbstractGame _game;

    public PriorityQueueForCallCommands(AbstractGame game)
    {
        _priorityQueue = new List<CallCommand>();
        _game = game;
    }

    private void AddCallCommand(CallCommand callCommand)
    {
        for (int i = 0; i < _priorityQueue.Count; i++)
        {
            if (callCommand.GetPriority() >= _priorityQueue[i].GetPriority())
            {
                _priorityQueue.Insert(i, callCommand);
                return;
            }
        }
        _priorityQueue.Add(callCommand);
    }

    public void AddCall(ICallObject callObject)
    {
        Type type = callObject.GetType();
        if (type.IsSubclassOf(typeof(CallCommand)))
        {
            AddCallCommand((CallCommand)callObject);
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

    public void Execute()
    {
        if (_priorityQueue.Count == 0)
        {
            _game.NextPlayer();
            return;
        }
        if (_priorityQueue[0].GetPriority() == 3)
        {
            foreach (CallCommand command in _priorityQueue)
            {
                if (command.GetPriority() == 3)
                {
                    command.Execute();
                    continue;
                }
                command.Execute();
                Clear();
                return;
            }
            Clear();
            return;
        }
        _priorityQueue[0].Execute();
        Clear();
    }
}