using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hand
{
    public class OpenMeld
    {
        private Enums.MeldType _meldType;
        private List<TileObject> _tiles;
        private ICreateMeldBehaviour _createMeldBehaviour;

        //Use strategy pattern to alter behaviour based on the meld type

        public OpenMeld(Enums.MeldType _meldType, TileObject _calledTile)
        {
            this._meldType = _meldType;
            SetMeldType(_meldType);
            _tiles = _createMeldBehaviour.CreateMeld(_calledTile);
        }

        public void AddTile(TileObject tile)
        {
            _tiles.Add(tile);
        }

        public void SetMeldType(Enums.MeldType _meldType)
        {
            switch (_meldType)
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
                    this._meldType = Enums.MeldType.OpenKan2;
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
