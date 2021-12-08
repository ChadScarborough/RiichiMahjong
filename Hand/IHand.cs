using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Hand
{
    public interface IHand
    {
        void DiscardTile(int index);
        void DrawTileFromWall();
        void DrawTileFromDeadWall();
        void SortHand();
        void CallPon(TileObject _calledTile);
        void CallLowChii(TileObject _calledTile);
        void CallMidChii(TileObject _calledTile);
        void CallHighChii(TileObject _calledTile);
        void CallClosedKan(TileObject _calledTile);
        void CallOpenKan1(TileObject _calledTile);
        void CallOpenKan2(TileObject _calledTile);
        void AddDrawTileToHand();
        List<TileObject> GetClosedTiles();
        List<OpenMeld> GetOpenMelds();
        TileObject GetDrawTile();
        bool IsOpen();
        List<TileObject> GetAllTiles(TileObject _extraTile);
    }
}