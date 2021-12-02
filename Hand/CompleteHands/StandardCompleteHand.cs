using RMU.Hand.CompleteHands.CompleteHandComponents;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Hand.CompleteHands
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
            _waitType = Enums.CompleteHandWaitType.PairWait;
        }

        public StandardCompleteHand //Two-sided triplet wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3, 
            Pair pair1, Pair pair2, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, pair1, pair2, drawTile);
            _waitType = Enums.CompleteHandWaitType.TwoSidedTripletWait;
        }

        public StandardCompleteHand //Closed wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3, 
            IncompleteSequenceClosedWait incompleteSequence, Pair pair, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, incompleteSequence, pair, drawTile);
            _waitType = Enums.CompleteHandWaitType.ClosedWait;
        }

        public StandardCompleteHand //Edge wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3,
            IncompleteSequenceEdgeWait incompleteSequence, Pair pair, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, incompleteSequence, pair, drawTile);
            _waitType = Enums.CompleteHandWaitType.EdgeWait;
        }

        public StandardCompleteHand //Open wait
            (
            ICompleteHandGroup group1, ICompleteHandGroup group2, ICompleteHandGroup group3,
            IncompleteSequenceOpenWait incompleteSequence, Pair pair, DrawTile drawTile
            )
        {
            InitializeList();
            FillList(group1, group2, group3, incompleteSequence, pair, drawTile);
            _waitType = Enums.CompleteHandWaitType.OpenWait;
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
            return Enums.CompleteHandType.Standard;
        }
    }
}
