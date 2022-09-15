using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateLowChiiBehaviour : ICreateMeldBehaviour
    {
        public List<Tile> CreateMeld(Tile calledTile)
        {
            Tile twoBelow = Functions.GetTileTwoBelow(calledTile);
            Tile oneBelow = Functions.GetTileBelow(calledTile);
            return new List<Tile> { twoBelow, oneBelow, calledTile };
        }
    }
}
