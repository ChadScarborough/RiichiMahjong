using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hand.Calls
{
    public class OpenMeld
    {
        private Enums.MeldType _meldType;
        private readonly List<TileObject> _tiles;
        private ICreateMeldBehaviour _createMeldBehaviour;

        public OpenMeld(Enums.MeldType meldType, TileObject calledTile)
        {
            _meldType = meldType;
            SetMeldType(meldType);
            _tiles = _createMeldBehaviour.CreateMeld(calledTile);
        }

        public void AddTile(TileObject tile)
        {
            _tiles.Add(tile);
        }

        public void SetMeldType(Enums.MeldType meldType)
        {
            switch (meldType)
            {
                case Enums.LOW_CHII:
                    _createMeldBehaviour = new CreateLowChiiBehaviour();
                    break;
                case Enums.MID_CHII:
                    _createMeldBehaviour = new CreateMidChiiBehaviour();
                    break;
                case Enums.HIGH_CHII:
                    _createMeldBehaviour = new CreateHighChiiBehaviour();
                    break;
                case Enums.PON:
                    _createMeldBehaviour = new CreatePonBehaviour();
                    break;
                case Enums.OPEN_KAN_1:
                case Enums.CLOSED_KAN_MELD:
                    _createMeldBehaviour = new CreateKanBehaviour();
                    break;
                case Enums.OPEN_KAN_2:
                    _meldType = Enums.MeldType.OpenKan2;
                    break;
                case Enums.KITA:
                    _createMeldBehaviour = new CreateKitaBehaviour();
                    break;
            }
        }

        public Enums.MeldType GetMeldType()
        {
            return this._meldType;
        }

        public List<TileObject> GetTiles()
        {
            return this._tiles;
        }
    }
}
