﻿using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;
using RMU.DiscardPile;
using RMU.Globals;

namespace RMU.Hand
{
    public class StandardHand : IHand
    {
        private IWall _wall;
        private IDeadWall _deadWall;
        private List<TileObject> _closedTiles;
        private TileObject _drawTile;
        private StandardDiscardPile _discardPile;
        private Algorithms.HandSorter _handSorter;
        private List<OpenMeld> _openMelds;
        private bool _isOpen = false;

        public StandardHand(IWall wall, IDeadWall deadWall)
        {
            this._wall = wall;
            this._deadWall = deadWall;
            this._discardPile = new StandardDiscardPile();
            this._handSorter = new Algorithms.HandSorter();
            _closedTiles = new List<TileObject>();
            _openMelds = new List<OpenMeld>();
        }

        public void DrawTileFromWall()
        {
            if(_drawTile != null)
            {
                AddDrawTileToHand();
            }
            _drawTile = _wall.DrawTileFromWall();
        }

        public void AddDrawTileToHand()
        {
            _closedTiles.Add(_drawTile);
            _drawTile = null;
        }

        public void DrawTileFromDeadWall()
        {
            if(_drawTile != null)
            {
                AddDrawTileToHand();
            }
            _drawTile = _deadWall.DrawTile();
        }

        public void DiscardTile(int index)
        {
            _discardPile.DiscardTile(_closedTiles[index]);
            _closedTiles.RemoveAt(index);
            AddDrawTileToHand();
            SortHand();
        }

        public void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }

        public TileObject GetDrawTile()
        {
            return _drawTile;
        }

        public void CallPon(TileObject _calledTile)
        {
            CreateOpenMeld(_calledTile, Enums.PON);
            for (int i = 0; i < 2; i++)
            {
                RemoveCopyOfTile(_calledTile);
            }
        }

        private void CreateOpenMeld(TileObject _calledTile, Enums.MeldType _meldType)
        {
            OpenMeld openMeld = new OpenMeld(_meldType, _calledTile);
            this._openMelds.Add(openMeld);
        }

        public void CallLowChii(TileObject _calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(_calledTile, Enums.LOW_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() - (i + 1), _calledTile.GetSuit());
                RemoveCopyOfTile(tempTile);
            }
        }

        public void CallMidChii(TileObject _calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(_calledTile, Enums.MID_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() - ((2 * i) - 1), _calledTile.GetSuit());
                RemoveCopyOfTile(tempTile);
            }
        }

        public void CallHighChii(TileObject _calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(_calledTile, Enums.HIGH_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(_calledTile.GetValue() + (i + 1), _calledTile.GetSuit());
                RemoveCopyOfTile(tempTile);
            }
        }

        public void CallClosedKan(TileObject _calledTile)
        {
            CreateOpenMeld(_calledTile, Enums.CLOSED_KAN_MELD);
            for (int i = 0; i < 4; i++)
            {
                RemoveCopyOfTile(_calledTile);
            }
            if (TilesAreEquivalent(_drawTile, _calledTile))
            {
                _drawTile = null;
            }
        }

        public void CallOpenKan1(TileObject _calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(_calledTile, Enums.OPEN_KAN_1);
            for (int i = 0; i < 3; i++)
            {
                RemoveCopyOfTile(_calledTile);
            }
        }

        public void CallOpenKan2(TileObject _calledTile)
        {
            foreach(OpenMeld openMeld in _openMelds)
            {
                if(SuccessfullyTurnedPonIntoOpenKan2(_calledTile, openMeld))
                {
                    return;
                }
            }
        }

        private bool SuccessfullyTurnedPonIntoOpenKan2(TileObject _calledTile, OpenMeld openMeld)
        {
            TileObject openMeldTile = openMeld.GetTiles()[0];
            if (openMeld.GetMeldType() == Enums.PON && TilesAreEquivalent(openMeldTile, _calledTile))
            {
                return ChangePonToOpenKan2(_calledTile, openMeld);
            }
            return false;
        }

        private bool ChangePonToOpenKan2(TileObject _calledTile, OpenMeld openMeld)
        {
            openMeld.SetMeldType(Enums.OPEN_KAN_2);
            openMeld.AddTile(_calledTile);
            if (TilesAreEquivalent(_drawTile, _calledTile))
            {
                _drawTile = null;
                return true;
            }
            foreach (TileObject tile in _closedTiles)
            {
                if (RemovedTileFromHand(tile)) 
                { 
                    return true; 
                }
            }
            return false;
        }

        private bool RemovedTileFromHand(TileObject tile)
        {
            if (TilesAreEquivalent(_drawTile, tile))
            {
                _closedTiles.Remove(tile);
                return true;
            }
            return false;
        }

        private void RemoveCopyOfTile(TileObject _calledTile)
        {
            for (int i = _closedTiles.Count - 1; i >= 0; i--)
            {
                if (IsDuplicateTile(_closedTiles[i], _calledTile, i))
                {
                    return;
                }
            }
        }

        private bool IsDuplicateTile(TileObject _closedTile, TileObject _calledTile, int index)
        {
            if (TilesAreEquivalent(_closedTile, _calledTile))
            {
                _closedTiles.RemoveAt(index);
                return true;
            }
            return false;
        }

        public List<OpenMeld> GetOpenMelds()
        {
            return _openMelds;
        }

        public List<TileObject> GetClosedTiles()
        {
            return _closedTiles;
        }

        private bool TilesAreEquivalent(TileObject tile1, TileObject tile2)
        {
            bool sameValue = (tile1.GetValue() == tile2.GetValue());
            bool sameSuit = (tile1.GetSuit() == tile2.GetSuit());
            return sameValue && sameSuit;
        }

        public List<TileObject> GetAllTiles(TileObject _extraTile)
        {
            List<TileObject> outputList = new List<TileObject>();
            AddClosedTilesToOutputList(outputList);
            AddEachOpenMeldToOutputList(outputList);
            AddExtraTileToOutputList(_extraTile, outputList);
            return _handSorter.SortHand(outputList);
        }

        private static void AddExtraTileToOutputList(TileObject _extraTile, List<TileObject> outputList)
        {
            outputList.Add(_extraTile);
        }

        private void AddEachOpenMeldToOutputList(List<TileObject> outputList)
        {
            foreach (OpenMeld openMeld in _openMelds)
            {
                AddEachTileInOpenMeldToOutputList(outputList, openMeld);
            }
        }

        private static void AddEachTileInOpenMeldToOutputList(List<TileObject> outputList, OpenMeld openMeld)
        {
            foreach (TileObject tile in openMeld.GetTiles())
            {
                outputList.Add(tile);
            }
        }

        private void AddClosedTilesToOutputList(List<TileObject> outputList)
        {
            foreach (TileObject tile in _closedTiles)
            {
                outputList.Add(tile);
            }
        }

        public bool IsOpen()
        {
            return _isOpen;
        }
    }
}
