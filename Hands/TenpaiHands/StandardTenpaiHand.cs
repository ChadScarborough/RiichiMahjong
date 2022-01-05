using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Hands.TenpaiHands
{
    public class StandardTenpaiHand : ITenpaiHand
    {
        List<ICompleteHandComponent> _components;

        public StandardTenpaiHand(List<ICompleteHandComponent> components)
        {
            _components = components;

        }

        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
        }

        //public List<TileObject> GetWaits()
        //{
            
        //}
    }
}
