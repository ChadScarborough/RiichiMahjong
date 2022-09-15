using System;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Calls.CallCommands
{
    public class CallOpenKan1Command : CallCommand
    {
        public CallOpenKan1Command(Player playerMakingCall, Tile calledTile) : base(playerMakingCall, calledTile)
        {

        }
        
        public override void Execute()
        {
            _handMakingCall.OpenHand();
            _handMakingCall.CreateOpenMeld(_calledTile, OPEN_KAN_1);
            for (int i = 0; i < 3; i++)
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