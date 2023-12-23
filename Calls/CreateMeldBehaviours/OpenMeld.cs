using RMU.Tiles;

namespace RMU.Calls.CreateMeldBehaviours;

public sealed class OpenMeld
{
    private MeldType _meldType;
    private readonly List<Tile> _tiles;
    private ICreateMeldBehaviour _createMeldBehaviour;
    private Tile _calledTile;

    public OpenMeld(MeldType meldType, Tile calledTile)
    {
        _meldType = meldType;
        SetMeldType(meldType);
        _calledTile = calledTile;
        _tiles = _createMeldBehaviour.CreateMeld(calledTile);
    }

    public void AddTile(Tile tile)
    {
        _tiles.Add(tile);
    }

    public void SetMeldType(MeldType meldType)
    {
        switch (meldType)
        {
            case LOW_CHII:
                _createMeldBehaviour = new CreateLowChiiBehaviour();
                break;
            case MID_CHII:
                _createMeldBehaviour = new CreateMidChiiBehaviour();
                break;
            case HIGH_CHII:
                _createMeldBehaviour = new CreateHighChiiBehaviour();
                break;
            case PON:
                _createMeldBehaviour = new CreatePonBehaviour();
                break;
            case OPEN_KAN_1:
            case CLOSED_KAN_MELD:
                _createMeldBehaviour = new CreateKanBehaviour();
                break;
            case OPEN_KAN_2:
                _meldType = OPEN_KAN_2;
                break;
            case KITA:
                _createMeldBehaviour = new CreateKitaBehaviour();
                break;
        }
    }

    public MeldType GetMeldType()
    {
        return _meldType;
    }

    public List<Tile> GetTiles()
    {
        return _tiles;
    }

    public Tile GetCalledTile()
    {
        return _calledTile;
    }
}
