using System.Collections.Generic;
using RMU.Globals.DataStructures;
using RMU.Tiles;

namespace RMU.Wall
{
    public abstract class Wall
    {
        protected Wall()
        {
            _wall = new DoublyLinkedList<TileObject>();
        }
        
        private readonly DoublyLinkedList<TileObject> _wall;
        
        public virtual TileObject DrawTileFromWall()
        {
            return DrawTile(_wall);
        }

        private TileObject DrawTile(DoublyLinkedList<TileObject> wall)
        {
            return wall.RemoveHead();
        }

        public virtual TileObject DrawTileFromEndOfWall()
        {
            return DrawTileFromEnd(_wall);
        }

        private TileObject DrawTileFromEnd(DoublyLinkedList<TileObject> wall)
        {
            return wall.RemoveTail();
        }

        public void PopulateWall(List<TileObject> tiles)
        {
            Clear();
            List<TileObject> tempList = GenerateTiles(tiles);
            FillWall(tempList, _wall);
        }
        
        private void FillWall(List<TileObject> source, DoublyLinkedList<TileObject> destination)
        {
            destination.Clear();
            foreach (TileObject tile in source)
            {
                destination.AddHead(tile);
            }
        }
        
        private List<TileObject> GenerateTiles(List<TileObject> tiles)
        {
            List<TileObject> tileList = new List<TileObject>();
            foreach (TileObject tile in tiles)
            {
                tileList.Add(tile.Clone());
            }
            return tileList;
        }

        public virtual int GetSize()
        {
            return _wall.GetSize();
        }

        private void Clear()
        {
            _wall.Clear();
        }

        public virtual List<TileObject> GetWallTiles()
        {
            List<TileObject> outputList = new List<TileObject>();
            DoublyLinkedList<TileObject>.Node node = _wall.GetHead();
            while (node != null)
            {
                outputList.Add(node.GetValue());
                node = node.GetNext();
            }
            
            return outputList;
        }
    }
}