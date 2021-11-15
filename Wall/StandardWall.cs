using System;
using System.Collections.Generic;
using System.Text;
using RMU.DataStructures;
using RMU.Tiles;
using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class StandardWall : IWall
    {
        private DoublyLinkedList<TileObject> _wall = new DoublyLinkedList<TileObject>();
        private const int NUMBER_OF_NUMERICAL_VALUES = 9;
        private const int NUMBER_OF_WINDS = 4;
        private const int NUMBER_OF_DRAGONS = 3;
        private const int NUMBER_OF_COPIES = 4;
        private TileFacade tileFacade = new TileFacade();

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
            int _r;
            while (tiles.Count > 0)
            {
                _r = _rand.Next(0, tiles.Count);
                outputList.Add(tiles[_r]);
                tiles.RemoveAt(_r);
            }
            return outputList;
        }

        private List<TileObject> GenerateTiles()
        {
            List<TileObject> tileList = new List<TileObject>();
            GenerateManTiles(tileList);
            GeneratePinTiles(tileList);
            GenerateSouTiles(tileList);
            GenerateWindTiles(tileList);
            GenerateDragonTiles(tileList);
            return tileList;
        }

        private void GenerateManTiles(List<TileObject> destination)
        {
            for (int i = 0; i < NUMBER_OF_NUMERICAL_VALUES; i++)
            {
                for (int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    destination.Add(tileFacade.CreateTile(i + 1, TileEnums.Suit.Man));
                }
            }
        }

        private void GeneratePinTiles(List<TileObject> destination)
        {
            for (int i = 0; i < NUMBER_OF_NUMERICAL_VALUES; i++)
            {
                for (int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    destination.Add(tileFacade.CreateTile(i + 1, TileEnums.Suit.Pin));
                }
            }
        }

        private void GenerateSouTiles(List<TileObject> destination)
        {
            for (int i = 0; i < NUMBER_OF_NUMERICAL_VALUES; i++)
            {
                for (int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    destination.Add(tileFacade.CreateTile(i + 1, TileEnums.Suit.Sou));
                }
            }
        }

        private void GenerateWindTiles(List<TileObject> destination)
        {
            for (int i = 0; i < NUMBER_OF_WINDS; i++)
            {
                for (int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    destination.Add(tileFacade.CreateTile(i + 1, TileEnums.Suit.Wind));
                }
            }
        }

        private void GenerateDragonTiles(List<TileObject> destination)
        {
            for (int i = 0; i < NUMBER_OF_DRAGONS; i++)
            {
                for (int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    destination.Add(tileFacade.CreateTile(i + 1, TileEnums.Suit.Dragon));
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
