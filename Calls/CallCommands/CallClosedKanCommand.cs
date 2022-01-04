using RMU.Hand;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMU.Calls.CallCommands
{
    public class CallClosedKanCommand : ICallCommand
    {
        private readonly AbstractHand _handMakingCall;
        private readonly TileObject _calledTile;

        public CallClosedKanCommand(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            _handMakingCall.CreateOpenMeld(_calledTile, CLOSED_KAN_MELD);
            for (int i = 0; i < 4; i++)
            {
                _handMakingCall.RemoveCopyOfTile(_calledTile);
            }
            if (AreTilesEquivalent(_handMakingCall.GetDrawTile(), _calledTile))
            {
                _handMakingCall.RemoveDrawTile();
            }
        }

        public int GetPriority()
        {
            return 2;
        }
    }
}