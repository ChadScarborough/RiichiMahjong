using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Players;
using RMU.Tiles;
using RMU.Yaku;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands;

public interface ICompleteHand
{
    List<ICompleteHandComponent> GetComponents();
    Enums.CompleteHandWaitType GetWaitType();
    Enums.CompleteHandType GetCompleteHandType();
    bool IsOpen();
    ITenpaiHand GetTenpaiHand();
    List<ICompleteHandComponent> GetConstructedHandComponents();
    List<ICompleteHandComponent> GetTriplets();
    List<ICompleteHandComponent> GetSequences();
    List<ICompleteHandComponent> GetPairs();
    List<ICompleteHandComponent> GetIsolatedTiles();
    List<Tile> GetTiles();
    void ClearYaku();
    void SetYaku(List<YakuBase> satisfiedYaku);
    List<YakuBase> GetYaku();
    Player GetPlayer();
}
