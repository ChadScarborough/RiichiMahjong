using RMU.Tiles;
using RMU.Calls.CallCommands;
using RMU.Hands;
using static RMU.Globals.Enums;

namespace RMU.Players
{
    public class ThreePlayerAbstractPlayer : Player
    {
        private readonly AbstractThreePlayerHand _hand;
        
        protected ThreePlayerAbstractPlayer(Wind seatWind, AbstractThreePlayerHand hand) : base(seatWind, hand)
        {
            _hand = hand;
        }

        public void CallKita(TileObject calledTile)
        {
            CallCommand callKita = new CallKitaCommand(this, calledTile);
            callKita.Execute();
        }
    }
}