using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Hand.Calls
{
    public interface ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile);
    }
}
