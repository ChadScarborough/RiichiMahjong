using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateHighChiiBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        Tile oneAbove = GetTileAbove(calledTile);
        Tile twoAbove = GetTileTwoAbove(calledTile);
        return new List<Tile> { calledTile, oneAbove, twoAbove };
    }
}
