using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.Calls
{
    public class CreateKanBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            return new List<TileObject> { calledTile, calledTile, calledTile, calledTile };
        }
    }
}
