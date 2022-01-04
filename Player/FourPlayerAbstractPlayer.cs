using RMU.Hand;
using RMU.Calls.CallCommands;
using RMU.Tiles;

namespace RMU.Player
{
    public class FourPlayerAbstractPlayer : AbstractPlayer
    {
        private readonly AbstractFourPlayerHand _hand;
        
        protected FourPlayerAbstractPlayer(ISeatWindState seatWind, AbstractFourPlayerHand hand) : base(seatWind, hand)
        {
            _hand = hand;
        }

        public void CallLowChii(TileObject calledTile)
        {
            ICallCommand callLowChii = new CallLowChiiCommand(_hand, calledTile);
            callLowChii.Execute();
        }

        public void CallMidChii(TileObject calledTile)
        {
            ICallCommand callMidCii = new CallMidChiiCommand(_hand, calledTile);
            callMidCii.Execute();
        }

        public void CallHighChii(TileObject calledTile)
        {
            ICallCommand callHighChii = new CallHighChiiCommand(_hand, calledTile);
            callHighChii.Execute();
        }
    }
}