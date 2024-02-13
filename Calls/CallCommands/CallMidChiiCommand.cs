using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallMidChiiCommand : CallCommand
{
    public CallMidChiiCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.OpenHand();
        _handMakingCall.CreateOpenMeld(_calledTile, MID_CHII);
        Tile tileAbove = GetTileAbove(_calledTile);
        Tile tileBelow = GetTileBelow(_calledTile);
        _handMakingCall.RemoveExactCopyOfTile(tileAbove);
        _handMakingCall.RemoveExactCopyOfTile(tileBelow);
    }

    public override int GetPriority()
    {
        return 1;
    }
}