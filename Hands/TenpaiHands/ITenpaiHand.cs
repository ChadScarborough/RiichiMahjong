using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public interface ITenpaiHand
{
    List<ICompleteHandComponent> GetComponents();
    List<Tile> GetWaits();
    Enums.CompleteHandWaitType GetWaitType();
    Enums.CompleteHandType GetHandType();
}
