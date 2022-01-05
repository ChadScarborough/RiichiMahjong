using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Hands.CompleteHands
{
    public class StandardCompleteHand : ICompleteHand
    {
        private List<ICompleteHandComponent> _completeHand;
        private Enums.CompleteHandWaitType _waitType;

        public StandardCompleteHand //Pair wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3, 
            ICompleteHandGroup group4, IsolatedTile isolatedTile, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, group4, isolatedTile, drawTile);
            _waitType = Enums.PAIR_WAIT;
        }

        public StandardCompleteHand //Two-sided triplet wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3, 
            PairComponent pair1, PairComponent pair2, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, pair1, pair2, drawTile);
            _waitType = Enums.TWO_SIDED_TRIPLET_WAIT;
        }

        public StandardCompleteHand //Closed wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3, 
            IncompleteSequenceClosedWait incompleteSequence, PairComponent pair, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, incompleteSequence, pair, drawTile);
            _waitType = Enums.CLOSED_WAIT;
        }

        public StandardCompleteHand //Edge wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3,
            IncompleteSequenceEdgeWait incompleteSequence, PairComponent pair, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, incompleteSequence, pair, drawTile);
            _waitType = Enums.EDGE_WAIT;
        }

        public StandardCompleteHand //Open wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3,
            IncompleteSequenceOpenWait incompleteSequence, PairComponent pair, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, incompleteSequence, pair, drawTile);
            _waitType = Enums.OPEN_WAIT;
        }

        private void InitializeList()
        {
            _completeHand = new List<ICompleteHandComponent>();
        }

        private void FillList(
            ICompleteHandComponent component1, ICompleteHandComponent component2, ICompleteHandComponent component3, 
            ICompleteHandComponent component4, ICompleteHandComponent component5, ICompleteHandComponent component6
            )
        {
            _completeHand.Add(component1);
            _completeHand.Add(component2);
            _completeHand.Add(component3);
            _completeHand.Add(component4);
            _completeHand.Add(component5);
            _completeHand.Add(component6);
        }

        public List<ICompleteHandComponent> GetCompleteHand()
        {
            return _completeHand;
        }

        public Enums.CompleteHandWaitType GetWaitType()
        {
            return _waitType;
        }

        public Enums.CompleteHandType GetCompleteHandType()
        {
            return Enums.STANDARD;
        }
    }
}
