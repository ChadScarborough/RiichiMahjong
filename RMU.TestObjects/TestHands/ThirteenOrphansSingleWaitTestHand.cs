using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ThirteenOrphansSingleWaitTestHand : TestHand
{
    public ThirteenOrphansSingleWaitTestHand()
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
            RedDragon()
        };
        //Waiting on White Dragon
    }
}