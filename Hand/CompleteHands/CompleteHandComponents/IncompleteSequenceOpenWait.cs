using System;
using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;
using static RMU.Globals.Functions;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceOpenWait : ICompleteHandIncompleteGroup
    {
        private readonly List<TileObject> _tiles;

        public IncompleteSequenceOpenWait(List<TileObject> incompleteSequenceOpenWait)
        {
            _tiles = new List<TileObject>();
            foreach (TileObject tile in incompleteSequenceOpenWait)
            {
                _tiles.Add(tile);
            }
            CheckForValidIncompleteSequenceOpenWait();
        }

        private void CheckForValidIncompleteSequenceOpenWait()
        {
            CheckForCorrectNumber();
            CheckForConsecutiveIncompleteSequence();
            CheckThatIncompleteSequenceIsNotEdgeWait();
        }

        private void CheckForCorrectNumber()
        {
            if(_tiles.Count != 2)
            {
                throw new ArgumentException("Incorrect number of tiles");
            }
        }

        private void CheckForConsecutiveIncompleteSequence()
        {
            if(AreTilesEquivalent(_tiles[0], GetTileBelow(_tiles[1])) == false)
            {
                throw new ArgumentException("Tiles do not form consecutive incomplete sequence");
            }
        }

        private void CheckThatIncompleteSequenceIsNotEdgeWait()
        {
            if(_tiles[0].GetValue() == 1 || _tiles[1].GetValue() == 9)
            {
                throw new ArgumentException("Tiles do not have open wait");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.INCOMPLETE_SEQUENCE_OPEN_WAIT;
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
