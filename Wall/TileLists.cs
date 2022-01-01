using System.Collections.Generic;
using static RMU.Globals.StandardTileList;
using RMU.Tiles;

namespace RMU.Wall
{
    public static class TileLists
    {
        private static readonly List<TileObject> _standardWallNoRedFives = new List<TileObject>
        {
            OneMan(), OneMan(), OneMan(), OneMan(),
            TwoMan(), TwoMan(), TwoMan(), TwoMan(),
            ThreeMan(), ThreeMan(), ThreeMan(), ThreeMan(),
            FourMan(), FourMan(), FourMan(), FourMan(),
            FiveMan(), FiveMan(), FiveMan(), FiveMan(),
            SixMan(), SixMan(), SixMan(), SixMan(),
            SevenMan(), SevenMan(), SevenMan(), SevenMan(),
            EightMan(), EightMan(), EightMan(), EightMan(),
            NineMan(), NineMan(), NineMan(), NineMan(),
            
            OnePin(), OnePin(), OnePin(), OnePin(),
            TwoPin(), TwoPin(), TwoPin(), TwoPin(),
            ThreePin(), ThreePin(), ThreePin(), ThreePin(),
            FourPin(), FourPin(), FourPin(), FourPin(),
            FivePin(), FivePin(), FivePin(), FivePin(),
            SixPin(), SixPin(), SixPin(), SixPin(),
            SevenPin(), SevenPin(), SevenPin(), SevenPin(),
            EightPin(), EightPin(), EightPin(), EightPin(),
            NinePin(), NinePin(), NinePin(), NinePin(),
            
            OneSou(), OneSou(), OneSou(), OneSou(),
            TwoSou(), TwoSou(), TwoSou(), TwoSou(),
            ThreeSou(), ThreeSou(), ThreeSou(), ThreeSou(),
            FourSou(), FourSou(), FourSou(), FourSou(),
            FiveSou(), FiveSou(), FiveSou(), FiveSou(),
            SixSou(), SixSou(), SixSou(), SixSou(),
            SevenSou(), SevenSou(), SevenSou(), SevenSou(),
            EightSou(), EightSou(), EightSou(), EightSou(),
            NineSou(), NineSou(), NineSou(), NineSou(),
            
            EastWind(), EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(), NorthWind(),
            
            GreenDragon(), GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(), WhiteDragon()
        };
        
        private static readonly List<TileObject> _standardWallThreeRedFives = new List<TileObject>
        {
            OneMan(), OneMan(), OneMan(), OneMan(),
            TwoMan(), TwoMan(), TwoMan(), TwoMan(),
            ThreeMan(), ThreeMan(), ThreeMan(), ThreeMan(),
            FourMan(), FourMan(), FourMan(), FourMan(),
            RedFiveMan(), FiveMan(), FiveMan(), FiveMan(),
            SixMan(), SixMan(), SixMan(), SixMan(),
            SevenMan(), SevenMan(), SevenMan(), SevenMan(),
            EightMan(), EightMan(), EightMan(), EightMan(),
            NineMan(), NineMan(), NineMan(), NineMan(),
            
            OnePin(), OnePin(), OnePin(), OnePin(),
            TwoPin(), TwoPin(), TwoPin(), TwoPin(),
            ThreePin(), ThreePin(), ThreePin(), ThreePin(),
            FourPin(), FourPin(), FourPin(), FourPin(),
            RedFivePin(), FivePin(), FivePin(), FivePin(),
            SixPin(), SixPin(), SixPin(), SixPin(),
            SevenPin(), SevenPin(), SevenPin(), SevenPin(),
            EightPin(), EightPin(), EightPin(), EightPin(),
            NinePin(), NinePin(), NinePin(), NinePin(),
            
            OneSou(), OneSou(), OneSou(), OneSou(),
            TwoSou(), TwoSou(), TwoSou(), TwoSou(),
            ThreeSou(), ThreeSou(), ThreeSou(), ThreeSou(),
            FourSou(), FourSou(), FourSou(), FourSou(),
            RedFiveSou(), FiveSou(), FiveSou(), FiveSou(),
            SixSou(), SixSou(), SixSou(), SixSou(),
            SevenSou(), SevenSou(), SevenSou(), SevenSou(),
            EightSou(), EightSou(), EightSou(), EightSou(),
            NineSou(), NineSou(), NineSou(), NineSou(),
            
            EastWind(), EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(), NorthWind(),
            
            GreenDragon(), GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(), WhiteDragon()
        };

