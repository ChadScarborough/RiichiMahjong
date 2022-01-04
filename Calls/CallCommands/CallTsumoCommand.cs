using System;

namespace RMU.Calls.CallCommands
{
    public class CallTsumoCommand : ICallCommand
    {
        public void Execute()
        {
            Console.WriteLine("Tsumo!"); //Obviously not the final code
        }

        public int GetPriority()
        {
            return 0;
        }
    }
}