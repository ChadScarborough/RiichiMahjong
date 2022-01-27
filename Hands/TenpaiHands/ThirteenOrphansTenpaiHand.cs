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
        private readonly List<ICompleteHandComponent> _components;

        public ThirteenOrphansTenpaiHand(List<ICompleteHandComponent> components)
        {
            _components = components;
            //TODO: Add logic to actually determine wait (may involve creating a separate class)
        }
        
        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
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