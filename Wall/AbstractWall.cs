using System;
using System.Collections.Generic;
using RMU.Globals.DataStructures;
using RMU.Tiles;

namespace RMU.Wall
{
    public abstract class AbstractWall
    {
        protected AbstractWall()
        {
            _wall = new DoublyLinkedList<TileObject>();
        }
        
        private readonly DoublyLinkedList<TileObject> _wall;
        
        private List<TileObject> ShuffleTiles(List<TileObject> tiles)
        {
            List<TileObject> outputList = new List<TileObject>();
            Random rand = new Random();
            while (tiles.Count > 0)
            {
                AddRandomTileToOutputList(tiles, outputList, rand);
            }
            return outputList;
        }
        
        private void AddRandomTileToOutputList(List<TileObject> inputList, List<TileObject> outputList, Random rand)
        {
            int r = rand.Next(0, inputList.Count);
            outputList.Add(inputList[r]);
            inputList.RemoveAt(r);
        }
        
        public TileObject DrawTileFromWall()
        {
            return DrawTile(_wall);
        }

        private TileObject DrawTile(DoublyLinkedList<TileObject> wall)
        {
            return wall.RemoveHead();
        }

        public TileObject DrawTileFromEndOfWall()
        {
            return DrawTileFromEnd(_wall);
        }

        private TileObject DrawTileFromEnd(DoublyLinkedList<TileObject> wall)
        {
            return wall.RemoveTail();
        }

        protected void PopulateWall(List<TileObject> tiles)
        {
            Clear();
            List<TileObject> tempList = GenerateTiles(tiles);
            tempList = ShuffleTiles(tempList);
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

        public int GetSize()
        {
            return _wall.GetSize();
        }

        private void Clear()
        {
            _wall.Clear();
        }

        public List<TileObject> GetWallTiles()
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