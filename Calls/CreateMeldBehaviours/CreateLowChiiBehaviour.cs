using RMU.Tiles;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateLowChiiBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        Tile twoBelow = GetTileTwoBelow(calledTile);
        Tile oneBelow = GetTileBelow(calledTile);
        return new List<Tile> { twoBelow, oneBelow, calledTile };
    }
}
