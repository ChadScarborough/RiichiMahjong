using Godot;
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

        public EventArgTileArray(List<Tile> tiles)
        {
            List<string> names = new();
            foreach(Tile t in tiles)
            {
                names.Add(t.ToString());
            }
            TileNames = names.ToArray();
        }
    }
}
