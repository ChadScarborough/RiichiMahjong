using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using static RMU.Globals.Enums;

namespace RMU.Hand.TenpaiHands
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
