using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateMidChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            TileObject oneBelow = Functions.GetTileBelow(calledTile);
            TileObject oneAbove = Functions.GetTileAbove(calledTile);
            return new List<TileObject> { oneBelow, calledTile, oneAbove };
        }
    }
}
