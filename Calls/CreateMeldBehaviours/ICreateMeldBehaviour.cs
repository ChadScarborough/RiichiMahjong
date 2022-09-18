using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Calls.CreateMeldBehaviours;

public interface ICreateMeldBehaviour
{
    public List<Tile> CreateMeld(Tile calledTile);
}
