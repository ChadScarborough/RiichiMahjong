using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallPonCommand : CallCommand
{
    public CallPonCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        _handMakingCall.CreateOpenMeld(_calledTile, PON);
        for (int i = 0; i < 2; i++)
        {
            _handMakingCall.RemoveCopyOfTile(_calledTile);
        }
    }

    public override int GetPriority()
    {
        return 2;
    }
}