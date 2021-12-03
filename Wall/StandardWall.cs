using System;
using System.Collections.Generic;
using RMU.DataStructures;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Wall
{
    public class StandardWall : IWall
    {
        private DoublyLinkedList<TileObject> _wall = new DoublyLinkedList<TileObject>();
        private const int NUMBER_OF_NUMERICAL_VALUES = 9;
        private const int NUMBER_OF_WINDS = 4;
        private const int NUMBER_OF_DRAGONS = 3;
        private const int NUMBER_OF_COPIES = 4;

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

        private void FillWall(List<TileObject> source, DoublyLinkedList<TileObject> destination)
        {
            destination.Clear();
            foreach (TileObject tile in source)
            {
                destination.AddHead(tile);
            }
        }

        private List<TileObject> ShuffleTiles(List<TileObject> tiles)
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

        private List<TileObject> GenerateTiles()
        {
            List<TileObject> tileList = new List<TileObject>();
            GenerateNumberTiles(tileList);
            GenerateWindTiles(tileList);
            GenerateDragonTiles(tileList);
            return tileList;
        }

        private void GenerateNumberTiles(List<TileObject> tileList)
        {
            GenerateManTiles(tileList);
            GeneratePinTiles(tileList);
            GenerateSouTiles(tileList);
        }

        private void GenerateManTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.MAN, NUMBER_OF_NUMERICAL_VALUES, destination);
        }

        private void GeneratePinTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.PIN, NUMBER_OF_NUMERICAL_VALUES, destination);
        }

        private void GenerateSouTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.SOU, NUMBER_OF_NUMERICAL_VALUES, destination);
        }

        private void GenerateWindTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.WIND, NUMBER_OF_WINDS, destination);
        }

        private void GenerateDragonTiles(List<TileObject> destination)
        {
            GenerateTilesOfAGivenSuitAndNumber(Enums.DRAGON, NUMBER_OF_DRAGONS, destination);
        }

        private void GenerateTilesOfAGivenSuitAndNumber(Enums.Suit suit, int numberOfValues, List<TileObject> destination)
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

        public void Clear()
        {
            _wall.Clear();
        }
    }
}
