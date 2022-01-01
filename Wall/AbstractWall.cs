using System;
using System.Collections.Generic;
using RMU.DataStructures;
using RMU.Tiles;

namespace RMU.Wall
{
    public abstract class AbstractWall
    {
        protected AbstractWall()
        {
            _wall = new DoublyLinkedList<TileObject>();
        }
        
        protected DoublyLinkedList<TileObject> _wall;
        
        protected List<TileObject> ShuffleTiles(List<TileObject> tiles)
        {
            List<TileObject> outputList = new List<TileObject>();
            Random _rand = new Random();
            int _r = 0;
            while (tiles.Count > 0)
            {
                AddRandomTileToOutputList(tiles, outputList, _r, _rand);
            }
            return outputList;
        }
        
        private void AddRandomTileToOutputList(List<TileObject> inputList, List<TileObject> outputList, int _r, Random _rand)
        {
            _r = _rand.Next(0, inputList.Count);
            outputList.Add(inputList[_r]);
            inputList.RemoveAt(_r);
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
        
        protected List<TileObject> GenerateTiles(List<TileObject> tiles)
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

        public void Clear()
        {
            _wall.Clear();
        }
    }
}