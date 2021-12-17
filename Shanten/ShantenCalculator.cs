using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Globals;

namespace RMU.Shanten
{
    public static class ShantenCalculator
    {
        private static int[] _shantenValues = new int[8];
        private static List<AbstractTileCollection> newCollections;
        private static List<ICompleteHandComponent> components;

        public static int CalculateShanten(List<AbstractTileCollection> collections)
        {
            ClearShantenValues();
            SetShantenValues(collections);
            return Functions.MinOfEight
                (
                _shantenValues[0], _shantenValues[1], _shantenValues[2], _shantenValues[3],
                _shantenValues[4], _shantenValues[5], _shantenValues[6], _shantenValues[7]
                );
        }

        private static void ClearShantenValues()
        {
            for (int i = 0; i < 8; i++)
            {
                _shantenValues[i] = 0;
            }
        }

        private static void SetShantenValues(List<AbstractTileCollection> collections)
        {
            _shantenValues[0] = PonChiiPairConsNoncons(collections);
            _shantenValues[1] = ChiiPonPairConsNoncons(collections);
            _shantenValues[2] = PonChiiConsNonconsPair(collections);
            _shantenValues[3] = ChiiPonConsNonconsPair(collections);
            _shantenValues[4] = PonChiiConsPairNoncons(collections);
            _shantenValues[5] = ChiiPonConsPairNoncons(collections);
            _shantenValues[6] = PonPairChiiConsNoncons(collections);
            _shantenValues[7] = PonPairChiiNonconsCons(collections);
        }

        private static int PonChiiPairConsNoncons(List<AbstractTileCollection> collections)
        {

            InitializeLists(collections, out newCollections, out components);
            foreach (AbstractTileCollection collection in newCollections)
            {
                ExtractPonToComponentsList(components, collection);
                ExtractChiiToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int ChiiPonPairConsNoncons(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach(AbstractTileCollection collection in newCollections)
            {
                ExtractChiiToComponentsList(components, collection);
                ExtractPonToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int PonChiiConsNonconsPair(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach(AbstractTileCollection collection in newCollections)
            {
                ExtractPonToComponentsList(components, collection);
                ExtractChiiToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int ChiiPonConsNonconsPair(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach (AbstractTileCollection collection in newCollections)
            {
                ExtractChiiToComponentsList(components, collection);
                ExtractPonToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int PonChiiConsPairNoncons(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach (AbstractTileCollection collection in newCollections)
            {
                ExtractPonToComponentsList(components, collection);
                ExtractChiiToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int ChiiPonConsPairNoncons(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach (AbstractTileCollection collection in newCollections)
            {
                ExtractChiiToComponentsList(components, collection);
                ExtractPonToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int PonPairChiiConsNoncons(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach (AbstractTileCollection collection in newCollections)
            {
                ExtractPonToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
                ExtractChiiToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static int PonPairChiiNonconsCons(List<AbstractTileCollection> collections)
        {
            InitializeLists(collections, out newCollections, out components);
            foreach (AbstractTileCollection collection in newCollections)
            {
                ExtractPonToComponentsList(components, collection);
                ExtractPairToComponentsList(components, collection);
                ExtractChiiToComponentsList(components, collection);
                ExtractNonconsecutiveTaatsuToComponentsList(components, collection);
                ExtractConsecutiveTaatsuToComponentsList(components, collection);
            }
            return CalculateStandardShanten(components);
        }

        private static void InitializeLists(List<AbstractTileCollection> collections, out List<AbstractTileCollection> newCollections, out List<ICompleteHandComponent> components)
        {
            newCollections = CloneCollections(collections);
            components = new List<ICompleteHandComponent>();
        }

        private static int CalculateStandardShanten(List<ICompleteHandComponent> components)
        {
            int groups = 0, pairs = 0, taatsu = 0;
            foreach (ICompleteHandComponent component in components)
            {
                IncrementCounters(ref groups, ref pairs, ref taatsu, component);
            }
            return ShantenFormula.CalculateStandardShanten(groups, pairs, taatsu);
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
                default:
                    break;
            }
        }

        private static void ExtractNonconsecutiveTaatsuToComponentsList(List<ICompleteHandComponent> components, AbstractTileCollection collection)
        {
            foreach (ICompleteHandComponent component in NonconsecutiveTaatsuExtractor.ExtractNonconsecutiveTaatsu(collection))
            {
                components.Add(component);
            }
        }

        private static void ExtractConsecutiveTaatsuToComponentsList(List<ICompleteHandComponent> components, AbstractTileCollection collection)
        {
            foreach (ICompleteHandComponent component in ConsecutiveTaatsuExtractor.ExtractConsecutiveTaatsu(collection))
            {
                components.Add(component);
            }
        }

        private static void ExtractPairToComponentsList(List<ICompleteHandComponent> components, AbstractTileCollection collection)
        {
            foreach (ICompleteHandComponent component in PairExtractor.ExtractPair(collection))
            {
                components.Add(component);
            }
        }

        private static void ExtractChiiToComponentsList(List<ICompleteHandComponent> components, AbstractTileCollection collection)
        {
            foreach (ICompleteHandComponent component in ChiiExtractor.ExtractChii(collection))
            {
                components.Add(component);
            }
        }

        private static void ExtractPonToComponentsList(List<ICompleteHandComponent> components, AbstractTileCollection collection)
        {
            foreach (ICompleteHandComponent component in PonExtractor.ExtractPon(collection))
            {
                components.Add(component);
            }
        }

        private static List<AbstractTileCollection> CloneCollections(List<AbstractTileCollection> collections)
        {
            List<AbstractTileCollection> outputList = new List<AbstractTileCollection>();
            foreach (AbstractTileCollection collection in collections)
            {
                outputList.Add(collection.Clone());
            }
            return outputList;
        }
    }
}
