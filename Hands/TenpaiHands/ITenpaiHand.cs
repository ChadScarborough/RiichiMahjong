using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Hands.TenpaiHands
{
    public interface ITenpaiHand
    {
        List<ICompleteHandComponent> GetComponents();
        List<TileObject> GetWaits();
    }
}
