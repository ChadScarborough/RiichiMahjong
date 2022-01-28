using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public abstract class ThirteenOrphansTenpaiHand : ITenpaiHand
    {
        protected List<TileObject> _waits;
        protected readonly List<ICompleteHandComponent> _components;

        protected ThirteenOrphansTenpaiHand(List<ICompleteHandComponent> components)
        {
            _components = components;
        }
        
        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
        }

        public virtual List<TileObject> GetWaits()
        {
            return _waits;
        }

        public abstract CompleteHandWaitType GetWaitType();
    }
}