using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedChii : AbstractCompleteHandComponent, ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public ClosedChii(List<TileObject> closedChii)
        {
            _tiles = new List<TileObject>();
            _getGeneralComponentBehaviour = new CompleteHandGeneralComponentStrategyBehaviours.GetGeneralGroupBehaviour();
            foreach(TileObject tile in closedChii)
            {
                _tiles.Add(tile);
            }
        }

        public override Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CLOSED_CHII;
        }

        public override TileObject GetLeadTile()
        {
            return _tiles[0];
        }

        public override List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
