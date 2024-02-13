using RMU.Tiles;
using RMU.Tiles.TileDecorators;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateLowChiiRedBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        Tile twoBelow = GetTileTwoBelow(calledTile);
        if (twoBelow.GetValue() == 5)
            twoBelow = new RedFiveDecorator(twoBelow);
        Tile oneBelow = GetTileBelow(calledTile);
        if (oneBelow.GetValue() == 5)
            oneBelow = new RedFiveDecorator(oneBelow);
        return new List<Tile> { twoBelow, oneBelow, calledTile };
    }
}
