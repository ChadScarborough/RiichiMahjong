using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands
{
    public interface ICompleteHand
    {
        List<ICompleteHandComponent> GetComponents();
        Enums.CompleteHandWaitType GetWaitType();
        Enums.CompleteHandType GetCompleteHandType();
        bool IsOpen();
        List<ICompleteHandComponent> GetConstructedHandComponents();
        List<ICompleteHandComponent> GetTriplets();
        List<ICompleteHandComponent> GetSequences();
        List<ICompleteHandComponent> GetPairs();
        List<ICompleteHandComponent> GetIsolatedTiles();
        List<TileObject> GetTiles();
    }
}
