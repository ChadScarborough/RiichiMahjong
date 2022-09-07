using RMU.Globals;

namespace RMU.Shanten
{
    public static class ShantenFormulas
    {
        public static int CalculateStandardShanten(int groups, int pairs, int taatsu)
        {
            int standardShanten = (8 - ((2 * groups) + (pairs + taatsu)));
            //Two groups, three pairs, one taatsu should not be considered tenpai
            if(standardShanten <= 0 && pairs == 0 && taatsu >= 1) 
            {
                return standardShanten + 1;
            }
            return standardShanten;
        }

        public static int CalculateSevenPairsShanten(int triplets, int pairs)
        {
            if (pairs == 5 && triplets == 1) return 1;
            return 6 - (pairs + triplets);
        }

        public static int CalculateThirteenOrphansShanten(int uniqueTerminals, bool isTerminalPair)
        {
            return 13 - (uniqueTerminals + Functions.BoolToInt(isTerminalPair));
        }
    }
}
