using RMU.Globals;
using RMU.Players;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;

namespace RMU.Calls.CallCommands;

public sealed class CallMidChiiRedCommand : CallCommand
{

    public CallMidChiiRedCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.OpenHand();
        _handMakingCall.CreateOpenMeld(_calledTile, MID_CHII_RED);
        Tile oneBelow = GetTileBelow(_calledTile);
        if (oneBelow.GetValue() == 5)
            oneBelow = new RedFiveDecorator(oneBelow);
        Tile oneAbove = GetTileTwoBelow(_calledTile);
        if (oneAbove.GetValue() == 5)
            oneAbove = new RedFiveDecorator(oneAbove);
        _handMakingCall.RemoveExactCopyOfTile(oneBelow);
        _handMakingCall.RemoveExactCopyOfTile(oneAbove);
    }

    public override int GetPriority()
    {
        return 1;
    }
}