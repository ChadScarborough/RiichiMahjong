using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class IsolatedTile : ICompleteHandComponent
{
    private readonly Tile _tile;

    public IsolatedTile(Tile isolatedTile)
    {
        _tile = isolatedTile;
    }

    public CompleteHandComponentType GetComponentType()
    {
        return ISOLATED_TILE;
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
