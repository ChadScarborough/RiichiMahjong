using System;
using System.Collections.Generic;
using RMU.Hands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Shanten
{
    public static class SevenPairsShantenCalculator
    {
        private static List<TileCollection> _newCollections;
        private static List<ICompleteHandComponent> _components;
        private static int _triplets, _pairs;

        public static int CalculateShanten(Hand hand, List<TileCollection> collections)
        {
            InitializeValues(collections);
            ExtractTripletsAndPairsAndIncrementCounters();
            int shanten = ShantenFormulas.CalculateSevenPairsShanten(_triplets, _pairs);
            if (shanten == 0)
            {
                foreach (TileCollection collection in _newCollections)
                {
                    List<ICompleteHandComponent> isolatedTiles = IsolatedTileExtractor.ExtractIsolatedTiles(collection);
                    foreach (ICompleteHandComponent component in isolatedTiles)
                    {
                        _components.Add(component);
                    }
                }
                hand.AddTenpaiHand(TenpaiHandFactory.CreateTenpaiHand(hand, _components));   
            }

            return shanten;
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
