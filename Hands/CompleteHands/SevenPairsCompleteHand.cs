using RMU.Globals.Algorithms;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Players;
using RMU.Tiles;
using RMU.Yaku;
using System;
using System.Collections.Generic;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Hands.CompleteHands;

public sealed class SevenPairsCompleteHand : ICompleteHand
{
    private readonly List<ICompleteHandComponent> _completeHand;
    private readonly List<ICompleteHandComponent> _constructedHand;
    private readonly ITenpaiHand _tenpaiHand;
    private readonly Tile _drawTile;
    private readonly List<Tile> _tiles;
    private List<YakuBase> _satisfiedYaku;
    private readonly Player _player;

    public SevenPairsCompleteHand(ITenpaiHand tenpaiHand, Tile tile, Player player)
    {
        _player = player;
        _tenpaiHand = tenpaiHand;
        _completeHand = tenpaiHand.GetComponents();
        ICompleteHandComponent drawTile = CreateCompleteHandComponent(tile, DRAW_TILE);
        _completeHand.Add(drawTile);
        _completeHand = RadixSortForCompleteHandComponents.Sort(_completeHand);
        _drawTile = tile;
        _tiles = new List<Tile>();
        _satisfiedYaku = new();

        _constructedHand = new List<ICompleteHandComponent>();
        ConstructHand();
        _constructedHand = RadixSortForCompleteHandComponents.Sort(_constructedHand);
        foreach (ICompleteHandComponent component in _constructedHand)
        {
            foreach (Tile t in component.GetTiles())
            {
                _tiles.Add(t);
            }
        }
    }

    public List<ICompleteHandComponent> GetComponents()
    {
        return _completeHand;
    }

    public CompleteHandWaitType GetWaitType()
    {
        return PAIR_WAIT;
    }

    public CompleteHandType GetCompleteHandType()
    {
        return SEVEN_PAIRS;
    }

    public bool IsOpen()
    {
        return false;
    }

    private void ConstructHand()
    {
        ICompleteHandComponent isolatedTile = null;
        foreach (ICompleteHandComponent component in _completeHand)
        {
            if (component.GetGeneralComponentType() is PAIR)
            {
                _constructedHand.Add(component);
                continue;
            }

            if (component.GetComponentType() is ISOLATED_TILE)
            {
                isolatedTile = component;
            }
        }

        List<Tile> tileList;
        try
        {
            tileList = new List<Tile> { _drawTile, isolatedTile.GetLeadTile() };
        }
        catch
        {
            throw new Exception("Invalid hand composition");
        }

        ICompleteHandComponent completedPair = CreateCompleteHandComponent(tileList, PAIR_COMPONENT);
        _constructedHand.Add(completedPair);
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
        return _constructedHand;
    }

    public List<ICompleteHandComponent> GetIsolatedTiles()
    {
        return new List<ICompleteHandComponent>();
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
