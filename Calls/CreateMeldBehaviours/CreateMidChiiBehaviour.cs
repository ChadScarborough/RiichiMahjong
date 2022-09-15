using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateMidChiiBehaviour : ICreateMeldBehaviour
    {
        public List<Tile> CreateMeld(Tile calledTile)
        {
            Tile oneBelow = Functions.GetTileBelow(calledTile);
            Tile oneAbove = Functions.GetTileAbove(calledTile);
            return new List<Tile> { oneBelow, calledTile, oneAbove };
        }
    }
}
