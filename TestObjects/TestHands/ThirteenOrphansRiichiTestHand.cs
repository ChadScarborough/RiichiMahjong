using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public class ThirteenOrphansRiichiTestHand : TestHand
    {
        public ThirteenOrphansRiichiTestHand()
        {
            _closedTiles = new List<Tile> {
                OneMan(), NineMan(),
                OnePin(), NinePin(),
                OneSou(), NineSou(),
                EastWind(), SouthWind(),
                WestWind(), NorthWind(),
                GreenDragon(), RedDragon(),
                WhiteDragon(),
                OneMan()
            };
        }
    }
}
