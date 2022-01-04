using System;

namespace RMU.Calls.CallCommands
{
    public class CallRiichiCommand : ICallCommand
    {
        public void Execute()
        {
            Console.WriteLine("Riichi!"); //Obviously not the final code
        }

        public int GetPriority()
        {
            return 0;
        }
    }
}