using RMU.Calls.CallCommands;
using RMU.Games;
using RMU.Hands;
using RMU.Tiles;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMU.Players;

public abstract class FourPlayerAbstractPlayer : Player
{
    private bool _canLowChii;
    private bool _canLowChiiRed;
    private bool _canMidChii;
    private bool _canMidChiiRed;
    private bool _canHighChii;
    private bool _canHighChiiRed;

    protected FourPlayerAbstractPlayer(Wind seatWind, Hand hand, AbstractGame game) : base(seatWind, hand, game)
    {
    }

    private bool CanLowChii()
    {
        if (IsActivePlayer())
            return false;
        return _canLowChii;
    }

    private bool CanLowChiiRed()
    {
        if (IsActivePlayer())
            return false;
        return _canLowChiiRed;
    }

    private bool CanMidChii()
    {
        if (IsActivePlayer())
            return false;
        return _canMidChii;
    }

    private bool CanMidChiiRed()
    {
        if (IsActivePlayer())
            return false;
        return _canMidChiiRed;
    }

    private bool CanHighChii()
    {
        if (IsActivePlayer())
            return false;
        return _canHighChii;
    }

    private bool CanHighChiiRed()
    {
        if (IsActivePlayer())
            return false;
        return _canHighChiiRed;
    }

    public void CallLowChii(Tile calledTile)
    {
        if (CanLowChii())
        {
            CallCommand callLowChii = new CallLowChiiCommand(this, calledTile);
            MakeCall(callLowChii);
            UpdateAvailableCalls();
        }
    }

    public void CallLowChiiRed(Tile calledTile)
    {
        if (CanLowChiiRed())
        {
            CallCommand callLowChiiRed = new CallLowChiiRedCommand(this, calledTile);
            MakeCall(callLowChiiRed);
            UpdateAvailableCalls();
        }
    }

    public void CallMidChii(Tile calledTile)
    {
        if (CanMidChii())
        {
            CallCommand callMidChii = new CallMidChiiCommand(this, calledTile);
            MakeCall(callMidChii);
            UpdateAvailableCalls();
        }
    }

    public void CallMidChiiRed(Tile calledTile)
    {
        if (CanMidChiiRed())
        {
            CallCommand callMidChiiRed = new CallMidChiiRedCommand(this, calledTile);
            MakeCall(callMidChiiRed);
            UpdateAvailableCalls();
        }
    }

    public void CallHighChii(Tile calledTile)
    {
        if (CanHighChii())
        {
            CallCommand callHighChii = new CallHighChiiCommand(this, calledTile);
            MakeCall(callHighChii);
            UpdateAvailableCalls();
        }
    }

    public void CallHighChiiRed(Tile calledTile)
    {
        if (CanHighChiiRed())
        {
            CallCommand callHighChiiRed = new CallHighChiiRedCommand(this, calledTile);
        }
    }

    public override void GeneratePotentialDiscardCalls(Tile lastTile)
    {
        base.GeneratePotentialDiscardCalls(lastTile);
        if (_game.GetActivePlayer() != this.GetPlayerOnLeft())
            return;
        GeneratePotentialLowChiiCall(this, _priorityQueueForPotentialCalls, lastTile);
        GeneratePotentialMidChiiCall(this, _priorityQueueForPotentialCalls, lastTile);
        GeneratePotentialHighChiiCall(this, _priorityQueueForPotentialCalls, lastTile);
    }

    public override void UpdateAvailableCalls()
    {
        base.UpdateAvailableCalls();
        _canLowChii = _availablePotentialCalls.CanCallLowChii();
        _canLowChiiRed = _availablePotentialCalls.CanCallLowChiiRed();
        _canMidChii = _availablePotentialCalls.CanCallMidChii();
        _canMidChiiRed = _availablePotentialCalls.CanCallMidChiiRed();
        _canHighChii = _availablePotentialCalls.CanCallHighChii();
        _canHighChiiRed = _availablePotentialCalls.CanCallHighChiiRed();
        if (CanLowChii())
            InvokeOnCanLowChii();
        if (CanLowChiiRed())
            InvokeOnCanLowChiiRed();
        if (CanMidChii())
            InvokeOnCanMidChii();
        if (CanMidChiiRed())
            InvokeOnCanMidChiiRed();
        if (CanHighChii())
            InvokeOnCanHighChii();
        if (CanHighChiiRed())
            InvokeOnCanHighChiiRed();
    }
}