using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public class ClosedKanTestHand : TestHand
    {
        public ClosedKanTestHand()
        {
            _closedTiles = new() {
                RedDragon(), RedDragon(), RedDragon(), RedDragon(),
                NineSou(), NineSou(), NineSou(), NineSou(),
                ThreeMan(), ThreeMan(), ThreeMan(), ThreeMan(),
                OneMan()
            };
        }
    }
}
