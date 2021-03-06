using System.Collections.Generic;
using RMU.Calls.CreateMeldBehaviours;
using RMU.DiscardPile;
using RMU.Globals.Algorithms;
using RMU.Hands.TenpaiHands;
using RMU.Shanten;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;
using static RMU.Globals.Functions;
using static RMU.Globals.Enums;

namespace RMU.Hands
{
    public abstract class Hand
    {
        private readonly Wall.Wall _wall;
        private readonly IDeadWall _deadWall;
        protected List<TileObject> _closedTiles;
        private TileObject _drawTile;
        private readonly StandardDiscardPile _discardPile;
        private readonly HandSorter _handSorter;
        private readonly List<OpenMeld> _openMelds;
        private bool _isOpen;
        private readonly List<ITenpaiHand> _tenpaiHands;
        private readonly List<TileObject> _waits;
        private int _shanten;

        protected Hand(WallObject wallObject)
        {
            _wall = wallObject.GetWall();
            _deadWall = wallObject.GetDeadWall();
            _discardPile = new StandardDiscardPile();
            _handSorter = new HandSorter();
            _closedTiles = new List<TileObject>();
            _openMelds = new List<OpenMeld>();
            _tenpaiHands = new List<ITenpaiHand>();
            _waits = new List<TileObject>();
        }

        public void OpenHand()
        {
            _isOpen = true;
        }
        
        public virtual void DiscardTile(int index)
        {
            _discardPile.DiscardTile(_closedTiles[index]);
            _closedTiles.RemoveAt(index);
            AddDrawTileToHand();
            SortHand();
        }
        
        public virtual void DrawTileFromWall()
        {
            if(_drawTile != null)
            {
                AddDrawTileToHand();
            }
            _drawTile = _wall.DrawTileFromWall();
        }
        
        public virtual void DrawTileFromDeadWall()
        {
            if(_drawTile != null)
            {
                AddDrawTileToHand();
            }
            _drawTile = _deadWall.DrawTile();
        }
        
        protected virtual void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }
        
        public void CreateOpenMeld(TileObject calledTile, MeldType meldType)
        {
            OpenMeld openMeld = new OpenMeld(meldType, calledTile);
            this._openMelds.Add(openMeld);
        }
        
        public void RemoveCopyOfTile(TileObject calledTile)
        {
            for (int i = _closedTiles.Count - 1; i >= 0; i--)
            {
                if (IsDuplicateTile(_closedTiles[i], calledTile, i))
                {
                    return;
                }
            }
        }
        
        private bool IsDuplicateTile(TileObject closedTile, TileObject calledTile, int index)
        {
            if (AreTilesEquivalent(closedTile, calledTile))
            {
                _closedTiles.RemoveAt(index);
                return true;
            }
            return false;
        }

        protected virtual void AddDrawTileToHand()
        {
            _closedTiles.Add(_drawTile);
            _drawTile = null;
        }
        
        public virtual List<TileObject> GetClosedTiles()
        {
            return _closedTiles;
        }
        
        public virtual List<OpenMeld> GetOpenMelds()
        {
            return _openMelds;
        }
        
        public virtual TileObject GetDrawTile()
        {
            return _drawTile;
        }
        
        public virtual bool IsOpen()
        {
            return _isOpen;
        }
        
        public virtual List<TileObject> GetAllTiles(TileObject extraTile)
        {
            List<TileObject> outputList = new List<TileObject>();
            AddClosedTilesToOutputList(outputList);
            AddEachOpenMeldToOutputList(outputList);
            AddExtraTileToOutputList(extraTile, outputList);
            return _handSorter.SortHand(outputList);
        }

        private static void AddExtraTileToOutputList(TileObject extraTile, List<TileObject> outputList)
        {
            outputList.Add(extraTile);
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

        public void RemoveDrawTile()
        {
            _drawTile = null;
        }

        public List<ITenpaiHand> GetTenpaiHands()
        {
            return _tenpaiHands;
        }

        public List<TileObject> GetWaits()
        {
            return _waits;
        }

        public int GetShanten()
        {
            return _shanten;
        }

        public void CheckShanten()
        {
            ClearTenpaiHands();
            _shanten = ShantenCalculator.CalculateShanten(this);
        }

        private void ClearTenpaiHands()
        {
            _tenpaiHands.Clear();
        }

        public void AddTenpaiHand(ITenpaiHand tenpaiHand)
        {
            _tenpaiHands.Add(tenpaiHand);
        }

        public void ClearWaits()
        {
            _waits.Clear();
        }

        public void AddWait(TileObject tile)
        {
            _waits.Add(tile);
        }
    }
}