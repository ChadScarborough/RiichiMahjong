namespace RMU.Shanten;

public static class ShantenFormulas
{
    public static int CalculateStandardShanten(int groups, int pairs, int taatsu)
    {
        int standardShanten = 8 - ((2 * groups) + pairs + taatsu);
        //Two groups, three pairs, one taatsu should not be considered tenpai
        return standardShanten <= 0 && pairs == 0 && taatsu >= 1 ? standardShanten + 1 : standardShanten;
    }

    public static int CalculateSevenPairsShanten(int triplets, int pairs)
    {
        return pairs == 5 && triplets == 1 ? 1 : 6 - (pairs + triplets);
    }

    public static int CalculateThirteenOrphansShanten(int uniqueTerminals, bool isTerminalPair)
    {
        return 13 - (uniqueTerminals + BoolToInt(isTerminalPair));
    }
}
