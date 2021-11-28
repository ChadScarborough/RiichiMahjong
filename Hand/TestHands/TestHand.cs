using RMU.Tiles;
using RMU.Algorithms;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.TestHands
{
    public abstract class TestHand : IHand
    {
        protected List<TileObject> _closedTiles;
        protected HandSorter _handSorter;
        protected List<int> _tileValues;
        protected List<Enums.Suit> _tileSuits;
        protected TileFactory _tileFactory;
        public virtual void FillHand()
        {
            for (int i = 0; i < 13; i++)
            {
                TileObject tile = _tileFactory.CreateTile(_tileValues[i], _tileSuits[i]);
                _closedTiles.Add(tile);
            }
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }

        public void DiscardTile(int index)
        {
            throw new NotImplementedException();
        }

        public void DrawTileFromWall()
        {
            throw new NotImplementedException();
        }

        public void DrawTileFromDeadWall()
        {
            throw new NotImplementedException();
        }

        public void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }

        public void CallPon(TileObject _calledTile)
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

        public void CallHighChii(TileObject _calledTile)
        {
            throw new NotImplementedException();
        }

        public void CallClosedKan(TileObject _calledTile)
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

        public void AddDrawTileToHand()
        {
            throw new NotImplementedException();
        }

        public List<TileObject> GetClosedTiles()
        {
            return _closedTiles;
        }

        public List<OpenMeld> GetOpenMelds()
        {
            throw new NotImplementedException();
        }

        public TileObject GetDrawTile()
        {
            throw new NotImplementedException();
        }

        public List<TileObject> Listify(TileObject _extraTile)
        {
            List<TileObject> outputList = new List<TileObject>();
            foreach (TileObject tile in _closedTiles)
            {
                outputList.Add(tile);
            }
            outputList.Add(_extraTile);
            return _handSorter.SortHand(outputList);
        }

        public virtual bool IsOpen()
        {
            return false;
        }
    }
}
