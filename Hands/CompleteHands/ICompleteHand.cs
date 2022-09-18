using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Players;
using RMU.Hands.TenpaiHands;

namespace RMU.Hands.CompleteHands
{
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
        void SetYaku(List<Yaku.StandardYaku.YakuBase> satisfiedYaku);
        List<Yaku.StandardYaku.YakuBase> GetYaku();
        Player GetPlayer();
    }
}
