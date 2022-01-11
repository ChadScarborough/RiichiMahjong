using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateKanBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            return new List<TileObject>
            {
                calledTile.Clone(), 
                calledTile.Clone(), 
                calledTile.Clone(), 
                calledTile.Clone()
            };
        }
    }
}
