using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Globals
{
    public static class StandardTileList
    {
        public static readonly TileObject ONE_MAN = TileFactory.CreateTile(1, Enums.Suit.Man);
        public static readonly TileObject TWO_MAN = TileFactory.CreateTile(2, Enums.Suit.Man);
        public static readonly TileObject THREE_MAN = TileFactory.CreateTile(3, Enums.Suit.Man);
        public static readonly TileObject FOUR_MAN = TileFactory.CreateTile(4, Enums.Suit.Man);
        public static readonly TileObject FIVE_MAN = TileFactory.CreateTile(5, Enums.Suit.Man);
        public static readonly TileObject SIX_MAN = TileFactory.CreateTile(6, Enums.Suit.Man);
        public static readonly TileObject SEVEN_MAN = TileFactory.CreateTile(7, Enums.Suit.Man);
        public static readonly TileObject EIGHT_MAN = TileFactory.CreateTile(8, Enums.Suit.Man);
        public static readonly TileObject NINE_MAN = TileFactory.CreateTile(9, Enums.Suit.Man);

        public static readonly TileObject ONE_PIN = TileFactory.CreateTile(1, Enums.Suit.Pin);
        public static readonly TileObject TWO_PIN = TileFactory.CreateTile(2, Enums.Suit.Pin);
        public static readonly TileObject THREE_PIN = TileFactory.CreateTile(3, Enums.Suit.Pin);
        public static readonly TileObject FOUR_PIN = TileFactory.CreateTile(4, Enums.Suit.Pin);
        public static readonly TileObject FIVE_PIN = TileFactory.CreateTile(5, Enums.Suit.Pin);
        public static readonly TileObject SIX_PIN = TileFactory.CreateTile(6, Enums.Suit.Pin);
        public static readonly TileObject SEVEN_PIN = TileFactory.CreateTile(7, Enums.Suit.Pin);
        public static readonly TileObject EIGHT_PIN = TileFactory.CreateTile(8, Enums.Suit.Pin);
        public static readonly TileObject NINE_PIN = TileFactory.CreateTile(9, Enums.Suit.Pin);

        public static readonly TileObject ONE_SOU = TileFactory.CreateTile(1, Enums.Suit.Sou);
        public static readonly TileObject TWO_SOU = TileFactory.CreateTile(2, Enums.Suit.Sou);
        public static readonly TileObject THREE_SOU = TileFactory.CreateTile(3, Enums.Suit.Sou);
        public static readonly TileObject FOUR_SOU = TileFactory.CreateTile(4, Enums.Suit.Sou);
        public static readonly TileObject FIVE_SOU = TileFactory.CreateTile(5, Enums.Suit.Sou);
        public static readonly TileObject SIX_SOU = TileFactory.CreateTile(6, Enums.Suit.Sou);
        public static readonly TileObject SEVEN_SOU = TileFactory.CreateTile(7, Enums.Suit.Sou);
        public static readonly TileObject EIGHT_SOU = TileFactory.CreateTile(8, Enums.Suit.Sou);
        public static readonly TileObject NINE_SOU = TileFactory.CreateTile(9, Enums.Suit.Sou);

        public static readonly TileObject EAST_WIND = TileFactory.CreateTile(ConstValues.EAST_WIND, Enums.Suit.Wind);
        public static readonly TileObject SOUTH_WIND = TileFactory.CreateTile(ConstValues.SOUTH_WIND, Enums.Suit.Wind);
        public static readonly TileObject WEST_WIND = TileFactory.CreateTile(ConstValues.WEST_WIND, Enums.Suit.Wind);
        public static readonly TileObject NORTH_WIND = TileFactory.CreateTile(ConstValues.NORTH_WIND, Enums.Suit.Wind);

        public static readonly TileObject GREEN_DRAGON = TileFactory.CreateTile(ConstValues.GREEN_DRAGON, Enums.Suit.Dragon);
        public static readonly TileObject RED_DRAGON = TileFactory.CreateTile(ConstValues.RED_DRAGON, Enums.Suit.Dragon);
        public static readonly TileObject WHITE_DRAGON = TileFactory.CreateTile(ConstValues.WHITE_DRAGON, Enums.Suit.Dragon);

    }
}
