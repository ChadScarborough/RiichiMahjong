using RMU.Calls.CreateMeldBehaviours;
using RMU.Tiles;

namespace RMU.Hands.RiichiCheckHands
{
    internal class RiichiCheckHand
    {
        private readonly List<Tile> _tiles;
        private readonly List<OpenMeld> _openMelds;

        public RiichiCheckHand(List<Tile> tiles, List<OpenMeld> openMelds)
        {
            this._tiles = tiles;
            this._openMelds = openMelds;
        }

        public List<Tile> GetTiles()
        {
            return _tiles;
        }

        public List<OpenMeld> GetOpenMelds()
        {
            return _openMelds;
        }
    }
}
