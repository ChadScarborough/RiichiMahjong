using RMU.Tiles;
using RMU.Calls.CallCommands;
using RMU.Hands;
using RMU.Games;
using static RMU.Globals.Enums;

namespace RMU.Players
{
    public class ThreePlayerAbstractPlayer : Player
    {
        private readonly AbstractThreePlayerHand _hand;
        
        protected ThreePlayerAbstractPlayer(Wind seatWind, AbstractThreePlayerHand hand, AbstractGame game) : base(seatWind, hand, game)
        {
            _hand = hand;
        }

        public void CallKita(Tile calledTile)
        {
            CallCommand callKita = new CallKitaCommand(this, calledTile);
            callKita.Execute();
        }
    }
}