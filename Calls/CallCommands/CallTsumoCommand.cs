using System;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands
{
    public class CallTsumoCommand : CallCommand
    {
        public CallTsumoCommand(Player playerMakingCall, TileObject calledTile) : base(playerMakingCall, calledTile)
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
}