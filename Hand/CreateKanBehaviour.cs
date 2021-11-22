using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

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
