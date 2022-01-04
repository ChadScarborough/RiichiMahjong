using RMU.Hand;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallOpenKan1Command : ICallCommand
    {
        private readonly AbstractHand _handMakingCall;
        private readonly TileObject _calledTile;

        public CallOpenKan1Command(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, OPEN_KAN_1);
            for (int i = 0; i < 3; i++)
            {
                _handMakingCall.RemoveCopyOfTile(_calledTile);
            }
        }

        public int GetPriority()
        {
            return 2;
        }
    }
}