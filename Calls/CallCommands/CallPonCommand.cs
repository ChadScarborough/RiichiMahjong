using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallPonCommand : CallCommand
    {
        public CallPonCommand(Player playerMakingCall, TileObject calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
        {
            _handMakingCall.CreateOpenMeld(_calledTile, PON);
            for (int i = 0; i < 2; i++)
            {
                _handMakingCall.RemoveCopyOfTile(_calledTile);
            }
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}