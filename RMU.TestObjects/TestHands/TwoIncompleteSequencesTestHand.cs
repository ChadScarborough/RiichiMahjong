using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class TwoIncompleteSequencesTestHand : TestHand
{
    public TwoIncompleteSequencesTestHand()
    {
        _closedTiles = new List<Tile>
        {
            ThreeMan(), FourMan(),
            FivePin(), FivePin(), FivePin(),
            SevenSou(), SevenSou(), SevenSou(),
            NorthWind(), NorthWind(), NorthWind(),
            SevenMan(), EightMan()
        };
        //Should be one from tenpai
    }
}