using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateMidChiiBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        Tile oneBelow = GetTileBelow(calledTile);
        Tile oneAbove = GetTileAbove(calledTile);
        return new List<Tile> { oneBelow, calledTile, oneAbove };
    }
}
