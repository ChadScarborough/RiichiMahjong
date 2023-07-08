using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;
using System;

namespace RMU.Globals;

public static class Functions
{
    public static int MinOfThree(int a, int b, int c)
    {
        return a <= b && a <= c ? a : b <= a && b <= c ? b : c;
    }

    private static int Min(int a, int b)
    {
        return a < b ? a : b;
    }

    public static int MinOfEight(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        int int1 = MinOfThree(a, b, c);
        int int2 = MinOfThree(d, e, f);
        int int3 = Min(g, h);
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

    public static bool AreTilesEquivalent(Tile tile1, Tile tile2)
    {
        if (tile1 is null || tile2 is null)
        {
            return false;
        }

        try
        {
            Suit suit1 = tile1.GetSuit();
            Suit suit2 = tile2.GetSuit();
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
        (Tile tile1, Tile tile2, Tile tile3)
    {
        return AreTilesEquivalent(tile1, tile2) && AreTilesEquivalent(tile2, tile3);
    }

    public static bool AreTilesEquivalent
        (Tile tile1, Tile tile2, Tile tile3, Tile tile4)
    {
        return AreTilesEquivalent(tile1, tile2, tile3) && AreTilesEquivalent(tile3, tile4);
    }

    public static bool AreWindsEquivalent(Tile windTile, Wind wind)
    {
        return windTile.GetSuit() == WIND
        && windTile.GetValue() switch
        {
            EAST_WIND_C => wind == EAST,
            SOUTH_WIND_C => wind == SOUTH,
            WEST_WIND_C => wind == WEST,
            NORTH_WIND_C => wind == NORTH,
            _ => false,
        };
    }

    public static bool DoTilesFormValidSequence
        (Tile bottomTile, Tile middleTile, Tile topTile)
    {
        bool sameSuit = bottomTile.GetSuit() == middleTile.GetSuit() && middleTile.GetSuit() == topTile.GetSuit();
        bool bottomTwoTilesCorrect = AreTilesEquivalent(bottomTile, GetTileBelow(middleTile));
        bool topTwoTilesCorrect = AreTilesEquivalent(middleTile, GetTileBelow(topTile));
        return sameSuit && bottomTwoTilesCorrect && topTwoTilesCorrect;
    }

    public static bool AreDragonsEquivalent(Tile dragonTile, Dragon dragon)
    {
        return dragonTile != null
        && dragonTile.GetSuit() == DRAGON
        && dragonTile.GetValue() switch
        {
            GREEN_DRAGON_C => dragon == GREEN,
            RED_DRAGON_C => dragon == RED,
            WHITE_DRAGON_C => dragon == WHITE,
            _ => false,
        };
    }

    public static Tile GetTileAbove(Tile tile)
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

    public static Tile GetTileTwoAbove(Tile tile)
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

    public static Tile GetTileBelow(Tile tile)
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

    public static Tile GetTileTwoBelow(Tile tile)
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

    public static void AddDoraValue(ref Tile tile)
    {
        tile = new DoraDecorator(tile);
    }

    public static void AddUraDoraValue(ref Tile tile)
    {
        tile = new UraDoraDecorator(tile);
    }

    public static void MakeRedFive(ref Tile tile)
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
        return input ? 1 : 0;
    }

    public static bool AreComponentsEquivalent(ICompleteHandComponent component1, ICompleteHandComponent component2)
    {
        Tile tile1 = component1.GetLeadTile();
        Tile tile2 = component2.GetLeadTile();
        CompleteHandComponentType componentType1 = component1.GetComponentType();
        CompleteHandComponentType componentType2 = component2.GetComponentType();
        bool sameTile = AreTilesEquivalent(tile1, tile2);
        bool sameComponentType = componentType1 == componentType2;
        return sameTile && sameComponentType;
    }

    public static Tile GetIndicatedDoraTile(Tile doraIndicator)
    {
        return doraIndicator.GetSuit() switch
        {
            MAN or PIN or SOU => GetIndicatedNumberDoraTile(doraIndicator),
            WIND => GetIndicatedWindDoraTile(doraIndicator),
            DRAGON => GetIndictedDragonDoraTile(doraIndicator),
            _ => throw new ArgumentException("Invalid suit")
        };
    }

    private static Tile GetIndicatedNumberDoraTile(Tile doraIndicator)
    {
        return doraIndicator.GetValue() switch
        {
            9 => TileFactory.CreateTile(1, doraIndicator.GetSuit()),
            _ => TileFactory.CreateTile(doraIndicator.GetValue() + 1, doraIndicator.GetSuit())
        };
    }

    private static Tile GetIndicatedWindDoraTile(Tile doraIndicator)
    {
        return doraIndicator.GetValue() switch
        {
            NORTH_WIND_C => TileFactory.CreateTile(EAST_WIND_C, doraIndicator.GetSuit()),
            _ => TileFactory.CreateTile(doraIndicator.GetValue() + 1, doraIndicator.GetSuit())
        };
    }

    private static Tile GetIndictedDragonDoraTile(Tile doraIndicator)
    {
        return doraIndicator.GetValue() switch
        {
            WHITE_DRAGON_C => TileFactory.CreateTile(GREEN_DRAGON_C, doraIndicator.GetSuit()),
            _ => TileFactory.CreateTile(doraIndicator.GetValue() + 1, doraIndicator.GetSuit())
        };
    }
}
