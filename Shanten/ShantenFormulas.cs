namespace RMU.Shanten;

public static class ShantenFormulas
{
    public static int CalculateStandardShanten(int groups, int pairs, int taatsu)
    {
        int standardShanten = 8 - ((2 * groups) + pairs + taatsu);
        standardShanten = standardShanten <= 0 && pairs == 0 && taatsu >= 1 ? standardShanten + 1 : standardShanten;
        return standardShanten <= 1
            ? (groups, pairs, taatsu) switch
            {
                (4, 1, 0) => -1,
                (4, 0, >= 0) or (3, >= 1, >= 1) or (3, >= 0, >= 2) => 0,
                _ => 1
            }
            : standardShanten;
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
