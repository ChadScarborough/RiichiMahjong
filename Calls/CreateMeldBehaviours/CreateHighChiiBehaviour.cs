using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateHighChiiBehaviour : ICreateMeldBehaviour
    {
        public List<Tile> CreateMeld(Tile calledTile)
        {
            Tile oneAbove = Functions.GetTileAbove(calledTile);
            Tile twoAbove = Functions.GetTileTwoAbove(calledTile);
            return new List<Tile> { calledTile, oneAbove, twoAbove };
        }
    }
}
