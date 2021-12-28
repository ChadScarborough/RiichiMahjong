using System;
using System.Collections.Generic;
using RMU.DataStructures;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Wall
{
    public class StandardWall : IWall
    {
        protected DoublyLinkedList<TileObject> _wall = new DoublyLinkedList<TileObject>();
        protected const int NUMBER_OF_NUMERICAL_VALUES = 9;
        protected const int NUMBER_OF_WINDS = 4;
        protected const int NUMBER_OF_DRAGONS = 3;
        protected const int NUMBER_OF_COPIES = 4;

        public StandardWall()
        {
            PopulateWall();
        }

        public void PopulateWall()
        {
            Clear();
            List<TileObject> tempList;
            tempList = GenerateTiles();
            tempList = ShuffleTiles(tempList);
            FillWall(tempList, _wall);
        }

        public int GetSize()
        {
            return _wall.GetSize();
        }

        protected void FillWall(List<TileObject> source, DoublyLinkedList<TileObject> destination)
        {
            destination.Clear();
            foreach (TileObject tile in source)
            {
                destination.AddHead(tile);
            }
        }

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

        protected void AddRandomTileToOutputList(List<TileObject> inputList, List<TileObject> outputList, int _r, Random _rand)
        {
            _r = _rand.Next(0, inputList.Count);
            outputList.Add(inputList[_r]);
            inputList.RemoveAt(_r);
        }

        protected List<TileObject> GenerateTiles()
        {
            List<TileObject> tileList = new List<TileObject>();
            GenerateNumberTiles(tileList);
            GenerateWindTiles(tileList);
            GenerateDragonTiles(tileList);
            return tileList;
        }

        protected void GenerateNumberTiles(List<TileObject> tileList)
        {
            GenerateManTiles(tileList);
            GeneratePinTiles(tileList);
            GenerateSouTiles(tileList);
        }

        protected void GenerateManTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.MAN, NUMBER_OF_NUMERICAL_VALUES, destination);
        }

        protected void GeneratePinTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.PIN, NUMBER_OF_NUMERICAL_VALUES, destination);
        }

        protected void GenerateSouTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.SOU, NUMBER_OF_NUMERICAL_VALUES, destination);
        }

        protected void GenerateWindTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.WIND, NUMBER_OF_WINDS, destination);
        }

        protected void GenerateDragonTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.DRAGON, NUMBER_OF_DRAGONS, destination);
        }

        protected virtual void GenerateTilesOfAGivenSuitAndNumber(Enums.Suit suit, int numberOfValues, List<TileObject> destination)
        {
            for(int i = 0; i < numberOfValues; i++)
            {
                for(int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    TileObject _tile = TileFactory.CreateTile(i + 1, suit);
                    destination.Add(_tile);
                }
            }
        }

        public TileObject DrawTileFromWall()
        {
            return DrawTile(_wall);
        }

        protected TileObject DrawTile(DoublyLinkedList<TileObject> wall)
        {
            return wall.RemoveHead();
        }

        public TileObject DrawTileFromEndOfWall()
        {
            return DrawTileFromEnd(_wall);
        }

        protected TileObject DrawTileFromEnd(DoublyLinkedList<TileObject> wall)
        {
            return wall.RemoveTail();
        }

        public void Clear()
        {
            _wall.Clear();
        }
    }
}
