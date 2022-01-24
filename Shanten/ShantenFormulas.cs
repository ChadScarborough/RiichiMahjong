using RMU.Globals;

namespace RMU.Shanten
{
    public static class ShantenFormulas
    {
        public static int CalculateStandardShanten(int groups, int pairs, int taatsu)
        {
            int standardShanten = (8 - ((2 * groups) + (pairs + taatsu)));
            if(standardShanten == -1 && pairs == 0) //Prevents the treating of a hand with four melds and an incomplete sequence as complete
            {
                return 0;
            }
            return standardShanten;
        }

        public static int CalculateSevenPairsShanten(int triplets, int pairs)
        {
            return 6 - (pairs + triplets);
        }

        public static int CalculateThirteenOrphansShanten(int uniqueTerminals, bool isTerminalPair)
        {
            return 13 - (uniqueTerminals + Functions.BoolToInt(isTerminalPair));
        }
    }
}
