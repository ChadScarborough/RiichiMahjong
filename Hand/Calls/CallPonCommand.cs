using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hand.Calls
{
    public class CallPonCommand : ICallCommand
    {
        private readonly TileObject _calledTile;
        private readonly AbstractHand _handMakingCall;
        
        public CallPonCommand(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            _handMakingCall.CreateOpenMeld(_calledTile, PON);
            for (int i = 0; i < 2; i++)
            {
                _handMakingCall.RemoveCopyOfTile(_calledTile);
            }
        }
    }
}