using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public class ArbitraryRiichiTestHand1 : TestHand
    {
        public ArbitraryRiichiTestHand1()
        {
            _closedTiles = new List<Tile>
            {
                OneMan(), OneMan(), TwoMan(), ThreeMan(),
                FourMan(), FourMan(), FiveMan(), SixMan(),
                SevenMan(), SevenMan(), EightMan(), NineMan(),
                NineMan(), NineMan()
            };
        }
    }
}
