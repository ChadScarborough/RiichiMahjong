using RMU.Globals;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallHighChiiCommand : CallCommand
{
    public CallHighChiiCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.OpenHand();
        _handMakingCall.CreateOpenMeld(_calledTile, HIGH_CHII);
        Tile oneAbove = GetTileAbove(_calledTile);
        Tile twoAbove = GetTileTwoAbove(_calledTile);
        _handMakingCall.RemoveExactCopyOfTile(oneAbove);
        _handMakingCall.RemoveExactCopyOfTile(twoAbove);
    }

    public override int GetPriority()
    {
        return 1;
    }
}