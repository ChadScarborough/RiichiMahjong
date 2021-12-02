using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Hand
{
    public interface ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject _calledTile);
    }
}
