using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Globals
{
    public static class StandardTileList
    {
        public static readonly TileObject ONE_MAN      = TileFactory.CreateTile(1, MAN);
        public static readonly TileObject TWO_MAN      = TileFactory.CreateTile(2, MAN);
        public static readonly TileObject THREE_MAN    = TileFactory.CreateTile(3, MAN);
        public static readonly TileObject FOUR_MAN     = TileFactory.CreateTile(4, MAN);
        public static readonly TileObject FIVE_MAN     = TileFactory.CreateTile(5, MAN);
        public static readonly TileObject SIX_MAN      = TileFactory.CreateTile(6, MAN);
        public static readonly TileObject SEVEN_MAN    = TileFactory.CreateTile(7, MAN);
        public static readonly TileObject EIGHT_MAN    = TileFactory.CreateTile(8, MAN);
        public static readonly TileObject NINE_MAN     = TileFactory.CreateTile(9, MAN);

        public static readonly TileObject ONE_PIN      = TileFactory.CreateTile(1, PIN);
        public static readonly TileObject TWO_PIN      = TileFactory.CreateTile(2, PIN);
        public static readonly TileObject THREE_PIN    = TileFactory.CreateTile(3, PIN);
        public static readonly TileObject FOUR_PIN     = TileFactory.CreateTile(4, PIN);
        public static readonly TileObject FIVE_PIN     = TileFactory.CreateTile(5, PIN);
        public static readonly TileObject SIX_PIN      = TileFactory.CreateTile(6, PIN);
        public static readonly TileObject SEVEN_PIN    = TileFactory.CreateTile(7, PIN);
        public static readonly TileObject EIGHT_PIN    = TileFactory.CreateTile(8, PIN);
        public static readonly TileObject NINE_PIN     = TileFactory.CreateTile(9, PIN);

        public static readonly TileObject ONE_SOU      = TileFactory.CreateTile(1, SOU);
        public static readonly TileObject TWO_SOU      = TileFactory.CreateTile(2, SOU);
        public static readonly TileObject THREE_SOU    = TileFactory.CreateTile(3, SOU);
        public static readonly TileObject FOUR_SOU     = TileFactory.CreateTile(4, SOU);
        public static readonly TileObject FIVE_SOU     = TileFactory.CreateTile(5, SOU);
        public static readonly TileObject SIX_SOU      = TileFactory.CreateTile(6, SOU);
        public static readonly TileObject SEVEN_SOU    = TileFactory.CreateTile(7, SOU);
        public static readonly TileObject EIGHT_SOU    = TileFactory.CreateTile(8, SOU);
        public static readonly TileObject NINE_SOU     = TileFactory.CreateTile(9, SOU);

        public static readonly TileObject EAST_WIND    = TileFactory.CreateTile(ConstValues.EAST_WIND_C,    WIND);
        public static readonly TileObject SOUTH_WIND   = TileFactory.CreateTile(ConstValues.SOUTH_WIND_C,   WIND);
        public static readonly TileObject WEST_WIND    = TileFactory.CreateTile(ConstValues.WEST_WIND_C,    WIND);
        public static readonly TileObject NORTH_WIND   = TileFactory.CreateTile(ConstValues.NORTH_WIND_C,   WIND);
        public static readonly TileObject GREEN_DRAGON = TileFactory.CreateTile(ConstValues.GREEN_DRAGON_C, DRAGON);
        public static readonly TileObject RED_DRAGON   = TileFactory.CreateTile(ConstValues.RED_DRAGON_C,   DRAGON);
        public static readonly TileObject WHITE_DRAGON = TileFactory.CreateTile(ConstValues.WHITE_DRAGON_C, DRAGON);

        public static TileObject OneMan()      { return ONE_MAN.Clone(); }
        public static TileObject TwoMan()      { return TWO_MAN.Clone(); }
        public static TileObject ThreeMan()    { return THREE_MAN.Clone(); }
        public static TileObject FourMan()     { return FOUR_MAN.Clone(); }
        public static TileObject FiveMan()     { return FIVE_MAN.Clone(); }
        public static TileObject SixMan()      { return SIX_MAN.Clone(); }
        public static TileObject SevenMan()    { return SEVEN_MAN.Clone(); }
        public static TileObject EightMan()    { return EIGHT_MAN.Clone(); }
        public static TileObject NineMan()     { return NINE_MAN.Clone(); }
        public static TileObject OnePin()      { return ONE_PIN.Clone(); }
        public static TileObject TwoPin()      { return TWO_PIN.Clone(); }
        public static TileObject ThreePin()    { return THREE_PIN.Clone(); }
        public static TileObject FourPin()     { return FOUR_PIN.Clone(); }
        public static TileObject FivePin()     { return FIVE_PIN.Clone(); }
        public static TileObject SixPin()      { return SIX_PIN.Clone(); }
        public static TileObject SevenPin()    { return SEVEN_PIN.Clone(); }
        public static TileObject EightPin()    { return EIGHT_PIN.Clone(); }
        public static TileObject NinePin()     { return NINE_PIN.Clone(); }
        public static TileObject OneSou()      { return ONE_SOU.Clone(); }
        public static TileObject TwoSou()      { return TWO_SOU.Clone(); }
        public static TileObject ThreeSou()    { return THREE_SOU.Clone(); }
        public static TileObject FourSou()     { return FOUR_SOU.Clone(); }
        public static TileObject FiveSou()     { return FIVE_SOU.Clone(); }
        public static TileObject SixSou()      { return SIX_SOU.Clone(); }
        public static TileObject SevenSou()    { return SEVEN_SOU.Clone(); }
        public static TileObject EightSou()    { return EIGHT_SOU.Clone(); }
        public static TileObject NineSou()     { return NINE_SOU.Clone(); }
        public static TileObject EastWind()    { return EAST_WIND.Clone(); }
        public static TileObject SouthWind()   { return SOUTH_WIND.Clone(); }
        public static TileObject WestWind()    { return WEST_WIND.Clone(); }
        public static TileObject NorthWind()   { return NORTH_WIND.Clone(); }
        public static TileObject GreenDragon() { return GREEN_DRAGON.Clone(); }
        public static TileObject RedDragon()   { return RED_DRAGON.Clone(); }
        public static TileObject WhiteDragon() { return WHITE_DRAGON.Clone(); }

        public static TileObject RedFiveMan()
        {
            TileObject tile = FiveMan();
            Functions.MakeRedFive(ref tile);
            return tile;
        }

        public static TileObject RedFivePin()
        {
            TileObject tile = FivePin();
            Functions.MakeRedFive(ref tile);
            return tile;
        }

        public static TileObject RedFiveSou()
        {
            TileObject tile = FiveSou();
            Functions.MakeRedFive(ref tile);
            return tile;
        }
    }
}
