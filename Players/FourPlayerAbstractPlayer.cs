using RMU.Calls.CallCommands;
using RMU.Games;
using RMU.Hands;
using RMU.Tiles;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMU.Players;

public abstract class FourPlayerAbstractPlayer : Player
{
    private bool _canLowChii;
    private bool _canMidChii;
    private bool _canHighChii;

    protected FourPlayerAbstractPlayer(Wind seatWind, Hand hand, AbstractGame game) : base(seatWind, hand, game)
    {
    }

    private bool CanLowChii()
    {
        if (IsActivePlayer())
            return false;
        return _canLowChii;
    }

    private bool CanMidChii()
    {
        if (IsActivePlayer())
            return false;
        return _canMidChii;
    }

    private bool CanHighChii()
    {if (IsActivePlayer())
            return false;
        return _canHighChii;
    }

    public void CallLowChii(Tile calledTile)
    {
        //UpdateAvailableCalls();
        if (CanLowChii())
        {
            CallCommand callLowChii = new CallLowChiiCommand(this, calledTile);
            MakeCall(callLowChii);
            UpdateAvailableCalls();
        }
    }

    public void CallMidChii(Tile calledTile)
    {
        //UpdateAvailableCalls();
        if (CanMidChii())
        {
            CallCommand callMidChii = new CallMidChiiCommand(this, calledTile);
            MakeCall(callMidChii);
            UpdateAvailableCalls();
        }
    }

    public void CallHighChii(Tile calledTile)
    {
        //UpdateAvailableCalls();
        if (CanHighChii())
        {
            CallCommand callHighChii = new CallHighChiiCommand(this, calledTile);
            MakeCall(callHighChii);
            UpdateAvailableCalls();
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
        _canMidChii = _availablePotentialCalls.CanCallMidChii();
        _canHighChii = _availablePotentialCalls.CanCallHighChii();
        if (CanLowChii())
            InvokeOnCanLowChii();
        if (CanMidChii())
            InvokeOnCanMidChii();
        if (CanHighChii())
            InvokeOnCanHighChii();
    }
}