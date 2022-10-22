using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class AllGreensTestHand : TestHand
{
    public AllGreensTestHand()
    {
        _closedTiles = new List<Tile>
        {
            TwoSou(), TwoSou(), TwoSou(),
            FourSou(), FourSou(), FourSou(),
            SixSou(), SixSou(), SixSou(),
            EightSou(), EightSou(),
            GreenDragon(), GreenDragon()
        };
    }
}