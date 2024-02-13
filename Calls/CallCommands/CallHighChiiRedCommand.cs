using RMU.Players;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;

namespace RMU.Calls.CallCommands;

public sealed class CallHighChiiRedCommand : CallCommand
{
    public CallHighChiiRedCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.OpenHand();
        _handMakingCall.CreateOpenMeld(_calledTile, HIGH_CHII_RED);
        Tile oneAbove = GetTileAbove(_calledTile);
        if (oneAbove.GetValue() == 5)
            oneAbove = new RedFiveDecorator(oneAbove);
        Tile twoAbove = GetTileTwoAbove(_calledTile);
        if (twoAbove.GetValue() == 5)
            twoAbove = new RedFiveDecorator(twoAbove);
        _handMakingCall.RemoveExactCopyOfTile(oneAbove);
        _handMakingCall.RemoveExactCopyOfTile(twoAbove);
    }

    public override int GetPriority()
    {
        return 1;
    }
}