namespace RMU.Hand
{
    public interface IHand
    {
        void DiscardTile(int index);
        void DrawTileFromWall();
        void DrawTileFromDeadWall();
        void SortHand();
        Tiles.TileObject GetDrawTile();
    }
}