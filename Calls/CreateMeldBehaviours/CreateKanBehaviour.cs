using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateKanBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        return new List<Tile>
        {
            calledTile.Clone(),
            calledTile.Clone(),
            calledTile.Clone(),
            calledTile.Clone()
        };
    }
}
