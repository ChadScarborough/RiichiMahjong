using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class EdgeWaitTestHand : TestHand
{
    public EdgeWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), TwoMan(),
            ThreePin(), ThreePin(), ThreePin(),
            TwoSou(), ThreeSou(), FourSou(),
            NineMan(), NineMan(), NineMan(),
            SouthWind(), SouthWind()
        };
        //Waiting on Three Man
    }
}