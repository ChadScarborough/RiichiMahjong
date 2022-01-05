using System;
using RMU.Players;
using RMU.Tiles;

namespace RMU.Calls.CallCommands
{
    public class CallRonCommand : CallCommand
    {
        public CallRonCommand(Player playerMakingCall, TileObject calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
        {
            Console.WriteLine("Ron!"); //Obviously not the final code
        }

        public override int GetPriority()
        {
            return 3;
        }
    }
}