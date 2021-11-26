using RMU.Tiles;
using RMU.Algorithms;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.TestHands
{
    public class AllTerminalsTestHand : ITestHand
    {
        private List<TileObject> _closedTiles;
        private TileFactory _tileFactory;
        private HandSorter _handSorter;
        private List<int> _tileValues;
        private List<Enums.Suit> _tileSuits;

        public AllTerminalsTestHand()
        {
            _closedTiles = new List<TileObject>();
            _tileFactory = new TileFactory();
            _handSorter = new HandSorter();
            _tileValues = new List<int>
            {
                1, 1, 1,
                9, 9, 9,
                1, 1, 1,
                9, 9, 9,
                1
            };
            _tileSuits = new List<Enums.Suit>()
            {
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Pin, Enums.Suit.Pin, Enums.Suit.Pin,
                Enums.Suit.Pin, Enums.Suit.Pin, Enums.Suit.Pin,
                Enums.Suit.Sou
            };
            FillHand();
        }

        public void AddDrawTileToHand()
        {
            throw new NotImplementedException();
        }

        public void CallClosedKan(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallHighChii(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallLowChii(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallMidChii(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallOpenKan1(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallOpenKan2(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallPon(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void DiscardTile(int index)
        {
            throw new NotImplementedException();
        }

        public void DrawTileFromDeadWall()
        {
            throw new NotImplementedException();
        }

        public void DrawTileFromWall()
        {
            throw new NotImplementedException();
        }

        public void FillHand()
        {
            for(int i = 0; i < 13; i++)
            {
                int value = _tileValues[i];
                Enums.Suit suit = _tileSuits[i];
                TileObject tile = _tileFactory.CreateTile(value, suit);
                _closedTiles.Add(tile);
            }
        }

        public List<TileObject> GetClosedTiles()
        {
            throw new NotImplementedException();
        }

        public TileObject GetDrawTile()
        {
            throw new NotImplementedException();
        }

        public List<OpenMeld> GetOpenMelds()
        {
            throw new NotImplementedException();
        }

        public List<TileObject> Listify(TileObject _extraTile)
        {
            SortHand();
            return _closedTiles;
        }

        public void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }
    }
}
