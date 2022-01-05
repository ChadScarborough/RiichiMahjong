using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandGroupFactory;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandIncompleteGroupFactory;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using RMU.Calls.CreateMeldBehaviours;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class CompleteHandComponentFactoryTest
    {
        ICompleteHandComponent _component;

        [TestMethod]
        public void FactorySuccessfullyCreates_ClosedChii()
        {
            _component = CreateCompleteHandComponent(new List<TileObject> { OneMan(), TwoMan(), ThreeMan()}, CLOSED_CHII);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_ClosedPon()
        {
            _component = CreateCompleteHandComponent(new List<TileObject> { OneMan(), OneMan(), OneMan() }, CLOSED_PON);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_ClosedKan()
        {
            OpenMeld closedKan = new OpenMeld(CLOSED_KAN_MELD, GreenDragon());
            _component = CreateCompleteHandComponent(closedKan);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_DrawTile()
        {
            _component = CreateCompleteHandComponent(FiveSou(), DRAW_TILE);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IncompleteSequenceClosedWait()
        {
            _component = CreateCompleteHandComponent(new List<TileObject> { FourPin(), SixPin() }, INCOMPLETE_SEQUENCE_CLOSED_WAIT);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IncompleteSequenceEdgeWait()
        {
            _component = CreateCompleteHandComponent(new List<TileObject> { EightSou(), NineSou() }, INCOMPLETE_SEQUENCE_EDGE_WAIT);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IncompleteSequenceOpenWait()
        {
            _component = CreateCompleteHandComponent(new List<TileObject> { FourMan(), FiveMan() }, INCOMPLETE_SEQUENCE_OPEN_WAIT);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IsolatedTile()
        {
            _component = CreateCompleteHandComponent(NineMan(), ISOLATED_TILE);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_OpenChii()
        {
            OpenMeld openChii = new OpenMeld(LOW_CHII, SevenPin());
            _component = CreateCompleteHandComponent(openChii);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_OpenKan()
        {
            OpenMeld openKan = new OpenMeld(OPEN_KAN_1, NorthWind());
            _component = CreateCompleteHandComponent(openKan);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_OpenPon()
        {
            OpenMeld openPon = new OpenMeld(PON, EightSou());
            _component = CreateCompleteHandComponent(openPon);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_Pair()
        {
            _component = CreateCompleteHandComponent(new List<TileObject> { TwoMan(), TwoMan() }, PAIR_COMPONENT);
            Assert.IsNotNull(_component);
        }

        [TestMethod]
        public void FactoryThrowsException_WhenGivenOneTile_ForGroupComponent()
        {
            Exception exception = null;
            try
            {
                _component = CreateCompleteHandComponent(SevenPin(), CLOSED_CHII);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void FactoryThrowsException_WhenGivenListOfTiles_ForSingleTileComponent()
        {
            Exception exception = null;
            try
            {
                _component = CreateCompleteHandComponent(new List<TileObject> { TwoSou(), ThreeSou(), FourSou() }, ISOLATED_TILE);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void GroupFactoryThrowsException_WhenGivenNonGroupComponent()
        {
            Exception exception = null;
            try
            {
                _component = CreateCompleteHandGroup(new List<TileObject> { TwoSou(), ThreeSou(), FourSou() }, ISOLATED_TILE);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void IncompleteGroupFactoryThrowsException_WhenGivenNonIncompleteGroupComponent()
        {
            Exception exception = null;
            try
            {
                _component = CreateCompleteHandIncompleteGroup(new List<TileObject> { TwoSou(), ThreeSou(), FourSou() }, ISOLATED_TILE);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }
    }
}
