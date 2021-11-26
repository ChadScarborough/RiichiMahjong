using System;
using System.Collections.Generic;
using System.Text;
using RMU.Yaku.Yakuman;

namespace RMU.Yaku.YakuLists
{
    public static class YakumanList
    {
        private static List<AbstractYakuman> _yakumanList = new List<AbstractYakuman>
        {
            new AllHonors(),
            new AllTerminals(),
            new BigThreeDragons(),
            new FourBigWinds()
        };
    }
}
