using System;

namespace RMU.Tiles
{
    public class EventArgTile : EventArgs
    {
        public string TileName { get; init; }

        public EventArgTile(Tile tile)
        {
            TileName = tile.ToString();
        }

        public override string ToString()
        {
            return TileName;
        }
    }

    public class EventArgTileArray : EventArgs
    {
        public string[] TileNames { get; init; }

        public EventArgTileArray(string[] tileNames)
        {
            TileNames = tileNames;
        }
    }
}
