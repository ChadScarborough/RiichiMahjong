using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public class FourConcealedTripletsTestHand : TestHand
    {
        public FourConcealedTripletsTestHand()
        {
            _closedTiles = new List<Tile> {
                TwoMan(), TwoMan(), TwoMan(),
                FiveSou(), FiveSou(), FiveSou(),
                EightPin(), EightPin(), EightPin(),
                RedDragon(), RedDragon(), RedDragon(),
                SouthWind()
            };
        }
    }
}
