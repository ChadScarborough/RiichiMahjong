using System;
using System.Collections.Generic;
using RMU.Globals.Algorithms;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using RMU.Players;
using static RMU.Globals.Enums;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using static RMU.Globals.Functions;

namespace RMU.Hands.CompleteHands
{
    public class StandardCompleteHand : ICompleteHand
    {
        private readonly List<ICompleteHandComponent> _components;
        private readonly List<ICompleteHandComponent> _constructedHand;
        private readonly CompleteHandWaitType _waitType;
        private readonly bool _isOpen;
        private readonly TileObject _drawTile;
        private readonly List<ICompleteHandComponent> _triplets;
        private readonly List<ICompleteHandComponent> _sequences;
        private readonly List<ICompleteHandComponent> _pairs;
        private readonly List<TileObject> _tiles;
        private readonly Player _player;
        private List<Yaku.StandardYaku.YakuBase> _satisfiedYaku;

        public StandardCompleteHand(ITenpaiHand tenpaiHand, TileObject drawTile, Player player)
        {
            _player = player;
            _components = tenpaiHand.GetComponents();
            _drawTile = drawTile;
            _components.Add(CreateCompleteHandComponent(drawTile, DRAW_TILE));
            _waitType = tenpaiHand.GetWaitType();
            _constructedHand = new List<ICompleteHandComponent>();
            _components = RadixSortForCompleteHandComponents.Sort(_components);
            _triplets = new List<ICompleteHandComponent>();
            _sequences = new List<ICompleteHandComponent>();
            _pairs = new List<ICompleteHandComponent>();
            _tiles = new List<TileObject>();
            _isOpen = player.GetHand().IsOpen();
            
            switch (_waitType)
            {
                case PAIR_WAIT:
                    ConstructPairWaitHand();
                    break;
                case TWO_SIDED_TRIPLET_WAIT:
                    ConstructTwoSidedTripletWaitHand();
                    break;
                case EDGE_WAIT:
                    ConstructEdgeWaitHand();
                    break;
                case CLOSED_WAIT:
                    ConstructClosedWaitHand();
                    break;
                case OPEN_WAIT:
                    ConstructOpenWaitHand();
                    break;
                default:
                    throw new Exception("Invalid wait type");
            }

            _constructedHand = RadixSortForCompleteHandComponents.Sort(_constructedHand);
            foreach (ICompleteHandComponent component in _constructedHand)
            {
                switch (component.GetComponentType())
                {
                    case OPEN_KAN:
                    case CLOSED_KAN_COMPONENT:
                    case OPEN_PON:
                    case CLOSED_PON:
                        _triplets.Add(component);
                        break;
                    case OPEN_CHII:
                    case CLOSED_CHII:
                        _sequences.Add(component);
                        break;
                    case PAIR_COMPONENT:
                        _pairs.Add(component);
                        break;
                    default:
                        throw new Exception("I don't know what the heck happened, honestly");
                }

                foreach (TileObject tile in component.GetTiles())
                {
                    _tiles.Add(tile);
                }
            }
        }

        public List<ICompleteHandComponent> GetComponents()
        {
            return _components;
        }

        public List<ICompleteHandComponent> GetConstructedHandComponents()
        {
            return _constructedHand;
        }

        public List<ICompleteHandComponent> GetTriplets()
        {
            return _triplets;
        }

        public List<ICompleteHandComponent> GetSequences()
        {
            return _sequences;
        }

        public List<ICompleteHandComponent> GetPairs()
        {
            return _pairs;
        }

        public List<ICompleteHandComponent> GetIsolatedTiles()
        {
            return new List<ICompleteHandComponent>();
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }

        public CompleteHandWaitType GetWaitType()
        {
            return _waitType;
        }

        public CompleteHandType GetCompleteHandType()
        {
            return STANDARD;
        }

        public bool IsOpen()
        {
            return _isOpen;
        }

        private void ConstructPairWaitHand()
        {
            ICompleteHandComponent isolatedTile = new IsolatedTile(null);
            List<TileObject> tileList = new List<TileObject>();
            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetGeneralComponentType() is GROUP or PAIR)
                {
                    _constructedHand.Add(component);
                    continue;
                }

                if (component.GetComponentType() is ISOLATED_TILE)
                {
                    isolatedTile = component;
                }
            }

