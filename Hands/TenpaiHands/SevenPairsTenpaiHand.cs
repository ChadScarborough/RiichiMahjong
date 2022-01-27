using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public class SevenPairsTenpaiHand : ITenpaiHand
    {
        private readonly List<ICompleteHandComponent> _components;
        private List<TileObject> _waits;
        
        public SevenPairsTenpaiHand(List<ICompleteHandComponent> components)
        {
            _components = components;
            GenerateWaits();
        }
        
        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
        }

        public List<TileObject> GetWaits()
        {
            return _waits;
        }

        public CompleteHandWaitType GetWaitType()
        {
            return PAIR_WAIT;
        }

        private void GenerateWaits()
        {
            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetComponentType() == ISOLATED_TILE)
                {
                    _waits = new List<TileObject>
                    {
                        component.GetLeadTile().Clone()
                    };
                    return;
                }
            }
        }
    }
}