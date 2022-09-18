using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class CreateKitaBehaviour : ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile)
    {
        return AreWindsEquivalent(calledTile, NORTH)
            ? new List<Tile> { calledTile }
            : throw new Exception("Tried to create Kita with non-North tile");
    }
}