using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Hands.CompleteHands
{
    public class SevenPairsCompleteHand : ICompleteHand
    {
        private List<ICompleteHandComponent> _completeHand;

        public SevenPairsCompleteHand(ITenpaiHand tenpaiHand, TileObject tile)
        {
            _completeHand = tenpaiHand.GetComponents();
            ICompleteHandComponent drawTile = CreateCompleteHandComponent(tile, DRAW_TILE);
            _completeHand.Add(drawTile);
        }

        public List<ICompleteHandComponent> GetCompleteHand()
        {
            return _completeHand;
        }

        public Enums.CompleteHandWaitType GetWaitType()
        {
            return Enums.PAIR_WAIT;
        }

        public Enums.CompleteHandType GetCompleteHandType()
        {
            return Enums.SEVEN_PAIRS;
        }
    }
}
