using RMU.Globals;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallLowChiiCommand : CallCommand
    {
       
        public CallLowChiiCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
        {
            
        }
        
        public override void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, LOW_CHII);
            Tile oneBelow = Functions.GetTileBelow(_calledTile);
            Tile twoBelow = Functions.GetTileTwoBelow(_calledTile);
            _handMakingCall.RemoveCopyOfTile(oneBelow);
            _handMakingCall.RemoveCopyOfTile(twoBelow);
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}