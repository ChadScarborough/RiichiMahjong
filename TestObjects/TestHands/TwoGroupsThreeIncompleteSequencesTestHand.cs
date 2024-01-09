using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class TwoGroupsThreeIncompleteSequencesTestHand : TestHand
{
    public TwoGroupsThreeIncompleteSequencesTestHand()
    {
        _closedTiles = new List<Tile>
        {
            SixMan(), SevenMan(),
            OnePin(), ThreePin(),
            FivePin(), FivePin(), FivePin(),
            OneSou(), TwoSou(),
            SouthWind(), SouthWind(), SouthWind(),
            WestWind()
        };
        // Should have shanten of 2
    }
}
