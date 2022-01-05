using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;
using static RMU.Globals.Functions;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceEdgeWait : ICompleteHandIncompleteGroup
    {
        private readonly List<TileObject> _tiles;

        public IncompleteSequenceEdgeWait(List<TileObject> incompleteSequenceEdgeWait)
        {
            _tiles = new List<TileObject>();
            foreach (TileObject tile in incompleteSequenceEdgeWait)
            {
                _tiles.Add(tile);
            }
            CheckForValidIncompleteSequenceEdgeWait();
        }

        private void CheckForValidIncompleteSequenceEdgeWait()
        {
            CheckForCorrectNumber();
            CheckThatTilesFormConsecutiveIncompleteSequence();
            CheckForEdgeWait();
        }

        private void CheckForCorrectNumber()
        {
            if(_tiles.Count != 2)
            {
                throw new ArgumentException("Incorrect number of tiles");
            }
        }

        private void CheckThatTilesFormConsecutiveIncompleteSequence()
        {
            if (AreTilesEquivalent(_tiles[0], GetTileBelow(_tiles[1])) == false)
            {
                throw new ArgumentException("Tiles do not form consecutive incomplete sequence");
            }
        }

        private void CheckForEdgeWait()
        {
            if(_tiles[0].GetValue() != 1 && _tiles[1].GetValue() != 9)
            {
                throw new ArgumentException("Not an edge wait");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.INCOMPLETE_SEQUENCE_EDGE_WAIT;
        }

        public Enums.CompleteHandGeneralComponentType GetGeneralComponentType()
        {
            return Enums.TAATSU;
        }

        public TileObject GetLeadTile()
        {
            return _tiles[0];
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
