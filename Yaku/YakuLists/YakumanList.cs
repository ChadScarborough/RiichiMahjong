using System.Collections.Generic;
using RMU.Yaku.Yakuman;

namespace RMU.Yaku.YakuLists
{
    public static class YakumanList
    {
        public static readonly AbstractYakuman ALL_GREENS = new AllGreens();
        public static readonly AbstractYakuman ALL_HONORS = new AllHonors();
        public static readonly AbstractYakuman ALL_TERMINALS = new AllTerminals();
        public static readonly AbstractYakuman BIG_THREE_DRAGONS = new BigThreeDragons();
        public static readonly AbstractYakuman FOUR_BIG_WINDS = new FourBigWinds();
        public static readonly AbstractYakuman THIRTEEN_ORPHANS = new ThirteenOrphans();
        public static readonly AbstractYakuman THIRTEEN_WAIT_THIRTEEN_ORPHANS = new ThirteenWaitThirteenOrphans();

        private static List<AbstractYakuman> _yakumanList = new List<AbstractYakuman>
        {
            ALL_GREENS,
            ALL_HONORS,
            ALL_TERMINALS,
            BIG_THREE_DRAGONS,
            FOUR_BIG_WINDS,
            THIRTEEN_ORPHANS,
            THIRTEEN_WAIT_THIRTEEN_ORPHANS
        };

        public static List<AbstractYakuman> GetYakumanList()
        {
            return _yakumanList;
        }
    }
}
