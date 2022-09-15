using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public class SevenPairsTenpaiHand : ITenpaiHand
    {
        private readonly List<ICompleteHandComponent> _components;
        private List<Tile> _waits;
        
        public SevenPairsTenpaiHand(List<ICompleteHandComponent> components)
        {
            _components = components;
            _waits = new();
            GenerateWaits();
        }
        
        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
        }

        public List<Tile> GetWaits()
        {
            return _waits;
        }

        public CompleteHandWaitType GetWaitType()
        {
            return PAIR_WAIT;
        }

        public CompleteHandType GetHandType()
        {
            return SEVEN_PAIRS;
        }

        private void GenerateWaits()
        {
            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetComponentType() != PAIR_COMPONENT)
                {
                    _waits.Add(component.GetLeadTile().Clone());
                    return;
                }
            }
        }
    }
}