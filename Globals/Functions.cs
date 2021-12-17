using System;
using RMU.Tiles;

namespace RMU.Globals
{
    public static class Functions
    {
        public static int MinOfThree(int a, int b, int c)
        {
            return (int)MathF.Round(MathF.Min(a, MathF.Min(b, c)));
        }

        public static int MinOfEight(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int int1 = MinOfThree(a, b, c);
            int int2 = MinOfThree(d, e, f);
            int int3 = Math.Min(g, h);
            return MinOfThree(int1, int2, int3);
        }

        public static bool AreTilesEquivalent(TileObject tile1, TileObject tile2)
        {
            Enums.Suit suit1 = tile1.GetSuit();
            Enums.Suit suit2 = tile2.GetSuit();
            int value1 = tile1.GetValue();
            int value2 = tile2.GetValue();
            bool sameSuit = suit1 == suit2;
            bool sameValue = value1 == value2;
            return sameSuit && sameValue;
        }

        public static bool AreTilesEquivalent(TileObject tile1, TileObject tile2, TileObject tile3)
        {
            return AreTilesEquivalent(tile1, tile2) && AreTilesEquivalent(tile2, tile3);
        }

        public static bool AreWindsEquivalent(TileObject windTile, Enums.Wind wind)
        {
            if (windTile.GetSuit() != Enums.WIND) return false;
            switch (windTile.GetValue())
            {
                case ConstValues.EAST_WIND:
                    return wind == Enums.EAST;
                case ConstValues.SOUTH_WIND:
                    return wind == Enums.SOUTH;
                case ConstValues.WEST_WIND:
                    return wind == Enums.WEST;
                case ConstValues.NORTH_WIND:
                    return wind == Enums.NORTH;
                default:
                    return false;
            }
        }

        public static bool AreDragonsEquivalent(TileObject dragonTile, Enums.Dragon dragon)
        {
            if (dragonTile.GetSuit() != Enums.DRAGON) return false;
            switch (dragonTile.GetValue())
            {
                case ConstValues.GREEN_DRAGON:
                    return dragon == Enums.GREEN;
                case ConstValues.RED_DRAGON:
                    return dragon == Enums.RED;
                case ConstValues.WHITE_DRAGON:
                    return dragon == Enums.WHITE;
                default:
                    return false;
            }
        }

        public static TileObject GetTileAbove(TileObject tile)
        {
            return tile.GetTileAbove();
        }

        public static TileObject GetTileTwoAbove(TileObject tile)
        {
            return tile.GetTileAbove().GetTileAbove();
        }

        public static TileObject GetTileBelow(TileObject tile)
        {
            return tile.GetTileBelow();
        }

        public static TileObject GetTileTwoBelow(TileObject tile)
        {
            return tile.GetTileBelow().GetTileBelow();
        }
    }
}
