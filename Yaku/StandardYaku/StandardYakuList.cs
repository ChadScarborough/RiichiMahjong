using RMU.Hands.CompleteHands;
using System.Collections.Generic;

namespace RMU.Yaku.StandardYaku
{
    internal class StandardYakuList
    {
        private ICompleteHand _completeHand;
        private List<YakuBase> _yakuList;

        public StandardYakuList(ICompleteHand completeHand)
        {
            _completeHand = completeHand;
            InitializeList();
        }

        private void InitializeList()
        {
            _yakuList = new List<YakuBase>()
            {
                new AllSimplesYaku(_completeHand),
                new AllTerminalsAndHonorsYaku(_completeHand),
                new AllTripletsYaku(_completeHand),
                new FullyConcealedHandYaku(_completeHand),
                new FullFlushYaku(_completeHand),
                new FullyOutsideHandYaku(_completeHand),
                new GreenDragonYaku(_completeHand),
                new HalfFlushYaku(_completeHand),
                new HalfOutsideHandYaku(_completeHand),
                new LittleThreeDragonsYaku(_completeHand),
                new MixedTripleSequenceYaku(_completeHand),
                new PureDoubleSequenceYaku(_completeHand),
                new PureStraightYaku(_completeHand),
                new RedDragonYaku(_completeHand),
                new SevenPairsYaku(_completeHand),
                new ThreeQuadsYaku(_completeHand),
                new TripleTripletsYaku(_completeHand),
                new TwicePureDoubleSequenceYaku(_completeHand),
                new WhiteDragonYaku(_completeHand)
            };
        }

        public List<YakuBase> CheckYaku()
        {
            List<YakuBase> achievedYaku = new List<YakuBase>();
            foreach(YakuBase yaku in _yakuList)
            {
                if (yaku.Check())
                {
                    achievedYaku.Add(yaku);
                }
            }
            return achievedYaku;
        }
    }
}
