﻿using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryTestHand2 : TestHand
{
    public ArbitraryTestHand2() //Should have shanten value of four
    {
        _closedTiles = new List<Tile>
        {
            NinePin(), OneMan(), ThreePin(), NinePin(), NineMan(), NinePin(), EightPin(),
            SevenSou(), SevenSou(), GreenDragon(), FiveSou(), RedDragon(), TwoPin()
        };
    }
}
