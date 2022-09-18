using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class AllTerminalsAndHonorsTestHand : TestHand
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