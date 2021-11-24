using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using RMU.DataStructures;
using RMU.Globals;

namespace RMU.Wall
{
    public class TestWall : IWall
    {
        private DoublyLinkedList<TileObject> _wall;
        private TileFactory tileFactory = new TileFactory();

        public TestWall()
        {
            _wall = new DoublyLinkedList<TileObject>();
            PopulateWall();
        }

        public void Clear()
        {
            _wall.Clear();
        }

        public TileObject DrawTileFromEndOfWall()
        {
            return _wall.RemoveTail();
        }

        public TileObject DrawTileFromWall()
        {
            return _wall.RemoveHead();
        }

        public int GetSize()
        {
            return _wall.GetSize();
        }

        public void PopulateWall()
        {
            for(int i = 0; i < 3; i++)
            {
                _wall.AddTail(tileFactory.CreateTile(1, Enums.Suit.Man));
            }
            for(int i = 0; i < 5; i++)
            {
                _wall.AddTail(tileFactory.CreateTile(i + 1, Enums.Suit.Sou));
            }
        }
    }
}