            try
            {
                if (AreTilesEquivalent(isolatedTile.GetLeadTile(), _drawTile) == false)
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception("Invalid hand composition");
            }
            
            
            tileList.Add(isolatedTile.GetLeadTile());
            tileList.Add(_drawTile);
            ICompleteHandComponent pair = CreateCompleteHandComponent(tileList, CompleteHandComponentType.Pair);
            _constructedHand.Add(pair);
        }

        private void ConstructTwoSidedTripletWaitHand()
        {
            ICompleteHandComponent incompletePair = null;
            ICompleteHandComponent completePair = null;
            List<TileObject> tileList = new List<TileObject>();

            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetGeneralComponentType() is GROUP)
                {
                    _constructedHand.Add(component);
                    continue;
                }

                if (component.GetGeneralComponentType() is PAIR)
                {
                    if (AreTilesEquivalent(component.GetLeadTile(), _drawTile))
                    {
                        completePair = component;
                        continue;
                    }

                    incompletePair = component;
                }
            }

            if (completePair is null)
            {
                throw new Exception("Invalid hand composition");
            }

            tileList.Add(_drawTile);
            tileList.Add(completePair.GetLeadTile());
            tileList.Add(completePair.GetLeadTile().Clone());
            ICompleteHandComponent triplet = CreateCompleteHandComponent(tileList, CompleteHandComponentType.ClosedPon);
            _constructedHand.Add(triplet);
            _constructedHand.Add(incompletePair);
        }

        private void ConstructEdgeWaitHand()
        {
            ICompleteHandComponent edgeWaitTaatsu = null;
            List<TileObject> tileList;
            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetGeneralComponentType() is GROUP or PAIR)
                {
                    _constructedHand.Add(component);
                    continue;
                }

                if (component.GetGeneralComponentType() is TAATSU)
                {
                    edgeWaitTaatsu = component;
                }
            }

            if (edgeWaitTaatsu.GetLeadTile().GetValue() is 1)
            {
                tileList = new List<TileObject> {edgeWaitTaatsu.GetLeadTile(), edgeWaitTaatsu.GetTiles()[1], _drawTile};
            }
            else
            {
                tileList = new List<TileObject> {_drawTile, edgeWaitTaatsu.GetLeadTile(), edgeWaitTaatsu.GetTiles()[1]};
            }

            ICompleteHandComponent completeSequence = CreateCompleteHandComponent(tileList, CLOSED_CHII);
            _constructedHand.Add(completeSequence);
        }

        private void ConstructClosedWaitHand()
        {
            ICompleteHandComponent closedWaitTaatsu = null;
            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetGeneralComponentType() is GROUP or PAIR)
                {
                    _constructedHand.Add(component);
                    continue;
                }

                if (component.GetComponentType() is INCOMPLETE_SEQUENCE_CLOSED_WAIT)
                {
                    closedWaitTaatsu = component;
                }
            }

            List<TileObject> tileList;
            
            try
            {
                tileList = new List<TileObject>
                {
                    closedWaitTaatsu.GetLeadTile(),
                    _drawTile,
                    closedWaitTaatsu.GetTiles()[1]
                };
            }
            catch
            {
                throw new Exception("Invalid hand composition");
            }

            ICompleteHandComponent completeSequence = CreateCompleteHandComponent(tileList, CLOSED_CHII);
            _constructedHand.Add(completeSequence);
        }

        private void ConstructOpenWaitHand()
        {
            ICompleteHandComponent openWaitTaatsu = null;
            bool drawTileIsBelowTaatsu;
            foreach (ICompleteHandComponent component in _components)
            {
                if (component.GetGeneralComponentType() is GROUP)
                {
                    _constructedHand.Add(component);
                    continue;
                }
                if (component.GetGeneralComponentType() is TAATSU)
                {
                    openWaitTaatsu = component;
                }
            }

            try
            {
                if (_drawTile.GetValue() == openWaitTaatsu.GetLeadTile().GetValue() - 1)
                {
                    drawTileIsBelowTaatsu = true;
                }
                else
                {
                    drawTileIsBelowTaatsu = false;
                }
            }
            catch
            {
                throw new Exception("Invalid hand composition");
            }

            List<TileObject> tileList;

            if (drawTileIsBelowTaatsu)
            {
                tileList = new List<TileObject>
                {
                    _drawTile, openWaitTaatsu.GetLeadTile(), openWaitTaatsu.GetTiles()[1]
                };
            }
            else
            {
                tileList = new List<TileObject>
                {
                    openWaitTaatsu.GetLeadTile(), openWaitTaatsu.GetTiles()[1], _drawTile
                };
            }

            ICompleteHandComponent completedSequence =
                CreateCompleteHandComponent(tileList, CompleteHandComponentType.ClosedChii);

            _constructedHand.Add(completedSequence);
        }

        public void SetYaku(List<Yaku.StandardYaku.YakuBase> satisfiedYaku)
        {
            _satisfiedYaku = satisfiedYaku;
        }

        public List<Yaku.StandardYaku.YakuBase> GetYaku()
        {
            return _satisfiedYaku;
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}
