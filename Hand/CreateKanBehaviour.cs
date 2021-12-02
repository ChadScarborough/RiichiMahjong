using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand
{
    public class CreateKanBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject _calledTile)
        {
            return new List<TileObject> { _calledTile, _calledTile, _calledTile, _calledTile };
        }
    }
}