        private static readonly List<TileObject> _standardWallFourRedFives = new List<TileObject>
        {
            OneMan(), OneMan(), OneMan(), OneMan(),
            TwoMan(), TwoMan(), TwoMan(), TwoMan(),
            ThreeMan(), ThreeMan(), ThreeMan(), ThreeMan(),
            FourMan(), FourMan(), FourMan(), FourMan(),
            RedFiveMan(), FiveMan(), FiveMan(), FiveMan(),
            SixMan(), SixMan(), SixMan(), SixMan(),
            SevenMan(), SevenMan(), SevenMan(), SevenMan(),
            EightMan(), EightMan(), EightMan(), EightMan(),
            NineMan(), NineMan(), NineMan(), NineMan(),
            
            OnePin(), OnePin(), OnePin(), OnePin(),
            TwoPin(), TwoPin(), TwoPin(), TwoPin(),
            ThreePin(), ThreePin(), ThreePin(), ThreePin(),
            FourPin(), FourPin(), FourPin(), FourPin(),
            RedFivePin(), RedFivePin(), FivePin(), FivePin(),
            SixPin(), SixPin(), SixPin(), SixPin(),
            SevenPin(), SevenPin(), SevenPin(), SevenPin(),
            EightPin(), EightPin(), EightPin(), EightPin(),
            NinePin(), NinePin(), NinePin(), NinePin(),
            
            OneSou(), OneSou(), OneSou(), OneSou(),
            TwoSou(), TwoSou(), TwoSou(), TwoSou(),
            ThreeSou(), ThreeSou(), ThreeSou(), ThreeSou(),
            FourSou(), FourSou(), FourSou(), FourSou(),
            RedFiveSou(), FiveSou(), FiveSou(), FiveSou(),
            SixSou(), SixSou(), SixSou(), SixSou(),
            SevenSou(), SevenSou(), SevenSou(), SevenSou(),
            EightSou(), EightSou(), EightSou(), EightSou(),
            NineSou(), NineSou(), NineSou(), NineSou(),
            
            EastWind(), EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(), NorthWind(),
            
            GreenDragon(), GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(), WhiteDragon()
        };

        private static readonly List<TileObject> _threePlayerWallNoRedFives = new List<TileObject>
        {
            OneMan(), OneMan(), OneMan(), OneMan(),

            NineMan(), NineMan(), NineMan(), NineMan(),

            OnePin(), OnePin(), OnePin(), OnePin(),
            TwoPin(), TwoPin(), TwoPin(), TwoPin(),
            ThreePin(), ThreePin(), ThreePin(), ThreePin(),
            FourPin(), FourPin(), FourPin(), FourPin(),
            FivePin(), FivePin(), FivePin(), FivePin(),
            SixPin(), SixPin(), SixPin(), SixPin(),
            SevenPin(), SevenPin(), SevenPin(), SevenPin(),
            EightPin(), EightPin(), EightPin(), EightPin(),
            NinePin(), NinePin(), NinePin(), NinePin(),

            OneSou(), OneSou(), OneSou(), OneSou(),
            TwoSou(), TwoSou(), TwoSou(), TwoSou(),
            ThreeSou(), ThreeSou(), ThreeSou(), ThreeSou(),
            FourSou(), FourSou(), FourSou(), FourSou(),
            FiveSou(), FiveSou(), FiveSou(), FiveSou(),
            SixSou(), SixSou(), SixSou(), SixSou(),
            SevenSou(), SevenSou(), SevenSou(), SevenSou(),
            EightSou(), EightSou(), EightSou(), EightSou(),
            NineSou(), NineSou(), NineSou(), NineSou(),

            EastWind(), EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(), NorthWind(),

            GreenDragon(), GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(), WhiteDragon()
        };

        private static readonly List<TileObject> _threePlayerWallWithRedFives = new List<TileObject>
        {
            OneMan(), OneMan(), OneMan(), OneMan(),

            NineMan(), NineMan(), NineMan(), NineMan(),

            OnePin(), OnePin(), OnePin(), OnePin(),
            TwoPin(), TwoPin(), TwoPin(), TwoPin(),
            ThreePin(), ThreePin(), ThreePin(), ThreePin(),
            FourPin(), FourPin(), FourPin(), FourPin(),
            RedFivePin(), FivePin(), FivePin(), FivePin(),
            SixPin(), SixPin(), SixPin(), SixPin(),
            SevenPin(), SevenPin(), SevenPin(), SevenPin(),
            EightPin(), EightPin(), EightPin(), EightPin(),
            NinePin(), NinePin(), NinePin(), NinePin(),

            OneSou(), OneSou(), OneSou(), OneSou(),
            TwoSou(), TwoSou(), TwoSou(), TwoSou(),
            ThreeSou(), ThreeSou(), ThreeSou(), ThreeSou(),
            FourSou(), FourSou(), FourSou(), FourSou(),
            RedFiveSou(), FiveSou(), FiveSou(), FiveSou(),
            SixSou(), SixSou(), SixSou(), SixSou(),
            SevenSou(), SevenSou(), SevenSou(), SevenSou(),
            EightSou(), EightSou(), EightSou(), EightSou(),
            NineSou(), NineSou(), NineSou(), NineSou(),

            EastWind(), EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(), NorthWind(),

            GreenDragon(), GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(), WhiteDragon()
        };
        
        public static List<TileObject> StandardWallNoRedFives()
        {
            return _standardWallNoRedFives;
        }

        public static List<TileObject> StandardWallThreeRedFives()
        {
            return _standardWallThreeRedFives;
        }

        public static List<TileObject> StandardWallFourRedFives()
        {
            return _standardWallFourRedFives;
        }

        public static List<TileObject> ThreePlayerWallNoRedFives()
        {
            return _threePlayerWallNoRedFives;
        }

        public static List<TileObject> ThreePlayerWallWithRedFives()
        {
            return _threePlayerWallWithRedFives;
        }
    }
}