using RMU.Tiles;
using RMU.Tiles.TileDecorators;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateHighChiiRedBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        Tile oneAbove = GetTileAbove(calledTile);
        if (oneAbove.GetValue() == 5)
            oneAbove = new RedFiveDecorator(oneAbove);
        Tile twoAbove = GetTileTwoAbove(calledTile);
        if (twoAbove.GetValue() == 5)
            twoAbove = new RedFiveDecorator(twoAbove);
        return new List<Tile> { calledTile, oneAbove, twoAbove };
    }
}
