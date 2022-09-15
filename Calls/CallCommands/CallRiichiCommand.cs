using System;
using RMU.Players;
using RMU.Hands;
using RMU.Tiles;

namespace RMU.Calls.CallCommands
{
    public class CallRiichiCommand : CallCommand
    {
        public CallRiichiCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
        {
            Console.WriteLine("Riichi!"); //Obviously not the final code
        }

        public override int GetPriority()
        {
            return 0;
        }
    }
}