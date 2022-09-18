using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public interface ICompleteHandComponent
{
    CompleteHandComponentType GetComponentType();
    List<Tile> GetTiles();
    Tile GetLeadTile();
    CompleteHandGeneralComponentType GetGeneralComponentType();
}
