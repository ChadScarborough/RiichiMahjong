using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;

namespace RMU.Shanten
{
    public static class StandardShantenCalculator
    {
        private static readonly int[] ShantenValues = new int[8];
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
            ShantenValues[0] = PonChiiPairConsNoncons(collections);
            ShantenValues[1] = ChiiPonPairConsNoncons(collections);
            ShantenValues[2] = PonChiiConsNonconsPair(collections);
            ShantenValues[3] = ChiiPonConsNonconsPair(collections);
            ShantenValues[4] = PonChiiConsPairNoncons(collections);
            ShantenValues[5] = ChiiPonConsPairNoncons(collections);
            ShantenValues[6] = PonPairChiiConsNoncons(collections);
            ShantenValues[7] = PonPairChiiNonconsCons(collections);
        }

        private static int PonChiiPairConsNoncons(List<TileCollection> collections)
        {

            InitializeLists(collections, out _newCollections);
            foreach (TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractChiiToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int ChiiPonPairConsNoncons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach(TileCollection collection in _newCollections)
            {
                ExtractChiiToComponentsList(_components, collection);
                ExtractPonToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int PonChiiConsNonconsPair(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach(TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractChiiToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int ChiiPonConsNonconsPair(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach (TileCollection collection in _newCollections)
            {
                ExtractChiiToComponentsList(_components, collection);
                ExtractPonToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int PonChiiConsPairNoncons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach (TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractChiiToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int ChiiPonConsPairNoncons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach (TileCollection collection in _newCollections)
            {
                ExtractChiiToComponentsList(_components, collection);
                ExtractPonToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int PonPairChiiConsNoncons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach (TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractChiiToComponentsList(_components, collection);
                ExtractConsecutiveTaatsuToComponentsList(_components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(_components, collection);
            }
            return CalculateStandardShanten(_components);
        }

        private static int PonPairChiiNonconsCons(List<TileCollection> collections)
        {
            InitializeLists(collections, out _newCollections);
            foreach (TileCollection collection in _newCollections)
            {
                ExtractPonToComponentsList(_components, collection);
                ExtractPairToComponentsList(_components, collection);
                ExtractChiiToComponentsList(_components, collection);
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

        private static void ExtractChiiToComponentsList(List<ICompleteHandComponent> components, TileCollection collection)
        {
            foreach (ICompleteHandComponent component in ChiiExtractor.ExtractChii(collection))
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
