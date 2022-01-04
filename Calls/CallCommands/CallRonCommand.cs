using System;
using RMU.Hand;
using RMU.Tiles;

namespace RMU.Calls.CallCommands
{
    public class CallRonCommand : ICallCommand
    {
        private readonly AbstractHand _hand;
        private readonly TileObject _calledTile;
        
        public CallRonCommand(AbstractHand hand, TileObject calledTile)
        {
            _hand = hand;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            Console.WriteLine("Ron!"); //Obviously not the final code
        }

        public int GetPriority()
        {
            return 3;
        }
    }
}