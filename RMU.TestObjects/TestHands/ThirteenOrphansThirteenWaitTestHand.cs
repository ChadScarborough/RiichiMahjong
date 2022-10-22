using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ThirteenOrphansThirteenWaitTestHand : TestHand
{
    public ThirteenOrphansThirteenWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), NineMan(),
            OnePin(), NinePin(),
            OneSou(), NineSou(),
            EastWind(), SouthWind(),
            WestWind(), NorthWind(),
            GreenDragon(),
            RedDragon(),
            WhiteDragon()
        };
    }
}