using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Globals
{
    public static class StandardTileList
    {
        public static readonly Tile ONE_MAN      = TileFactory.CreateTile(1, MAN);
        public static readonly Tile TWO_MAN      = TileFactory.CreateTile(2, MAN);
        public static readonly Tile THREE_MAN    = TileFactory.CreateTile(3, MAN);
        public static readonly Tile FOUR_MAN     = TileFactory.CreateTile(4, MAN);
        public static readonly Tile FIVE_MAN     = TileFactory.CreateTile(5, MAN);
        public static readonly Tile SIX_MAN      = TileFactory.CreateTile(6, MAN);
        public static readonly Tile SEVEN_MAN    = TileFactory.CreateTile(7, MAN);
        public static readonly Tile EIGHT_MAN    = TileFactory.CreateTile(8, MAN);
        public static readonly Tile NINE_MAN     = TileFactory.CreateTile(9, MAN);

        public static readonly Tile ONE_PIN      = TileFactory.CreateTile(1, PIN);
        public static readonly Tile TWO_PIN      = TileFactory.CreateTile(2, PIN);
        public static readonly Tile THREE_PIN    = TileFactory.CreateTile(3, PIN);
        public static readonly Tile FOUR_PIN     = TileFactory.CreateTile(4, PIN);
        public static readonly Tile FIVE_PIN     = TileFactory.CreateTile(5, PIN);
        public static readonly Tile SIX_PIN      = TileFactory.CreateTile(6, PIN);
        public static readonly Tile SEVEN_PIN    = TileFactory.CreateTile(7, PIN);
        public static readonly Tile EIGHT_PIN    = TileFactory.CreateTile(8, PIN);
        public static readonly Tile NINE_PIN     = TileFactory.CreateTile(9, PIN);

        public static readonly Tile ONE_SOU      = TileFactory.CreateTile(1, SOU);
        public static readonly Tile TWO_SOU      = TileFactory.CreateTile(2, SOU);
        public static readonly Tile THREE_SOU    = TileFactory.CreateTile(3, SOU);
        public static readonly Tile FOUR_SOU     = TileFactory.CreateTile(4, SOU);
        public static readonly Tile FIVE_SOU     = TileFactory.CreateTile(5, SOU);
        public static readonly Tile SIX_SOU      = TileFactory.CreateTile(6, SOU);
        public static readonly Tile SEVEN_SOU    = TileFactory.CreateTile(7, SOU);
        public static readonly Tile EIGHT_SOU    = TileFactory.CreateTile(8, SOU);
        public static readonly Tile NINE_SOU     = TileFactory.CreateTile(9, SOU);

        public static readonly Tile EAST_WIND    = TileFactory.CreateTile(ConstValues.EAST_WIND_C,    WIND);
        public static readonly Tile SOUTH_WIND   = TileFactory.CreateTile(ConstValues.SOUTH_WIND_C,   WIND);
        public static readonly Tile WEST_WIND    = TileFactory.CreateTile(ConstValues.WEST_WIND_C,    WIND);
        public static readonly Tile NORTH_WIND   = TileFactory.CreateTile(ConstValues.NORTH_WIND_C,   WIND);
        public static readonly Tile GREEN_DRAGON = TileFactory.CreateTile(ConstValues.GREEN_DRAGON_C, DRAGON);
        public static readonly Tile RED_DRAGON   = TileFactory.CreateTile(ConstValues.RED_DRAGON_C,   DRAGON);
        public static readonly Tile WHITE_DRAGON = TileFactory.CreateTile(ConstValues.WHITE_DRAGON_C, DRAGON);

        public static Tile OneMan()      { return ONE_MAN.Clone(); }
        public static Tile TwoMan()      { return TWO_MAN.Clone(); }
        public static Tile ThreeMan()    { return THREE_MAN.Clone(); }
        public static Tile FourMan()     { return FOUR_MAN.Clone(); }
        public static Tile FiveMan()     { return FIVE_MAN.Clone(); }
        public static Tile SixMan()      { return SIX_MAN.Clone(); }
        public static Tile SevenMan()    { return SEVEN_MAN.Clone(); }
        public static Tile EightMan()    { return EIGHT_MAN.Clone(); }
        public static Tile NineMan()     { return NINE_MAN.Clone(); }
        public static Tile OnePin()      { return ONE_PIN.Clone(); }
        public static Tile TwoPin()      { return TWO_PIN.Clone(); }
        public static Tile ThreePin()    { return THREE_PIN.Clone(); }
        public static Tile FourPin()     { return FOUR_PIN.Clone(); }
        public static Tile FivePin()     { return FIVE_PIN.Clone(); }
        public static Tile SixPin()      { return SIX_PIN.Clone(); }
        public static Tile SevenPin()    { return SEVEN_PIN.Clone(); }
        public static Tile EightPin()    { return EIGHT_PIN.Clone(); }
        public static Tile NinePin()     { return NINE_PIN.Clone(); }
        public static Tile OneSou()      { return ONE_SOU.Clone(); }
        public static Tile TwoSou()      { return TWO_SOU.Clone(); }
        public static Tile ThreeSou()    { return THREE_SOU.Clone(); }
        public static Tile FourSou()     { return FOUR_SOU.Clone(); }
        public static Tile FiveSou()     { return FIVE_SOU.Clone(); }
        public static Tile SixSou()      { return SIX_SOU.Clone(); }
        public static Tile SevenSou()    { return SEVEN_SOU.Clone(); }
        public static Tile EightSou()    { return EIGHT_SOU.Clone(); }
        public static Tile NineSou()     { return NINE_SOU.Clone(); }
        public static Tile EastWind()    { return EAST_WIND.Clone(); }
        public static Tile SouthWind()   { return SOUTH_WIND.Clone(); }
        public static Tile WestWind()    { return WEST_WIND.Clone(); }
        public static Tile NorthWind()   { return NORTH_WIND.Clone(); }
        public static Tile GreenDragon() { return GREEN_DRAGON.Clone(); }
        public static Tile RedDragon()   { return RED_DRAGON.Clone(); }
        public static Tile WhiteDragon() { return WHITE_DRAGON.Clone(); }

        public static Tile RedFiveMan()
        {
            Tile tile = FiveMan();
            Functions.MakeRedFive(ref tile);
            return tile;
        }

        public static Tile RedFivePin()
        {
            Tile tile = FivePin();
            Functions.MakeRedFive(ref tile);
            return tile;
        }

        public static Tile RedFiveSou()
        {
            Tile tile = FiveSou();
            Functions.MakeRedFive(ref tile);
            return tile;
        }
    }
}
