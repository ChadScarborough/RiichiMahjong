using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public interface ICompleteHandComponent
    {
        Enums.CompleteHandComponentType GetComponentType();
        List<Tile> GetTiles();
        Tile GetLeadTile();

        Enums.CompleteHandGeneralComponentType GetGeneralComponentType();
    }
}
