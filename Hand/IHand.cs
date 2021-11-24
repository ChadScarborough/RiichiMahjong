using System.Collections.Generic;

namespace RMU.Hand
{
    public interface IHand
    {
        void DiscardTile(int index);
        void DrawTileFromWall();
        void DrawTileFromDeadWall();
        void SortHand();
        void CallPon(Tiles.TileObject _calledTile);
        void CallLowChii(Tiles.TileObject _calledTile);
        void CallMidChii(Tiles.TileObject _calledTile);
        void CallHighChii(Tiles.TileObject _calledTile);
        void CallClosedKan(Tiles.TileObject _calledTile);
        void CallOpenKan1(Tiles.TileObject _calledTile);
        void CallOpenKan2(Tiles.TileObject _calledTile);
        void AddDrawTileToHand();
        List<Tiles.TileObject> GetClosedTiles();
        List<OpenMeld> GetOpenMelds();
        Tiles.TileObject GetDrawTile();
    }
}