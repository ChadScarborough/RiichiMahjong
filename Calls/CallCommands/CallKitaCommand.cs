using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;
using static RMU.Globals.StandardTileList;

namespace RMU.Calls.CallCommands
{
    public class CallKitaCommand : CallCommand
    {
        public CallKitaCommand(Player playerMakingCall, TileObject calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
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

        public override int GetPriority()
        {
            return 0;
        }
    }
}