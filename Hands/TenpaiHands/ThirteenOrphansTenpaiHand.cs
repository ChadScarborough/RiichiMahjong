using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Hands.TenpaiHands
{
    public class ThirteenOrphansTenpaiHand : ITenpaiHand
    {
        private readonly List<TileObject> _waits;
        
        public List<ICompleteHandComponent> GetComponents()
        {
            throw new System.NotImplementedException();
        }

        public List<TileObject> GetWaits()
        {
            return _waits;
        }
    }
}