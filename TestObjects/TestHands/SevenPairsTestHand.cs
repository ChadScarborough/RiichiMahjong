using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class SevenPairsTestHand : TestHand
{
    public SevenPairsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(),
            FourPin(), FourPin(),
            ThreeSou(), ThreeSou(),
            FiveMan(), FiveMan(),
            SixSou(), SixSou(),
            SouthWind(), SouthWind(),
            RedDragon()
        };
        //Waiting on Red Dragon
    }
}