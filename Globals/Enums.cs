namespace RMU.Globals
{
    public static class Enums
    {
        public enum MeldType { LowChii, MidChii, HighChii, Pon, OpenKan1, OpenKan2, ClosedKan }
        public enum Suit { Man, Pin, Sou, Wind, Dragon }
        public enum Wind { East, South, West, North }
        public enum CompleteHandComponentType
        {
            ClosedChii, ClosedPon, ClosedKan,
            OpenChii, OpenPon, OpenKan,
            IncompleteSequenceClosedWait, IncompleteSequenceOpenWait, IncompleteSequenceEdgeWait,
            Pair, IsolatedTile, DrawTile
        }
        public enum CompleteHandWaitType { PairWait, TwoSidedTripletWait, ClosedWait, EdgeWait, OpenWait, ThirteenWait }
        public enum CompleteHandType { Standard, SevenPairs, ThirteenOrphans }
    }
}
