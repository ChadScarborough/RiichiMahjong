namespace RMU.Shanten;

public static class ShantenFormulas
{
    public static int CalculateStandardShantenNoDrawTile(int groups, int pairs, int taatsu)
    {
        int standardShanten = 8 - ((2 * groups) + pairs + taatsu);
        int totalComponents = groups + pairs + taatsu;
        if (totalComponents >= 6)
            standardShanten += totalComponents - 5;

        return standardShanten <= 1
            ? (groups, pairs, taatsu) switch
            {
                (4, 1, 0) => -1,
                (4, 0, >= 0) or (3, >= 1, >= 1) or (3, >= 2, >= 0) => 0,
                _ => 1
            }
            : standardShanten;
    }

    public static int CalculateStandardShantenWithDrawTile(int groups, int pairs, int taatsu)
    {
        int blocks = 0;
        if (pairs >= 1) blocks++;
        blocks += groups * 2;
        int partial = pairs + taatsu;
        if (partial > 4) partial = 4;
        return blocks + partial;
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
