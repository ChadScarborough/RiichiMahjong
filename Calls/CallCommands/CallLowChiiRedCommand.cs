using RMU.Globals;
using RMU.Players;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;

namespace RMU.Calls.CallCommands;

public sealed class CallLowChiiRedCommand : CallCommand
{

    public CallLowChiiRedCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.OpenHand();
        _handMakingCall.CreateOpenMeld(_calledTile, LOW_CHII_RED);
        Tile oneBelow = GetTileBelow(_calledTile);
        if (oneBelow.GetValue() == 5)
            oneBelow = new RedFiveDecorator(oneBelow);
        Tile twoBelow = GetTileTwoBelow(_calledTile);
        if (twoBelow.GetValue() == 5)
            twoBelow = new RedFiveDecorator(twoBelow);
        _handMakingCall.RemoveExactCopyOfTile(oneBelow);
        _handMakingCall.RemoveExactCopyOfTile(twoBelow);
    }

    public override int GetPriority()
    {
        return 1;
    }
}