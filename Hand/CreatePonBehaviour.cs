using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Hand
{
    public class CreatePonBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject _calledTile)
        {
            return new List<TileObject> { _calledTile, _calledTile, _calledTile };
        }
    }
}
