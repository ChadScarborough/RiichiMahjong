using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class DrawTile : ICompleteHandComponent
{
    private readonly Tile _tile;

    public DrawTile(Tile drawTile)
    {
        _tile = drawTile;
    }

    public CompleteHandComponentType GetComponentType()
    {
        return DRAW_TILE;
    }

    public CompleteHandGeneralComponentType GetGeneralComponentType()
    {
        return TILE;
    }

    public Tile GetLeadTile()
    {
        return _tile;
    }

    public List<Tile> GetTiles()
    {
        return new List<Tile> { _tile };
    }
}
