using System.Collections.Generic;
using RMU.Globals.DataStructures;
using RMU.Tiles;

namespace RMU.Wall
{
    public abstract class Wall
    {
        protected Wall()
        {
            _wall = new DoublyLinkedList<Tile>();
        }
        
        private readonly DoublyLinkedList<Tile> _wall;
        
        public virtual Tile DrawTileFromWall()
        {
            return DrawTile(_wall);
        }

        private Tile DrawTile(DoublyLinkedList<Tile> wall)
        {
            return wall.RemoveHead();
        }

        public virtual Tile DrawTileFromEndOfWall()
        {
            return DrawTileFromEnd(_wall);
        }

        private Tile DrawTileFromEnd(DoublyLinkedList<Tile> wall)
        {
            return wall.RemoveTail();
        }

        public void PopulateWall(List<Tile> tiles)
        {
            Clear();
            List<Tile> tempList = GenerateTiles(tiles);
            FillWall(tempList, _wall);
        }
        
        private void FillWall(List<Tile> source, DoublyLinkedList<Tile> destination)
        {
            destination.Clear();
            foreach (Tile tile in source)
            {
                destination.AddHead(tile);
            }
        }
        
        private List<Tile> GenerateTiles(List<Tile> tiles)
        {
            List<Tile> tileList = new List<Tile>();
            foreach (Tile tile in tiles)
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

        public virtual List<Tile> GetWallTiles()
        {
            List<Tile> outputList = new List<Tile>();
            DoublyLinkedList<Tile>.Node node = _wall.GetHead();
            while (node != null)
            {
                outputList.Add(node.GetValue());
                node = node.GetNext();
            }
            
            return outputList;
        }
    }
}