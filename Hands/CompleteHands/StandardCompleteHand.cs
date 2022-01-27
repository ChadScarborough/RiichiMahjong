using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Hands.CompleteHands
{
    public class StandardCompleteHand : ICompleteHand
    {
        private readonly List<ICompleteHandComponent> _completeHand;
        private readonly CompleteHandWaitType _waitType;

        public StandardCompleteHand(ITenpaiHand tenpaiHand, TileObject drawTile)
        {
            _completeHand = tenpaiHand.GetComponents();
            _completeHand.Add(CreateCompleteHandComponent(drawTile, DRAW_TILE));
            _waitType = tenpaiHand.GetWaitType();
        }

        public List<ICompleteHandComponent> GetCompleteHand()
        {
            return _completeHand;
        }

        public CompleteHandWaitType GetWaitType()
        {
            return _waitType;
        }

        public CompleteHandType GetCompleteHandType()
        {
            return STANDARD;
        }
    }
}
