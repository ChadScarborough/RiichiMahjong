using RMU.Globals;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallLowChiiCommand : CallCommand
{

    public CallLowChiiCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.OpenHand();
        _handMakingCall.CreateOpenMeld(_calledTile, LOW_CHII);
        Tile oneBelow = GetTileBelow(_calledTile);
        Tile twoBelow = GetTileTwoBelow(_calledTile);
        _handMakingCall.RemoveExactCopyOfTile(oneBelow);
        _handMakingCall.RemoveExactCopyOfTile(twoBelow);
    }

    public override int GetPriority()
    {
        return 1;
    }
}