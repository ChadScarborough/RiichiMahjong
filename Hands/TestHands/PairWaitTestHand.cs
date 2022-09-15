using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class PairWaitTestHand : TestHand
{
    public PairWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(), OneMan(),
            ThreePin(), ThreePin(), ThreePin(),
            FiveSou(), FiveSou(), FiveSou(),
            EightMan(), EightMan(), EightMan(),
            RedDragon()
        };
        //Waiting on another red dragon
    }   
}