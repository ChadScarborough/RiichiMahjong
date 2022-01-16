﻿using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;

namespace RMU.Shanten
{
    public static class StandardShantenCalculator
    {
        private static readonly int[] ShantenValues = new int[16];
        private static List<TileCollection> _newCollections;
        private static List<ICompleteHandComponent> _components;

        public static int CalculateShanten(List<TileCollection> collections)
        {
            ClearShantenValues();
            SetShantenValues(collections);
            return Functions.MinOfArray(ShantenValues);
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
            return CalculateStandardShanten(_components);
        }

        private static int TopchiiPonPairConsNoncons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach(TileCollection collection in _newCollections)
            {
                ExtractChiiFromTopToComponentsList(_components, collection);
                ExtractPonToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int PonTopchiiConsNonconsPair(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach(TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractChiiFromTopToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
        }

        private static int BottomchiiPonPairConsNoncons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach(TileCollection collection in _newCollections)
            {
                ExtractChiiFromBottomToComponentsList(_components, collection);
                ExtractPonToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int PonBottomchiiConsNonconsPair(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach(TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractChiiFromBottomToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
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
            return CalculateStandardShanten(_components);
        }

        private static void InitializeLists(List<TileCollection> collections, out List<TileCollection> newCollections)
        {
            newCollections = CloneCollections(collections);
            _components = new List<ICompleteHandComponent>();
        }

        private static int CalculateStandardShanten(List<ICompleteHandComponent> components)
        {
            int groups = 0, pairs = 0, taatsu = 0;
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
                case (Enums.GROUP):
                    groups++;
                    break;
                case (Enums.PAIR):
                    pairs++;
                    break;
                case (Enums.TAATSU):
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
            List<TileCollection> outputList = new List<TileCollection>();
            foreach (TileCollection collection in collections)
            {
                outputList.Add(collection.Clone());
            }
            return outputList;
        }
    }
}
