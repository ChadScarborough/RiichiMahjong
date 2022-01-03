using System.Collections.Generic;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;
using static RMU.Globals.Enums;

namespace RMU.Shanten
{
    public static class SevenPairsShantenCalculator
    {
        private static List<TileCollection> _newCollections;
        private static List<ICompleteHandComponent> _components;
        private static int _triplets, _pairs;

        public static int CalculateShanten(List<TileCollection> collections)
        {
            InitializeValues(collections);
            ExtractTripletsAndPairsAndIncrementCounters();
            return ShantenFormulas.CalculateSevenPairsShanten(_triplets, _pairs);
        }

        private static void ExtractTripletsAndPairsAndIncrementCounters()
        {
            ExtractAllTripletsAndPairs();
            IncrementCounters();
        }

        private static void InitializeValues(List<TileCollection> collections)
        {
            InitializeLists();
            CloneCollections(collections);
        }

        private static void IncrementCounters()
        {
            ResetCounters();
            foreach (ICompleteHandComponent component in _components)
            {
                IncrementAppropriateCounter(component);
            }
        }

        private static void ResetCounters()
        {
            _triplets = 0; 
            _pairs = 0;
        }

        private static void IncrementAppropriateCounter(ICompleteHandComponent component)
        {
            switch (component.GetComponentType())
            {
                case CLOSED_PON:
                    _triplets++;
                    break;
                case PAIR_COMPONENT:
                    _pairs++;
                    break;
            }
        }

        private static void InitializeLists()
        {
            _components = new List<ICompleteHandComponent>();
            _newCollections = new List<TileCollection>();
        }

        private static void CloneCollections(List<TileCollection> collections)
        {
            foreach (TileCollection collection in collections)
            {
                _newCollections.Add(collection.Clone());
            }
        }

        private static void ExtractAllTripletsAndPairs()
        {
            foreach (TileCollection coll in _newCollections)
            {
                ExtractTriplets(coll);
                ExtractPairs(coll);
            }
        }

        private static void ExtractPairs(TileCollection coll)
        {
            foreach (ICompleteHandComponent component in PairExtractor.ExtractPair(coll))
            {
                _components.Add(component);
            }
        }

        private static void ExtractTriplets(TileCollection coll)
        {
            foreach (ICompleteHandComponent component in PonExtractor.ExtractPon(coll))
            {
                _components.Add(component);
            }
        }
    }
}
