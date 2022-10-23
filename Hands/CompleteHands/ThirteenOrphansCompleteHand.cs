using RMU.Globals.Algorithms;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Players;
using RMU.Tiles;
using RMU.Yaku;
using System.Collections.Generic;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Hands.CompleteHands;

public sealed class ThirteenOrphansCompleteHand : ICompleteHand
{
    private readonly List<ICompleteHandComponent> _completeHand;
    private readonly CompleteHandWaitType _waitType;
    private readonly ITenpaiHand _tenpaiHand;
    private readonly List<ICompleteHandComponent> _constructedHand;
    private readonly Tile _drawTile;
    private readonly List<ICompleteHandComponent> _isolatedTiles;
    private readonly List<ICompleteHandComponent> _pairs;
    private readonly List<Tile> _tiles;
    private readonly Player _player;
    private List<YakuBase> _satisfiedYaku;

    public ThirteenOrphansCompleteHand(ITenpaiHand tenpaiHand, Tile tile, Player player)
    {
        _player = player;
        _completeHand = tenpaiHand.GetComponents();
        ICompleteHandComponent drawTile = CreateCompleteHandComponent(tile, DRAW_TILE);
        _completeHand.Add(drawTile);
        _tenpaiHand = tenpaiHand;
        _waitType = tenpaiHand.GetWaitType();
        _drawTile = tile;
        _isolatedTiles = new List<ICompleteHandComponent>();
        _pairs = new List<ICompleteHandComponent>();
        _constructedHand = new List<ICompleteHandComponent>();
        _tiles = new List<Tile>();
        _satisfiedYaku = new();

        if (_waitType is SINGLE_WAIT)
        {
            foreach (ICompleteHandComponent component in _completeHand)
            {
                if (component.GetComponentType() is DRAW_TILE)
                {
                    ICompleteHandComponent isolatedTile =
                        CreateCompleteHandComponent(component.GetLeadTile(), ISOLATED_TILE);
                    _constructedHand.Add(isolatedTile);
                    continue;
                }

                if (component.GetComponentType() is ISOLATED_TILE)
                {
                    _isolatedTiles.Add(component);
                }
                else if (component.GetComponentType() is PAIR_COMPONENT)
                {
                    _pairs.Add(component);
                }
                _constructedHand.Add(component);
            }
        }
        else
        {
            foreach (ICompleteHandComponent component in _completeHand)
            {
                if (AreTilesEquivalent(component.GetLeadTile(), _drawTile))
                {
                    List<Tile> tileList = new() { _drawTile, component.GetLeadTile() };
                    ICompleteHandComponent pair = CreateCompleteHandComponent(tileList, PAIR_COMPONENT);
                    _constructedHand.Add(pair);
                    _pairs.Add(pair);
                    continue;
                }
                _constructedHand.Add(component);
                _isolatedTiles.Add(component);
            }
        }

        foreach (ICompleteHandComponent component in _constructedHand)
        {
            foreach (Tile t in component.GetTiles())
            {
                _tiles.Add(t);
            }
        }

        _constructedHand = RadixSortForCompleteHandComponents.Sort(_constructedHand);
    }

    public List<ICompleteHandComponent> GetComponents()
    {
        return _completeHand;
    }

    public CompleteHandType GetCompleteHandType()
    {
        return THIRTEEN_ORPHANS;
    }

    public CompleteHandWaitType GetWaitType()
    {
        return _waitType;
    }

    public bool IsOpen()
    {
        return false;
    }

    public List<ICompleteHandComponent> GetConstructedHandComponents()
    {
        return _constructedHand;
    }

    public List<ICompleteHandComponent> GetTriplets()
    {
        return new List<ICompleteHandComponent>();
    }

    public List<ICompleteHandComponent> GetSequences()
    {
        return new List<ICompleteHandComponent>();
    }

    public List<ICompleteHandComponent> GetPairs()
    {
        return _pairs;
    }

    public List<ICompleteHandComponent> GetIsolatedTiles()
    {
        return _isolatedTiles;
    }

    public List<Tile> GetTiles()
    {
        return _tiles;
    }

    public void SetYaku(List<YakuBase> satisfiedYaku)
    {
        _satisfiedYaku.AddRange(satisfiedYaku);
    }

    public List<YakuBase> GetYaku()
    {
        return _satisfiedYaku;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public ITenpaiHand GetTenpaiHand()
    {
        return _tenpaiHand;
    }

    public void ClearYaku()
    {
        _satisfiedYaku.Clear();
    }
}
