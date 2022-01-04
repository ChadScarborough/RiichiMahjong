using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMU.Hand.Calls
{
    public class CallOpenKan2Command : ICallCommand
    {
        private readonly AbstractHand _handMakingCall;
        private readonly TileObject _calledTile;

        public CallOpenKan2Command(AbstractHand handMakingCall, TileObject calledTile)
        {
            _handMakingCall = handMakingCall;
            _calledTile = calledTile;
        }
        
        public void Execute()
        {
            foreach(OpenMeld openMeld in _handMakingCall.GetOpenMelds())
            {
                if(SuccessfullyTurnedPonIntoOpenKan2(_calledTile, openMeld))
                {
                    return;
                }
            }
        }
        
        private bool SuccessfullyTurnedPonIntoOpenKan2(TileObject calledTile, OpenMeld openMeld)
        {
            TileObject openMeldTile = openMeld.GetTiles()[0];
            if (openMeld.GetMeldType() == PON && AreTilesEquivalent(openMeldTile, calledTile))
            {
                return ChangePonToOpenKan2(calledTile, openMeld);
            }
            return false;
        }
        
        private bool ChangePonToOpenKan2(TileObject calledTile, OpenMeld openMeld)
        {
            openMeld.SetMeldType(OPEN_KAN_2);
            openMeld.AddTile(calledTile);
            if (AreTilesEquivalent(_handMakingCall.GetDrawTile(), calledTile))
            {
                _handMakingCall.RemoveDrawTile();
                return true;
            }
            foreach (TileObject tile in _handMakingCall.GetClosedTiles())
            {
                if (RemovedTileFromHand(tile)) 
                { 
                    return true; 
                }
            }
            return false;
        }
        
        private bool RemovedTileFromHand(TileObject tile)
        {
            if (AreTilesEquivalent(_handMakingCall.GetDrawTile(), tile))
            {
                _handMakingCall.GetClosedTiles().Remove(tile);
                return true;
            }
            return false;
        }
    }
}