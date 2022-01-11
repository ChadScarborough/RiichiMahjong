using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateLowChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            TileObject twoBelow = Functions.GetTileTwoBelow(calledTile);
            TileObject oneBelow = Functions.GetTileBelow(calledTile);
            return new List<TileObject> { twoBelow, oneBelow, calledTile };
        }
    }
}
