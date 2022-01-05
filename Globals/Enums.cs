namespace RMU.Globals
{
    public static class Enums
    {
        public enum MeldType { LowChii, MidChii, HighChii, Pon, OpenKan1, OpenKan2, ClosedKan, Kita }

        public const MeldType LOW_CHII = MeldType.LowChii;
        public const MeldType MID_CHII = MeldType.MidChii;
        public const MeldType HIGH_CHII = MeldType.HighChii;
        public const MeldType PON = MeldType.Pon;
        public const MeldType OPEN_KAN_1 = MeldType.OpenKan1;
        public const MeldType OPEN_KAN_2 = MeldType.OpenKan2;
        public const MeldType CLOSED_KAN_MELD = MeldType.ClosedKan;
        public const MeldType KITA = MeldType.Kita;

        public enum Suit { Man, Pin, Sou, Wind, Dragon }

        public const Suit MAN = Suit.Man;
        public const Suit PIN = Suit.Pin;
        public const Suit SOU = Suit.Sou;
        public const Suit WIND = Suit.Wind;
        public const Suit DRAGON = Suit.Dragon;

        public enum Wind { East, South, West, North }

        public const Wind EAST = Wind.East;
        public const Wind SOUTH = Wind.South;
        public const Wind WEST = Wind.West;
        public const Wind NORTH = Wind.North;

        public enum Dragon { Green, Red, White }

        public const Dragon GREEN = Dragon.Green;
        public const Dragon RED = Dragon.Red;
        public const Dragon WHITE = Dragon.White;

        public enum CompleteHandComponentType
        {
            ClosedChii, ClosedPon, ClosedKan,
            OpenChii, OpenPon, OpenKan,
            IncompleteSequenceClosedWait, IncompleteSequenceOpenWait, IncompleteSequenceEdgeWait,
            Pair, IsolatedTile, DrawTile
        }

        public const CompleteHandComponentType CLOSED_CHII = CompleteHandComponentType.ClosedChii;
        public const CompleteHandComponentType CLOSED_PON = CompleteHandComponentType.ClosedPon;
        public const CompleteHandComponentType CLOSED_KAN_COMPONENT = CompleteHandComponentType.ClosedKan;
        public const CompleteHandComponentType OPEN_CHII = CompleteHandComponentType.OpenChii;
        public const CompleteHandComponentType OPEN_PON = CompleteHandComponentType.OpenPon;
        public const CompleteHandComponentType OPEN_KAN = CompleteHandComponentType.OpenKan;
        public const CompleteHandComponentType INCOMPLETE_SEQUENCE_CLOSED_WAIT = CompleteHandComponentType.IncompleteSequenceClosedWait;
        public const CompleteHandComponentType INCOMPLETE_SEQUENCE_OPEN_WAIT = CompleteHandComponentType.IncompleteSequenceOpenWait;
        public const CompleteHandComponentType INCOMPLETE_SEQUENCE_EDGE_WAIT = CompleteHandComponentType.IncompleteSequenceEdgeWait;
        public const CompleteHandComponentType PAIR_COMPONENT = CompleteHandComponentType.Pair;
        public const CompleteHandComponentType ISOLATED_TILE = CompleteHandComponentType.IsolatedTile;
        public const CompleteHandComponentType DRAW_TILE = CompleteHandComponentType.DrawTile;

        public enum CompleteHandGeneralComponentType { Group, Pair, Taatsu, Tile }

        public const CompleteHandGeneralComponentType GROUP = CompleteHandGeneralComponentType.Group;
        public const CompleteHandGeneralComponentType PAIR = CompleteHandGeneralComponentType.Pair;
        public const CompleteHandGeneralComponentType TAATSU = CompleteHandGeneralComponentType.Taatsu;
        public const CompleteHandGeneralComponentType TILE = CompleteHandGeneralComponentType.Tile;
        public enum CompleteHandWaitType { PairWait, TwoSidedTripletWait, ClosedWait, EdgeWait, OpenWait, ThirteenWait }

        public const CompleteHandWaitType PAIR_WAIT = CompleteHandWaitType.PairWait;
        public const CompleteHandWaitType TWO_SIDED_TRIPLET_WAIT = CompleteHandWaitType.TwoSidedTripletWait;
        public const CompleteHandWaitType CLOSED_WAIT = CompleteHandWaitType.ClosedWait;
        public const CompleteHandWaitType EDGE_WAIT = CompleteHandWaitType.EdgeWait;
        public const CompleteHandWaitType OPEN_WAIT = CompleteHandWaitType.OpenWait;
        public const CompleteHandWaitType THIRTEEN_WAIT = CompleteHandWaitType.ThirteenWait;

        public enum CompleteHandType { Standard, SevenPairs, ThirteenOrphans }

        public const CompleteHandType STANDARD = CompleteHandType.Standard;
        public const CompleteHandType SEVEN_PAIRS = CompleteHandType.SevenPairs;
        public const CompleteHandType THIRTEEN_ORPHANS = CompleteHandType.ThirteenOrphans;
        
        public enum PotentialCallType {Pon, LowChii, MidChii, HighChii, ClosedKan, OpenKan1, Ron}

        public const PotentialCallType PON_POTENTIAL_CALL_TYPE = PotentialCallType.Pon;
        public const PotentialCallType LOW_CHII_POTENTIAL_CALL_TYPE = PotentialCallType.LowChii;
        public const PotentialCallType MID_CHII_POTENTIAL_CALL_TYPE = PotentialCallType.MidChii;
        public const PotentialCallType HIGH_CHII_POTENTIAL_CALL_TYPE = PotentialCallType.HighChii;
        public const PotentialCallType CLOSED_KAN_POTENTIAL_CALL_TYPE = PotentialCallType.ClosedKan;
        public const PotentialCallType OPEN_KAN_1_POTENTIAL_CALL_TYPE = PotentialCallType.OpenKan1;
        public const PotentialCallType RON_POTENTIAL_CALL_TYPE = PotentialCallType.Ron;
    }
}
