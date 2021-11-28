using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku.YakuLists
{
    public static class YakuList
    {
        private static List<AbstractYaku> _yakuList = new List<AbstractYaku>
        {
            new AllSimples(),
            new AllTerminalsAndHonors(),
            new FullFlush(),
            new GreenDragon(),
            new RedDragon(),
            new WhiteDragon()
        };

        public static List<AbstractYaku> GetYakuList()
        {
            return _yakuList;
        }
    }
}
