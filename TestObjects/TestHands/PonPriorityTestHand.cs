using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public sealed class PonPriorityTestHand : TestHand
    {
        public PonPriorityTestHand()
        {
            _closedTiles = new List<Tile>
            {
                RedDragon(), RedDragon(),
                OneMan(), FourMan(), SevenMan(),
                TwoPin(), FivePin(), EightPin(),
                ThreeSou(), SixSou(), NineSou(),
                WestWind(), WhiteDragon()
            };
        }
    }
}

