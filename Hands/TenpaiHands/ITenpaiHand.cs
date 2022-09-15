using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Hands.TenpaiHands
{
    public interface ITenpaiHand
    {
        List<ICompleteHandComponent> GetComponents();
        List<Tile> GetWaits();
        Enums.CompleteHandWaitType GetWaitType();
        Enums.CompleteHandType GetHandType();
    }
}
