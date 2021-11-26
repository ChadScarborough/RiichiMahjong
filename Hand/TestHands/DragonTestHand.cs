using RMU.Tiles;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;
using RMU.Algorithms;

namespace RMU.Hand.TestHands
{
    public class DragonTestHand : ITestHand
    {
        private List<TileObject> _closedTiles;
        private HandSorter _handSorter;
        private List<int> _tileValues;
        private List<Enums.Suit> _tileSuits;
        private TileFactory _tileFactory;

        public DragonTestHand()
        {
            _closedTiles = new List<TileObject>();
            _handSorter = new HandSorter();
            _tileFactory = new TileFactory();
            _tileValues = new List<int>
            { 
                ConstValues.GREEN_DRAGON, ConstValues.GREEN_DRAGON, ConstValues.GREEN_DRAGON, 
                ConstValues.RED_DRAGON, ConstValues.RED_DRAGON, ConstValues.RED_DRAGON,
                ConstValues.WHITE_DRAGON, ConstValues.WHITE_DRAGON, ConstValues.WHITE_DRAGON,
                ConstValues.EAST_WIND, ConstValues.EAST_WIND, ConstValues.EAST_WIND,
                ConstValues.SOUTH_WIND
            };
            _tileSuits = new List<Enums.Suit>
            {
                Enums.Suit.Dragon, Enums.Suit.Dragon, Enums.Suit.Dragon,
                Enums.Suit.Dragon, Enums.Suit.Dragon, Enums.Suit.Dragon,
                Enums.Suit.Dragon, Enums.Suit.Dragon, Enums.Suit.Dragon,
                Enums.Suit.Wind, Enums.Suit.Wind, Enums.Suit.Wind,
                Enums.Suit.Wind
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

        public List<TileObject> GetClosedTiles()
        {
            return _closedTiles;
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
            List<TileObject> outputList = new List<TileObject>();
            foreach(TileObject tile in _closedTiles)
            {
                outputList.Add(tile);
            }
            outputList.Add(_extraTile);
            return _handSorter.SortHand(outputList);
        }

        public void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }

        public void FillHand()
        {
            for(int i = 0; i < 13; i++)
            {
                TileObject tile = _tileFactory.CreateTile(_tileValues[i], _tileSuits[i]);
                _closedTiles.Add(tile);
            }
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }
    }
}
