using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Hand.Calls
{
    public class CreateKitaBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            return new List<TileObject> {calledTile};
        }
    }
}