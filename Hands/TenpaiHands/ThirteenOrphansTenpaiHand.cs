using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public class ThirteenOrphansTenpaiHand : ITenpaiHand
    {
        private readonly List<TileObject> _waits;

        public ThirteenOrphansTenpaiHand(List<ICompleteHandComponent> components)
        {
            //TODO: Add logic to actually determine wait (may involve creating a separate class)
        }
        
        public List<ICompleteHandComponent> GetComponents()
        {
            throw new System.NotImplementedException();
        }

        public List<TileObject> GetWaits()
        {
            return _waits;
        }

        public Enums.CompleteHandWaitType GetWaitType()
        {
            return THIRTEEN_WAIT; 
        }
    }
}