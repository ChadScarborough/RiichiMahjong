using RMU.Hands.CompleteHands;
using System.Linq;

namespace RMU.Yaku.StandardYaku;

internal sealed class StandardYakuList
{
    private readonly ICompleteHand _completeHand;
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
            // 1 han
            new FullyConcealedHandYaku(_completeHand),
            new PinfuYaku(_completeHand),
            new PureDoubleSequenceYaku(_completeHand),
            new AllSimplesYaku(_completeHand),
            new GreenDragonYaku(_completeHand),
            new RedDragonYaku(_completeHand),
            new WhiteDragonYaku(_completeHand),
            new SeatWindYaku(_completeHand),
            new RoundWindYaku(_completeHand),
            // 2 han
            new HalfOutsideHandYaku(_completeHand),
            new MixedTripleSequenceYaku(_completeHand),
            new PureStraightYaku(_completeHand),
            new AllTripletsYaku(_completeHand),
            new ThreeConcealedTripletsYaku(_completeHand),
            new TripleTripletsYaku(_completeHand),
            new ThreeQuadsYaku(_completeHand),
            new SevenPairsYaku(_completeHand),
            new AllTerminalsAndHonorsYaku(_completeHand),
            new LittleThreeDragonsYaku(_completeHand),
            // 3 han
            new HalfFlushYaku(_completeHand),
            new FullyOutsideHandYaku(_completeHand),
            new TwicePureDoubleSequenceYaku(_completeHand),
            // 6 han
            new FullFlushYaku(_completeHand)
        };
    }

    public List<YakuBase> CheckYaku()
    {
        return _yakuList.Where(yaku => yaku.Check()).ToList();
    }
}
