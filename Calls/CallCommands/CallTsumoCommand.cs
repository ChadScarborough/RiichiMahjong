using RMU.Players;
using RMU.Tiles;
using System;

namespace RMU.Calls.CallCommands;

public sealed class CallTsumoCommand : CallCommand
{
    public CallTsumoCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
    {

    }

    public override void Execute()
    {
        Console.WriteLine("Tsumo!"); //Obviously not the final code
    }

    public override int GetPriority()
    {
        return 0;
    }
}