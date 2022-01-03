using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.TestHands
{
    public abstract class TestHand : AbstractHand
    {
        protected TestHand() : base(null, null)
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
