using RMU.Tiles;
using RMU.Tiles.TileDecorators;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateMidChiiRedBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        Tile oneBelow = GetTileBelow(calledTile);
        if (oneBelow.GetValue() == 5)
            oneBelow = new RedFiveDecorator(oneBelow);
        Tile oneAbove = GetTileAbove(calledTile);
        if (oneAbove.GetValue() == 5)
            oneAbove = new RedFiveDecorator(oneAbove);
        return new List<Tile> { oneBelow, calledTile, oneAbove };
    }
}
