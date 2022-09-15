using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class AllTerminalsAndHonorsTestHand : TestHand
    {
        public AllTerminalsAndHonorsTestHand()
        {
            _closedTiles = new List<Tile>
            {
                NineMan(), NineMan(), NineMan(),
                OneSou(), OneSou(), OneSou(),
                NinePin(), NinePin(), NinePin(),
                EastWind(), EastWind(), EastWind(),
                WhiteDragon()
            };
        }
    }
}