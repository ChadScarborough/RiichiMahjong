using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Globals.Algorithms;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;

namespace RMU.Hands.CompleteHands
{
    public class SevenPairsCompleteHand : ICompleteHand
    {
        private readonly List<ICompleteHandComponent> _completeHand;
        private readonly List<ICompleteHandComponent> _constructedHand;
        private readonly TileObject _drawTile;
        private readonly List<TileObject> _tiles;
        private List<Yaku.StandardYaku.YakuBase> _satisfiedYaku;

        public SevenPairsCompleteHand(ITenpaiHand tenpaiHand, TileObject tile)
        {
            _completeHand = tenpaiHand.GetComponents();
            ICompleteHandComponent drawTile = CreateCompleteHandComponent(tile, DRAW_TILE);
            _completeHand.Add(drawTile);
            _completeHand = RadixSortForCompleteHandComponents.Sort(_completeHand);
            _drawTile = tile;
            _tiles = new List<TileObject>();

            _constructedHand = new List<ICompleteHandComponent>();
            ConstructHand();
            _constructedHand = RadixSortForCompleteHandComponents.Sort(_constructedHand);
            foreach (ICompleteHandComponent component in _constructedHand)
            {
                foreach (TileObject t in component.GetTiles())
                {
                    _tiles.Add(t);
                }
            }
        }

        public List<ICompleteHandComponent> GetComponents()
        {
            return _completeHand;
        }

        public Enums.CompleteHandWaitType GetWaitType()
        {
            return Enums.PAIR_WAIT;
        }

        public Enums.CompleteHandType GetCompleteHandType()
        {
            return Enums.SEVEN_PAIRS;
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

            List<TileObject> tileList;
            try
            {
                tileList = new List<TileObject> {_drawTile, isolatedTile.GetLeadTile()};
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

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }

        public void SetYaku(List<Yaku.StandardYaku.YakuBase> satisfiedYaku)
        {
            _satisfiedYaku = satisfiedYaku;
        }

        public List<Yaku.StandardYaku.YakuBase> GetYaku()
        {
            return _satisfiedYaku;
        }
    }
}
