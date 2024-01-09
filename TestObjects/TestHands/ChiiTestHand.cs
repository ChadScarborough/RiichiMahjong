using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public class ChiiTestHand : TestHand
    {
        public ChiiTestHand()
        {
            _closedTiles = new List<Tile>
            {
                TwoPin(), ThreePin(), FivePin(), SixPin(),
                OneMan(), FourMan(), SevenMan(),
                TwoSou(), FiveSou(), EightSou(),
                EastWind(), NorthWind(), GreenDragon()
            };
        }
    }
}
