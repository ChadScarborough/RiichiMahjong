using System.Collections.Generic;
using RMU.Wall;
using RMU.Wall.DeadWall;
using RMU.DiscardPile;
using RMU.Hand.Calls;
using static RMU.Globals.Functions;
using static RMU.Globals.Enums;
using RMU.Globals.Algorithms;
using RMU.Tiles;

namespace RMU.Hand
{
    public abstract class AbstractHand
    {
        private readonly AbstractWall _wall;
        private readonly IDeadWall _deadWall;
        protected List<TileObject> _closedTiles;
        private TileObject _drawTile;
        private readonly StandardDiscardPile _discardPile;
        private readonly HandSorter _handSorter;
        private readonly List<OpenMeld> _openMelds;
        protected bool _isOpen = false;

        protected AbstractHand(AbstractWall wall, IDeadWall deadWall)
        {
            _wall = wall;
            _deadWall = deadWall;
            _discardPile = new StandardDiscardPile();
            _handSorter = new HandSorter();
            _closedTiles = new List<TileObject>();
            _openMelds = new List<OpenMeld>();
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
        
        public virtual void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }
        
        protected void CreateOpenMeld(TileObject calledTile, MeldType meldType)
        {
            OpenMeld openMeld = new OpenMeld(meldType, calledTile);
            this._openMelds.Add(openMeld);
        }
        
        protected void RemoveCopyOfTile(TileObject calledTile)
        {
            for (int i = _closedTiles.Count - 1; i >= 0; i--)
            {
                if (IsDuplicateTile(_closedTiles[i], calledTile, i))
                {
                    return;
                }
            }
        }
        
        protected bool IsDuplicateTile(TileObject closedTile, TileObject calledTile, int index)
        {
            if (AreTilesEquivalent(closedTile, calledTile))
            {
                _closedTiles.RemoveAt(index);
                return true;
            }
            return false;
        }

        public virtual void CallPon(TileObject calledTile)
        {
            CreateOpenMeld(calledTile, PON);
            for (int i = 0; i < 2; i++)
            {
                RemoveCopyOfTile(calledTile);
            }
        }

        public virtual void CallClosedKan(TileObject calledTile)
        {
            CreateOpenMeld(calledTile, CLOSED_KAN_MELD);
            for (int i = 0; i < 4; i++)
            {
                RemoveCopyOfTile(calledTile);
            }
            if (AreTilesEquivalent(_drawTile, calledTile))
            {
                _drawTile = null;
            }
        }
        
        public virtual void CallOpenKan1(TileObject calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(calledTile, OPEN_KAN_1);
            for (int i = 0; i < 3; i++)
            {
                RemoveCopyOfTile(calledTile);
            }
        }
        
        public virtual void CallOpenKan2(TileObject calledTile)
        {
            foreach(OpenMeld openMeld in _openMelds)
            {
                if(SuccessfullyTurnedPonIntoOpenKan2(calledTile, openMeld))
                {
                    return;
                }
            }
        }
        
        private bool SuccessfullyTurnedPonIntoOpenKan2(TileObject calledTile, OpenMeld openMeld)
        {
            TileObject openMeldTile = openMeld.GetTiles()[0];
            if (openMeld.GetMeldType() == PON && AreTilesEquivalent(openMeldTile, calledTile))
            {
                return ChangePonToOpenKan2(calledTile, openMeld);
            }
            return false;
        }
        
        private bool ChangePonToOpenKan2(TileObject calledTile, OpenMeld openMeld)
        {
            openMeld.SetMeldType(OPEN_KAN_2);
            openMeld.AddTile(calledTile);
            if (AreTilesEquivalent(_drawTile, calledTile))
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
            if (AreTilesEquivalent(_drawTile, tile))
            {
                _closedTiles.Remove(tile);
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
    }
}