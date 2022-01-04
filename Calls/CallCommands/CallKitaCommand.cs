using RMU.Hand;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;
using static RMU.Globals.StandardTileList;

namespace RMU.Calls.CallCommands
{
    public class CallKitaCommand : ICallCommand
    {
        private readonly AbstractHand _handMakingCall;
        private readonly TileObject _calledTile;
        
        public CallKitaCommand(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            _handMakingCall.CreateOpenMeld(_calledTile, KITA);
            if (AreTilesEquivalent(_handMakingCall.GetDrawTile(), NORTH_WIND))
            {
                _handMakingCall.RemoveDrawTile();
                return;
            }

            foreach (TileObject tile in _handMakingCall.GetClosedTiles())
            {
                if (AreTilesEquivalent(tile, NORTH_WIND))
                {
                    _handMakingCall.RemoveCopyOfTile(tile);
                    return;
                }
            }
        }

        public int GetPriority()
        {
            return 0;
        }
    }
}