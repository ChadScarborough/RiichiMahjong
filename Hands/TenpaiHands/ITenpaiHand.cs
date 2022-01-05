using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Hands.TenpaiHands
{
    public interface ITenpaiHand
    {
        List<ICompleteHandComponent> GetComponents();
        //List<TileObject> GetWaits();
    }
}
