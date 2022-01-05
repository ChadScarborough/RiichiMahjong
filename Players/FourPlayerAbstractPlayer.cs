using RMU.Calls.CallCommands;
using RMU.Hands;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Players
{
    public class FourPlayerAbstractPlayer : Player
    {
        private readonly AbstractFourPlayerHand _hand;
        
        protected FourPlayerAbstractPlayer(Wind seatWind, AbstractFourPlayerHand hand) : base(seatWind, hand)
        {
            _hand = hand;
        }

        public void CallLowChii(TileObject calledTile)
        {
            CallCommand callLowChii = new CallLowChiiCommand(this, calledTile);
            MakeCall(callLowChii);
        }

        public void CallMidChii(TileObject calledTile)
        {
            CallCommand callMidChii = new CallMidChiiCommand(this, calledTile);
            MakeCall(callMidChii);
        }

        public void CallHighChii(TileObject calledTile)
        {
            CallCommand callHighChii = new CallHighChiiCommand(this, calledTile);
            MakeCall(callHighChii);
        }
    }
}