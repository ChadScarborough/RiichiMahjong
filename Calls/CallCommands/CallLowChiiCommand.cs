using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallLowChiiCommand : CallCommand
    {
       
        public CallLowChiiCommand(Player playerMakingCall, TileObject calledTile) : base(playerMakingCall, calledTile)
        {
            
        }
        
        public override void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, LOW_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() - (i + 1), _calledTile.GetSuit());
                _handMakingCall.RemoveCopyOfTile(tempTile);
            }
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}