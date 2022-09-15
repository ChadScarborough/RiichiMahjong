using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMU.Calls.CallCommands
{
    public class CallClosedKanCommand : CallCommand
    {
        public CallClosedKanCommand(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
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

        public override int GetPriority()
        {
            return 2;
        }
    }
}