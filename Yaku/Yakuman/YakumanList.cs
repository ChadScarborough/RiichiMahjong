using Godot;
using RMU.Hands.CompleteHands;
using System.Linq;

namespace RMU.Yaku.Yakuman
{
    internal sealed class YakumanList
    {
        private readonly ICompleteHand _completeHand;
        private List<YakumanBase> _yakumanList;

        public YakumanList(ICompleteHand completeHand)
        {
            _completeHand = completeHand;
            InitializeList();
        }

        private void InitializeList()
        {
            _yakumanList = new List<YakumanBase>
            {
                new BlessingsOfHeavenYakuman(_completeHand),
                new BlessingsOfEarthYakuman(_completeHand),
                new ThirteenOrphansYakuman(_completeHand),
                new ThirteenWaitThirteenOrphansYakuman(_completeHand),
                new FourConcealedTripletsYakuman(_completeHand),
                new FourConcealedTripletsSingleWaitYakuman(_completeHand),
                new BigThreeDragonsYakuman(_completeHand),
                new FourLittleWindsYakuman(_completeHand),
                new FourBigWindsYakuman(_completeHand),
                new AllHonorsYakuman(_completeHand),
                new AllTerminalsYakuman(_completeHand),
                new AllGreensYakuman(_completeHand),
                new NineGatesYakuman(_completeHand),
                new TrueNineGatesYakuman(_completeHand),
                new FourQuadsYakuman(_completeHand)
            };
        }

        public List<YakumanBase> CheckYakuman()
        {
            GD.Print("Checking Yakuman");
            return _yakumanList.Where(y => y.Check()).ToList();
        }
    }
}
