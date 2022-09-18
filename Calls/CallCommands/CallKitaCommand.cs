using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallKitaCommand : CallCommand
{
    public CallKitaCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.CreateOpenMeld(_calledTile, KITA);
        if (AreTilesEquivalent(_handMakingCall.GetDrawTile(), NORTH_WIND))
        {
            _handMakingCall.RemoveDrawTile();
            return;
        }

        foreach (Tile tile in _handMakingCall.GetClosedTiles())
        {
            if (AreTilesEquivalent(tile, NORTH_WIND))
            {
                _handMakingCall.RemoveCopyOfTile(tile);
                return;
            }
        }
    }

    public override int GetPriority()
    {
        return 0;
    }
}