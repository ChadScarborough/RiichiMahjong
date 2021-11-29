using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Globals
{
    public class Enums
    {
        public enum MeldType { LowChii, MidChii, HighChii, Pon, OpenKan1, OpenKan2, ClosedKan }
        public enum Suit { Man, Pin, Sou, Wind, Dragon }
        public enum Wind { East, South, West, North }
        public enum Dragon { Green, Red, White }
        public enum CompleteHandComponentType
        {
            ClosedChii, ClosedPon, ClosedKan,
            OpenChii, OpenPon, OpenKan,
            IncompleteSequenceClosedWait, IncompleteSequenceOpenWait, IncompleteSequenceEdgeWait,
            Pair, IsolatedTerminal, DrawTile
        }
    }
}
