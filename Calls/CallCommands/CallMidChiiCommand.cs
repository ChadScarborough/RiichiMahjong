using RMU.Globals;
using RMU.Hands;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallMidChiiCommand : CallCommand
    {
        public CallMidChiiCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, MID_CHII);
            Tile tileAbove = Functions.GetTileAbove(_calledTile);
            Tile tileBelow = Functions.GetTileBelow(_calledTile);
            _handMakingCall.RemoveCopyOfTile(tileAbove);
            _handMakingCall.RemoveCopyOfTile(tileBelow);
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}