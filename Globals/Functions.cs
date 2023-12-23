using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;
using RMU.Yaku.StandardYaku;
using RMU.Yaku.Yakuman;
using RMU.Yaku;
using System;
namespace RMU.Globals
{
    public static class Functions
    {
        // Returns the smallest of three integers
        public static int MinOfThree(int a, int b, int c)
        {
            return a <= b && a <= c ? a : b <= a && b <= c ? b : c;
        }
         // Returns the smallest of two integers
        private static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
         // Returns the smallest of eight integers
        public static int MinOfEight(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int int1 = MinOfThree(a, b, c);
            int int2 = MinOfThree(d, e, f);
            int int3 = Min(g, h);
            return MinOfThree(int1, int2, int3);
        }
         // Returns the smallest integer in an array
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
         // Compares two tiles for equivalence
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
         // Compares three tiles for equivalence
        public static bool AreTilesEquivalent(Tile tile1, Tile tile2, Tile tile3)
        {
            return AreTilesEquivalent(tile1, tile2) && AreTilesEquivalent(tile2, tile3);
        }
         // Compares four tiles for equivalence
        public static bool AreTilesEquivalent(Tile tile1, Tile tile2, Tile tile3, Tile tile4)
        {
            return AreTilesEquivalent(tile1, tile2, tile3) && AreTilesEquivalent(tile3, tile4);
        }
         // Checks if a tile and a wind are equivalent
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
         // Checks if three tiles form a valid sequence
        public static bool DoTilesFormValidSequence(Tile bottomTile, Tile middleTile, Tile topTile)
        {
            bool sameSuit = bottomTile.GetSuit() == middleTile.GetSuit() && middleTile.GetSuit() == topTile.GetSuit();
            bool bottomTwoTilesCorrect = AreTilesEquivalent(bottomTile, GetTileBelow(middleTile));
            bool topTwoTilesCorrect = AreTilesEquivalent(middleTile, GetTileBelow(topTile));
            return sameSuit && bottomTwoTilesCorrect && topTwoTilesCorrect;
        }
         // Checks if a tile and a dragon are equivalent
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
         // Returns the tile above the current tile
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
         // Returns the tile two above the current tile
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
         // Returns the tile below the current tile
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
         // Returns the tile two below the current tile
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
         // Adds Dora value to a tile
        public static void AddDoraValue(ref Tile tile)
        {
            tile = new DoraDecorator(tile);
        }
         // Adds UraDora value to a tile
        public static void AddUraDoraValue(ref Tile tile)
        {
            tile = new UraDoraDecorator(tile);
        }
         // Makes a tile a Red Five if its value is 5
        public static void MakeRedFive(ref Tile tile)
        {
            if (tile.GetValue() == 5)
            {
                tile = new RedFiveDecorator(tile);
                return;
            }
            throw new ArgumentException("Input tile did not have value 5");
        }
         // Converts a boolean to an integer
        public static int BoolToInt(bool input)
        {
            return input ? 1 : 0;
        }
         // Compares two components for equivalence
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
         // Returns the indicated Dora tile
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
         // Returns the indicated number Dora tile
        private static Tile GetIndicatedNumberDoraTile(Tile doraIndicator)
        {
            return doraIndicator.GetValue() switch
            {
                9 => TileFactory.CreateTile(1, doraIndicator.GetSuit()),
                _ => TileFactory.CreateTile(doraIndicator.GetValue() + 1, doraIndicator.GetSuit())
            };
        }
         // Returns the indicated wind Dora tile
        private static Tile GetIndicatedWindDoraTile(Tile doraIndicator)
        {
            return doraIndicator.GetValue() switch
            {
                NORTH_WIND_C => TileFactory.CreateTile(EAST_WIND_C, doraIndicator.GetSuit()),
                _ => TileFactory.CreateTile(doraIndicator.GetValue() + 1, doraIndicator.GetSuit())
            };
        }
         // Returns the indicted dragon Dora tile
        private static Tile GetIndictedDragonDoraTile(Tile doraIndicator)
        {
            return doraIndicator.GetValue() switch
            {
                WHITE_DRAGON_C => TileFactory.CreateTile(GREEN_DRAGON_C, doraIndicator.GetSuit()),
                _ => TileFactory.CreateTile(doraIndicator.GetValue() + 1, doraIndicator.GetSuit())
            };
        }

        // Determines whether a completed hand satisfies at least one yaku and can therefore call Ron or Tsumo
        public static bool AtLeastOneYakuSatisfied(List<ICompleteHand> completeHands)
        {
            bool yakuSatisfied = false;
            foreach (ICompleteHand completeHand in completeHands)
            {
                completeHand.ClearYaku();
                YakumanList yakumanList = new(completeHand);
                StandardYakuList yakuList = new(completeHand);
                List<YakuBase> satisfiedYaku = new();
                satisfiedYaku.AddRange(yakumanList.CheckYakuman());
                if (satisfiedYaku.Count == 0)
                {
                    satisfiedYaku.AddRange(yakuList.CheckYaku());
                }

                completeHand.SetYaku(satisfiedYaku);
                if (satisfiedYaku.Count > 0)
                {
                    yakuSatisfied = true;
                }
            }
            return yakuSatisfied;
        }
    }
}