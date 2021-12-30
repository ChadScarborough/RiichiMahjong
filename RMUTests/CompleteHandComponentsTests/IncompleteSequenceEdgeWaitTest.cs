using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Hand.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class IncompleteSequenceEdgeWaitTest
    {
        private ICompleteHandComponent _incompleteSequenceEdgeWait;

        private void Setup()
        {
            _incompleteSequenceEdgeWait = CreateCompleteHandComponent(new List<TileObject> { EightMan(), NineMan() }, INCOMPLETE_SEQUENCE_EDGE_WAIT);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IncompleteSequenceEdgeWait()
        {
            Setup();
            Assert.IsNotNull(_incompleteSequenceEdgeWait);
        }

        [TestMethod]
        public void GetComponentType_ReturnsIncompleteSequenceEdgeWait()
        {
            Setup();
            Assert.AreEqual(INCOMPLETE_SEQUENCE_EDGE_WAIT, _incompleteSequenceEdgeWait.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsTaatsu()
        {
            Setup();
            Assert.AreEqual(TAATSU, _incompleteSequenceEdgeWait.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsSevenMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(EightMan(), _incompleteSequenceEdgeWait.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListContainingSevenManAndNineMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(EightMan(), _incompleteSequenceEdgeWait.GetTiles()[0]));
            Assert.IsTrue(AreTilesEquivalent(NineMan(), _incompleteSequenceEdgeWait.GetTiles()[1]));
        }
    }
}
