using RMU.Calls.CreateMeldBehaviours;
using RMU.Hands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Shanten.HandSplitter;
using System.Collections.Generic;

namespace RMU.Shanten;

public static class StandardShantenCalculator
{
    private static readonly int[] ShantenValues = new int[16];
    private static List<TileCollection> _newCollections;
    private static List<ICompleteHandComponent> _components;
    private static int _numberOfOpenMelds;
    private static Hand _hand;

    public static int CalculateShanten(Hand hand, List<TileCollection> collections, int numberOfOpenMelds)
    {
        _hand = hand;
        _numberOfOpenMelds = numberOfOpenMelds;
        ClearShantenValues();
        SetShantenValues(collections);
        return MinOfArray(ShantenValues);
    }

    private static void ClearShantenValues()
    {
        for (int i = 0; i < 8; i++)
        {
            ShantenValues[i] = 0;
        }
    }

    private static void SetShantenValues(List<TileCollection> collections)
    {
        ShantenValues[0] = PonTopchiiPairConsNoncons(collections);
        ShantenValues[1] = TopchiiPonPairConsNoncons(collections);
        ShantenValues[2] = PonTopchiiConsNonconsPair(collections);
        ShantenValues[3] = TopchiiPonConsNonconsPair(collections);
        ShantenValues[4] = PonTopchiiConsPairNoncons(collections);
        ShantenValues[5] = TopchiiPonConsPairNoncons(collections);
        ShantenValues[6] = PonPairTopchiiConsNoncons(collections);
        ShantenValues[7] = PonPairTopchiiNonconsCons(collections);
        ShantenValues[8] = PonBottomchiiPairConsNoncons(collections);
        ShantenValues[9] = BottomchiiPonPairConsNoncons(collections);
        ShantenValues[10] = PonBottomchiiConsNonconsPair(collections);
        ShantenValues[11] = BottomchiiPonConsNonconsPair(collections);
        ShantenValues[12] = PonBottomchiiConsPairNoncons(collections);
        ShantenValues[13] = BottomchiiPonConsPairNoncons(collections);
        ShantenValues[14] = PonPairBottomchiiConsNoncons(collections);
        ShantenValues[15] = PonPairBottomchiiNonconsCons(collections);
    }

    private static int PonTopchiiPairConsNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero()
    {
        int shanten = CalculateStandardShanten(_components);

        if (shanten == 0)
        {
            ExtractIsolatedTiles();
            foreach (OpenMeld openMeld in _hand.GetOpenMelds())
            {
                ICompleteHandComponent component =
                    CompleteHandComponentFactory.CreateCompleteHandComponent(openMeld);
                _components.Add(component);
            }

            _hand.AddTenpaiHand(TenpaiHandFactory.CreateTenpaiHand(_hand, _components));
        }

        return shanten;
    }

    private static void ExtractIsolatedTiles()
    {
        foreach (TileCollection collection in _newCollections)
        {
            List<ICompleteHandComponent> isolatedTiles = IsolatedTileExtractor.ExtractIsolatedTiles(collection);
            foreach (ICompleteHandComponent component in isolatedTiles)
            {
                _components.Add(component);
            }
        }
    }

    private static int TopchiiPonPairConsNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractPonToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonTopchiiConsNonconsPair(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int TopchiiPonConsNonconsPair(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractPonToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonTopchiiConsPairNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int TopchiiPonConsPairNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractPonToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonPairTopchiiConsNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonPairTopchiiNonconsCons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractChiiFromTopToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonBottomchiiPairConsNoncons(List<TileCollection> collections)
    {

        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int BottomchiiPonPairConsNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractPonToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonBottomchiiConsNonconsPair(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int BottomchiiPonConsNonconsPair(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractPonToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonBottomchiiConsPairNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int BottomchiiPonConsPairNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractPonToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonPairBottomchiiConsNoncons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static int PonPairBottomchiiNonconsCons(List<TileCollection> collections)
    {
        InitializeLists(collections, out _newCollections);
        foreach (TileCollection collection in _newCollections)
        {
            ExtractPonToComponentsList(_components, collection);
            ExtractPairToComponentsList(_components, collection);
            ExtractChiiFromBottomToComponentsList(_components, collection);
            ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            ExtractConsecutiveTaatsuToComponentsList(_components, collection);
        }
        return CalculateShantenValueAndCreateTenpaiHandIfShantenIsZero();
    }

    private static void InitializeLists(List<TileCollection> collections, out List<TileCollection> newCollections)
    {
        newCollections = CloneCollections(collections);
        _components = new List<ICompleteHandComponent>();
    }

    private static int CalculateStandardShanten(List<ICompleteHandComponent> components)
    {
        int groups = _numberOfOpenMelds, pairs = 0, taatsu = 0;
        foreach (ICompleteHandComponent component in components)
        {
            IncrementCounters(ref groups, ref pairs, ref taatsu, component);
        }
        return ShantenFormulas.CalculateStandardShanten(groups, pairs, taatsu);
    }

    private static void IncrementCounters(ref int groups, ref int pairs, ref int taatsu, ICompleteHandComponent component)
    {
        switch (component.GetGeneralComponentType())
        {
            case GROUP:
                groups++;
                break;
            case PAIR:
                pairs++;
                break;
            case TAATSU:
                taatsu++;
                break;
        }
    }

    private static void ExtractNonconsecutiveTaatsuToComponentsList(List<ICompleteHandComponent> components, TileCollection collection)
    {
        foreach (ICompleteHandComponent component in NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(collection))
        {
            components.Add(component);
        }
    }

    private static void ExtractConsecutiveTaatsuToComponentsList(List<ICompleteHandComponent> components, TileCollection collection)
    {
        foreach (ICompleteHandComponent component in ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(collection))
        {
            components.Add(component);
        }
    }

    private static void ExtractPairToComponentsList(List<ICompleteHandComponent> components, TileCollection collection)
    {
        foreach (ICompleteHandComponent component in PairExtractor.ExtractPair(collection))
        {
            components.Add(component);
        }
    }

    private static void ExtractChiiFromTopToComponentsList(List<ICompleteHandComponent> components, TileCollection collection)
    {
        foreach (ICompleteHandComponent component in ChiiFromTopExtractor.ExtractChii(collection))
        {
            components.Add(component);
        }
    }

    private static void ExtractChiiFromBottomToComponentsList(List<ICompleteHandComponent> components,
        TileCollection collection)
    {
        foreach (ICompleteHandComponent component in ChiiFromBottomExtractor.ExtractChii(collection))
        {
            components.Add(component);
        }
    }

    private static void ExtractPonToComponentsList(List<ICompleteHandComponent> components, TileCollection collection)
    {
        foreach (ICompleteHandComponent component in PonExtractor.ExtractPon(collection))
        {
            components.Add(component);
        }
    }

    private static List<TileCollection> CloneCollections(List<TileCollection> collections)
    {
        List<TileCollection> outputList = new();
        foreach (TileCollection collection in collections)
        {
            outputList.Add(collection.Clone());
        }
        return outputList;
    }
}
