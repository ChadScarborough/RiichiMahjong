using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class PairComponent : ICompleteHandComponent
    {
        private readonly List<TileObject> _tiles;

        public PairComponent(List<TileObject> pair)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in pair)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.PAIR_COMPONENT;
        }

        public Enums.CompleteHandGeneralComponentType GetGeneralComponentType()
        {
            return Enums.PAIR;
        }

        public TileObject GetLeadTile()
        {
            return _tiles[0];
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
