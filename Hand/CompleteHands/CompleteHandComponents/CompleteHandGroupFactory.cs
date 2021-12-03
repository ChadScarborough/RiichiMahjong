using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public static class CompleteHandGroupFactory
    {
        public static ICompleteHandGroup CreateCompleteHandGroup(List<TileObject> tiles, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.CLOSED_PON:
                    return new ClosedPon(tiles);
                case Enums.CLOSED_CHII:
                    return new ClosedChii(tiles);
                default:
                    return null;
            }
        }

        public static ICompleteHandGroup CreateCompleteHandGroup(OpenMeld meld)
        {
            switch (meld.GetMeldType())
            {
                case Enums.LOW_CHII:
                case Enums.MID_CHII:
                case Enums.HIGH_CHII:
                    return new OpenChii(meld);
                case Enums.PON:
                    return new OpenPon(meld);
                case Enums.OPEN_KAN_1:
                case Enums.OPEN_KAN_2:
                    return new OpenKan(meld);
                case Enums.CLOSED_KAN_MELD:
                    return new ClosedKan(meld);
                default:
                    return null;
            }
        }
    }
}
