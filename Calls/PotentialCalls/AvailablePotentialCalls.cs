using RMU.Players;
using System.Collections.Generic;

namespace RMU.Calls.PotentialCalls;

public sealed class AvailablePotentialCalls
{
    private readonly Player _player;
    private readonly PriorityQueueForPotentialCalls _queue;
    private List<PotentialCall> _availableCalls;

    public AvailablePotentialCalls(Player player, PriorityQueueForPotentialCalls queue)
    {
        _player = player;
        _queue = queue;
    }

    public void UpdateAvailableCalls()
    {
        _availableCalls = _queue.GetCallsByPlayer(_player);
    }

    private bool AvailableCallsContainsCallOfGivenType(PotentialCallType callType)
    {
        foreach (PotentialCall call in _availableCalls)
        {
            if (call.GetCallType() == callType)
            {
                return true;
            }
        }

        return false;
    }

    public bool CanCallPon()
    {
        return AvailableCallsContainsCallOfGivenType(PON_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallOpenKan1()
    {
        return AvailableCallsContainsCallOfGivenType(OPEN_KAN_1_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallLowChii()
    {
        return AvailableCallsContainsCallOfGivenType(LOW_CHII_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallLowChiiRed()
    {
        return AvailableCallsContainsCallOfGivenType(LOW_CHII_RED_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallMidChii()
    {
        return AvailableCallsContainsCallOfGivenType(MID_CHII_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallMidChiiRed()
    {
        return AvailableCallsContainsCallOfGivenType(MID_CHII_RED_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallHighChii()
    {
        return AvailableCallsContainsCallOfGivenType(HIGH_CHII_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallHighChiiRed()
    {
        return AvailableCallsContainsCallOfGivenType(HIGH_CHII_RED_POTENTIAL_CALL_TYPE);
    }

    public bool CanCallRon()
    {
        return AvailableCallsContainsCallOfGivenType(RON_POTENTIAL_CALL_TYPE);
    }
}