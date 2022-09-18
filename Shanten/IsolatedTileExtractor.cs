using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Shanten;

public static class IsolatedTileExtractor
{
    public static List<ICompleteHandComponent> ExtractIsolatedTiles(TileCollection collection)
    {
        List<ICompleteHandComponent> outputList = new();
        foreach (Tile tile in collection.GetTiles())
        {
            ICompleteHandComponent component = CompleteHandComponentFactory.CreateCompleteHandComponent(tile, ISOLATED_TILE);
            outputList.Add(component);
        }

        return outputList;
    }
}