namespace RMU.Calls.CallCommands
{
    public interface ICallCommand
    {
        void Execute();

        int GetPriority();
    }
}