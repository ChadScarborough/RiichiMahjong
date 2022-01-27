using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Hands.CompleteHands
{
    public class ThirteenOrphansCompleteHand : ICompleteHand
    {
        private List<ICompleteHandComponent> _completeHand;
        private CompleteHandWaitType _waitType;
        
        public ThirteenOrphansCompleteHand(ITenpaiHand tenpaiHand, TileObject tile)
        {
            _completeHand = tenpaiHand.GetComponents();
            ICompleteHandComponent drawTile = CreateCompleteHandComponent(tile, DRAW_TILE);
            _completeHand.Add(drawTile);
            _waitType = tenpaiHand.GetWaitType();
        }

        public List<ICompleteHandComponent> GetCompleteHand()
        {
            return _completeHand;
        }

        public CompleteHandType GetCompleteHandType()
        {
            return THIRTEEN_ORPHANS;
        }

        public CompleteHandWaitType GetWaitType()
        {
            return _waitType;
        }
    }
}
