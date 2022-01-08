using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;

namespace RMU.Hands.TestHands
{
    public abstract class TestHand : Hand
    {
        protected TestHand() : base(new NullWallObject())
        {
        }

        public override List<TileObject> GetClosedTiles()
        {
            return _closedTiles;
        }

        public override List<TileObject> GetAllTiles(TileObject extraTile)
        {
            List<TileObject> outputList = new List<TileObject>();
            foreach (TileObject tile in _closedTiles)
            {
                outputList.Add(tile);
            }
            outputList.Add(extraTile);
            return outputList;
        }

        public override bool IsOpen()
        {
            return false;
        }
    }
}
