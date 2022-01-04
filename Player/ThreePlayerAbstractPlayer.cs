using RMU.Hand;
using RMU.Tiles;
using RMU.Calls.CallCommands;

namespace RMU.Player
{
    public class ThreePlayerAbstractPlayer : AbstractPlayer
    {
        private readonly AbstractThreePlayerHand _hand;
        
        protected ThreePlayerAbstractPlayer(ISeatWindState seatWind, AbstractThreePlayerHand hand) : base(seatWind, hand)
        {
            _hand = hand;
        }

        public void CallKita(TileObject calledTile)
        {
            ICallCommand callKita = new CallKitaCommand(_hand, calledTile);
            callKita.Execute();
        }
    }
}