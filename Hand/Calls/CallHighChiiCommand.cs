using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hand.Calls
{
    public class CallHighChiiCommand : ICallCommand
    {
        private readonly AbstractHand _handMakingCall;
        private readonly TileObject _calledTile;

        public CallHighChiiCommand(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, HIGH_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() + (i + 1), _calledTile.GetSuit());
                _handMakingCall.RemoveCopyOfTile(tempTile);
            }
        }
    }
}