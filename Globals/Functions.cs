using System;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;
using static RMU.Globals.Enums;

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

        public static int MinOfArray(int[] array)
        {
            int length = array.Length;
            int min = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static bool AreTilesEquivalent(TileObject tile1, TileObject tile2)
        {
            try
            {
                Enums.Suit suit1 = tile1.GetSuit();
                Enums.Suit suit2 = tile2.GetSuit();
                int value1 = tile1.GetValue();
                int value2 = tile2.GetValue();
                bool sameSuit = suit1 == suit2;
                bool sameValue = value1 == value2;
                return sameSuit && sameValue;
            }
            catch
            {
                return false;
            }
        }

        public static bool AreTilesEquivalent
            (TileObject tile1, TileObject tile2, TileObject tile3)
        {
            return AreTilesEquivalent(tile1, tile2) && AreTilesEquivalent(tile2, tile3);
        }

        public static bool AreTilesEquivalent
            (TileObject tile1, TileObject tile2, TileObject tile3, TileObject tile4)
        {
            return AreTilesEquivalent(tile1, tile2, tile3) && AreTilesEquivalent(tile3, tile4);
        }

        public static bool AreWindsEquivalent(TileObject windTile, Enums.Wind wind)
        {
            if (windTile.GetSuit() != Enums.WIND) return false;
            switch (windTile.GetValue())
            {
                case ConstValues.EAST_WIND_C:
                    return wind == Enums.EAST;
                case ConstValues.SOUTH_WIND_C:
                    return wind == Enums.SOUTH;
                case ConstValues.WEST_WIND_C:
                    return wind == Enums.WEST;
                case ConstValues.NORTH_WIND_C:
                    return wind == Enums.NORTH;
            }
            return false;
        }

        public static bool DoTilesFormValidSequence
            (TileObject bottomTile, TileObject middleTile, TileObject topTile)
        {
            bool sameSuit = bottomTile.GetSuit() == middleTile.GetSuit() && middleTile.GetSuit() == topTile.GetSuit();
            bool bottomTwoTilesCorrect = AreTilesEquivalent(bottomTile, GetTileBelow(middleTile));
            bool topTwoTilesCorrect = AreTilesEquivalent(middleTile, GetTileBelow(topTile));
            return sameSuit && bottomTwoTilesCorrect && topTwoTilesCorrect;
        }

        public static bool AreDragonsEquivalent(TileObject dragonTile, Enums.Dragon dragon)
        {
            if (dragonTile == null) return false;
            if (dragonTile.GetSuit() != Enums.DRAGON) return false;
            switch (dragonTile.GetValue())
            {
                case ConstValues.GREEN_DRAGON_C:
                    return dragon == Enums.GREEN;
                case ConstValues.RED_DRAGON_C:
                    return dragon == Enums.RED;
                case ConstValues.WHITE_DRAGON_C:
                    return dragon == Enums.WHITE;
            }
            return false;
        }

        public static TileObject GetTileAbove(TileObject tile)
        {
            try
            {
                return tile.GetTileAbove();
            }
            catch
            {
                return null;
            }
        }

        public static TileObject GetTileTwoAbove(TileObject tile)
        {
            try
            {
                return tile.GetTileAbove().GetTileAbove();
            }
            catch
            {
                return null;
            }
        }

        public static TileObject GetTileBelow(TileObject tile)
        {
            try
            {
                return tile.GetTileBelow();
            }
            catch
            {
                return null;
            }
        }

        public static TileObject GetTileTwoBelow(TileObject tile)
        {
            try
            {
                return tile.GetTileBelow().GetTileBelow();
            }
            catch
            {
                return null;
            }
        }

        public static void AddDoraValue(ref TileObject tile)
        {
            tile = new DoraDecorator(tile);
        }

        public static void AddUraDoraValue(ref TileObject tile)
        {
            tile = new UraDoraDecorator(tile);
        }

        public static void MakeRedFive(ref TileObject tile)
        {
            if (tile.GetValue() == 5)
            {
                tile = new RedFiveDecorator(tile);
                return;
            }
            throw new ArgumentException("Input tile did not have value 5");
        }

        public static int BoolToInt(bool input)
        {
            if (input) return 1;
            return 0;
        }

        public static bool AreComponentsEquivalent(ICompleteHandComponent component1, ICompleteHandComponent component2)
        {
            TileObject tile1 = component1.GetLeadTile();
            TileObject tile2 = component2.GetLeadTile();
            CompleteHandComponentType componentType1 = component1.GetComponentType();
            CompleteHandComponentType componentType2 = component2.GetComponentType();
            bool sameTile = AreTilesEquivalent(tile1, tile2);
            bool sameComponentType = componentType1 == componentType2;
            return sameTile && sameComponentType;
        }
    }
}
