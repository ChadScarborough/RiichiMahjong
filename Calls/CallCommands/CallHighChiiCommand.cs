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
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() + (i + 1), _calledTile.GetSuit());
                _handMakingCall.RemoveCopyOfTile(tempTile);
            }
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}