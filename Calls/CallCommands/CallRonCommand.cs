using RMU.Games;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands;

public sealed class CallRonCommand : CallCommand
{
    public CallRonCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        Player player = GetPlayerMakingCall();
        AbstractGame game = player.GetGame();
        game.CallRon(player, player.GetYaku());
    }

    public override int GetPriority()
    {
        return 3;
    }
}