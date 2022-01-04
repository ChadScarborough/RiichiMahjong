using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Calls.CreateMeldBehaviours
{
    public interface ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile);
    }
}
