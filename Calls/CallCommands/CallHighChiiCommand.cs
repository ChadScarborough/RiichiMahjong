using RMU.Globals;
using RMU.Hands;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallHighChiiCommand : CallCommand
    {
        public CallHighChiiCommand(Player playerMakingCall, TileObject calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, HIGH_CHII);
            TileObject oneAbove = Functions.GetTileAbove(_calledTile);
            TileObject twoAbove = Functions.GetTileTwoAbove(_calledTile);
            _handMakingCall.RemoveCopyOfTile(oneAbove);
            _handMakingCall.RemoveCopyOfTile(twoAbove);
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}