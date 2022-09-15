using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Hands.TenpaiHands
{
    public abstract class StandardTenpaiHand : ITenpaiHand
    {
        private readonly List<ICompleteHandComponent> _components;
        protected List<Tile> _waits;

        protected StandardTenpaiHand(List<ICompleteHandComponent> components)
        {
            _components = components;
        }
        
        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
        }

        public List<Tile> GetWaits()
        {
            return _waits;
        }

        public abstract Enums.CompleteHandWaitType GetWaitType();
        public Enums.CompleteHandType GetHandType()
        {
            return Enums.STANDARD;
        }
    }
}