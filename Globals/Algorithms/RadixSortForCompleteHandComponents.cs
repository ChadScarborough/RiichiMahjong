using System;
using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Globals.Algorithms;

public static class RadixSortForCompleteHandComponents
{
    private const int UNIQUE_NUMBERS = 9;
    private const int UNIQUE_SUITS = 5;
    private const int UNIQUE_GENERAL_COMPONENT_TYPES = 4;
    private static List<DataStructures.Queue<ICompleteHandComponent>> _numberBuckets;
    private static List<DataStructures.Queue<ICompleteHandComponent>> _suitBuckets;
    private static List<DataStructures.Queue<ICompleteHandComponent>> _componentBuckets;
    private static List<ICompleteHandComponent> _components;

    public static List<ICompleteHandComponent> Sort(List<ICompleteHandComponent> components)
    {
        _components = components;
        InitializeBuckets();
        SortHand();
        return _components;
    }

    private static void SortHand()
    {
        SortComponentsByNumber();
        SortComponentsBySuit();
        SortComponentsByType();
    }

    private static void InitializeBuckets()
    {
        _numberBuckets = new List<DataStructures.Queue<ICompleteHandComponent>>();
        _suitBuckets = new List<DataStructures.Queue<ICompleteHandComponent>>();
        _componentBuckets = new List<DataStructures.Queue<ICompleteHandComponent>>();
        CreateBuckets(_numberBuckets, UNIQUE_NUMBERS);
        CreateBuckets(_suitBuckets, UNIQUE_SUITS);
        CreateBuckets(_componentBuckets, UNIQUE_GENERAL_COMPONENT_TYPES);
    }

    private static void SortComponentsByNumber()
    {
        FillNumberBuckets();
        _components.Clear();
        EmptyBuckets(_numberBuckets);
    }

    private static void SortComponentsBySuit()
    {
        FillSuitBuckets();
        _components.Clear();
        EmptyBuckets(_suitBuckets);
    }

    private static void SortComponentsByType()
    {
        FillComponentBuckets();
        _components.Clear();
        EmptyBuckets(_componentBuckets);
    }

    private static void FillNumberBuckets()
    {
        foreach (ICompleteHandComponent component in _components)
        {
            int index = component.GetLeadTile().GetValue() - 1;
            _numberBuckets[index].Enqueue(component);
        }
    }

    private static void FillSuitBuckets()
    {
        List<Suit> suitPriority = new List<Suit> {MAN, PIN, SOU, WIND, DRAGON}; 
        foreach (ICompleteHandComponent component in _components)
        {
            Suit suit = component.GetLeadTile().GetSuit();
            int index = suitPriority.IndexOf(suit);
            _suitBuckets[index].Enqueue(component);
        }
    }

    private static void FillComponentBuckets()
    {
        List<CompleteHandGeneralComponentType> componentPriority = new List<CompleteHandGeneralComponentType>
        {
            GROUP,
            PAIR,
            TAATSU,
            TILE
        };
        foreach (ICompleteHandComponent component in _components)
        {
            CompleteHandGeneralComponentType componentType = component.GetGeneralComponentType();
            int index = componentPriority.IndexOf(componentType);
            _componentBuckets[index].Enqueue(component);
        }
    }
    
    private static void CreateBuckets(List<DataStructures.Queue<ICompleteHandComponent>> buckets, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            DataStructures.Queue<ICompleteHandComponent> queue = new DataStructures.Queue<ICompleteHandComponent>();
            buckets.Add(queue);
        }
    }
    
    private static void EmptyQueues(DataStructures.Queue<ICompleteHandComponent> queue)
    {
        while (!queue.IsEmpty())
        {
            ICompleteHandComponent component = queue.Dequeue();
            _components.Add(component);
        }
    }
    
    private static void EmptyBuckets(List<DataStructures.Queue<ICompleteHandComponent>> buckets)
    {
        foreach (DataStructures.Queue<ICompleteHandComponent> queue in buckets)
        {
            EmptyQueues(queue);
        }
    }
}