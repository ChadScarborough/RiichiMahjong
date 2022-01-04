using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hand.Calls
{
    public class CallMidChiiCommand : ICallCommand
    {
        private readonly AbstractHand _handMakingCall;
        private readonly TileObject _calledTile;
        
        public CallMidChiiCommand(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, MID_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() - ((2 * i) - 1), _calledTile.GetSuit());
                _handMakingCall.RemoveCopyOfTile(tempTile);
            }
        }
    }
}