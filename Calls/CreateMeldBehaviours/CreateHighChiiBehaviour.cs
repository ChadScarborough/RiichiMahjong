using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateHighChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            TileObject oneAbove = Functions.GetTileAbove(calledTile);
            TileObject twoAbove = Functions.GetTileTwoAbove(calledTile);
            return new List<TileObject> { calledTile, oneAbove, twoAbove };
        }
    }
}
