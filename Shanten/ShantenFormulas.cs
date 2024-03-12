using Godot;
using System;

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
        //int blocks = 0;
        //if (pairs >= 1) 
        //{ 
        //    blocks++;
        //    pairs--;
        //}
        //blocks += groups * 2;
        //int partial = pairs + taatsu;
        //if (partial > 4) partial = 4;
        //return 8 - (blocks + partial);
        int shanten = 8 - (taatsu + pairs) - 2 * groups;
        if (taatsu + groups == 5 && pairs == 0)
            shanten++;
        if (groups + pairs + taatsu >= 6)
        {
            while (groups + taatsu + pairs >= 6)
            {
                if (taatsu > 0)
                    taatsu--;
                else if (pairs > 0)
                    pairs--;
            }
            int normTaatsu = Math.Min(5 - groups, taatsu);
            shanten = 8 - 2 * groups - (normTaatsu + pairs);
        }
        return shanten;
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
