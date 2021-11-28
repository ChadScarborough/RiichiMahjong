using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Shanten
{
    public static class ShantenFormula
    {
        public static int CalculateShanten(int _groups, int _pairs, int _taatsu, int _uniqueTerminals)
        {
            int _standardShanten = StandardShanten(_groups, _pairs, _taatsu);
            int _sevenPairsShanten = SevenPairsShanten(_pairs);
            int _thirteenOrphansShanten = ThirteenOrphansShanten(_uniqueTerminals);
            return Globals.Math.MinOfThree(_standardShanten, _sevenPairsShanten, _thirteenOrphansShanten);   
        }

        private static int StandardShanten(int _groups, int _pairs, int _taatsu)
        {
            return (8 - (2 * _groups) - _pairs - _taatsu);
        }

        private static int SevenPairsShanten(int _pairs)
        {
            return 6 - _pairs;
        }

        private static int ThirteenOrphansShanten(int _uniqueTerminals)
        {
            return 13 - _uniqueTerminals;
        }
    }
}
