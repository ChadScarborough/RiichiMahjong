using RMU.Tiles;

namespace RMU.TestObjects.TestHands
{
    public sealed class OpenKan1TestHand : TestHand
    {
        public OpenKan1TestHand()
        {
            _closedTiles = new()
            {
                FourPin(), FourPin(), FourPin(),
                TwoMan(), FiveMan(), EightMan(),
                OneSou(), FourSou(), SevenSou(),
                NorthWind(), NorthWind(), NorthWind(),
                RedDragon()
            };
        }
    }
}
