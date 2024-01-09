using Godot;
using RMU.Calls.CreateMeldBehaviours;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallOpenKan2Command : CallCommand
{
    public CallOpenKan2Command(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        GD.Print("Called execute function");
        foreach (OpenMeld openMeld in _handMakingCall.GetOpenMelds())
        {
            GD.Print($"{openMeld.GetCalledTile()} - {openMeld.GetMeldType()}");
            if (SuccessfullyTurnedPonIntoOpenKan2(_calledTile, openMeld))
            {
                GD.Print("Successfully called open kan 2");
                _playerMakingCall.DrawTileFromDeadWall();
                _playerMakingCall.GetGame().GetDeadWall().RevealDoraTile();
                return;
            }
        }
    }

    private bool SuccessfullyTurnedPonIntoOpenKan2(Tile calledTile, OpenMeld openMeld)
    {
        Tile openMeldTile = openMeld.GetCalledTile();
        return openMeld.GetMeldType() ==
            PON
            && AreTilesEquivalent(openMeldTile, calledTile)
            && ChangePonToOpenKan2(calledTile, openMeld);
    }

    private bool ChangePonToOpenKan2(Tile calledTile, OpenMeld openMeld)
    {
        openMeld.SetMeldType(OPEN_KAN_2);
        openMeld.AddTile(calledTile);
        if (AreTilesEquivalent(_handMakingCall.GetDrawTile(), calledTile))
        {
            _handMakingCall.RemoveDrawTile();
            return true;
        }
        foreach (Tile tile in _handMakingCall.GetClosedTiles())
        {
            if (RemovedTileFromHand(tile))
            {
                return true;
            }
        }
        return false;
    }

    private bool RemovedTileFromHand(Tile tile)
    {
        if (AreTilesEquivalent(_calledTile, tile))
        {
            _ = _handMakingCall.GetClosedTiles().Remove(tile);
            return true;
        }
        return false;
    }

    public override int GetPriority()
    {
        return 0;
    }
}