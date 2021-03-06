using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public interface ICompleteHandComponent
    {
        Enums.CompleteHandComponentType GetComponentType();
        List<TileObject> GetTiles();
        TileObject GetLeadTile();

        Enums.CompleteHandGeneralComponentType GetGeneralComponentType();
    }
}
