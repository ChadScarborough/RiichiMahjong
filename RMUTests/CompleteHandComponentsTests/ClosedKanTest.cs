using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Hand.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using RMU.Hand;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class ClosedKanTest
    {
        ICompleteHandComponent _closedKan;

        private void Setup()
        {
            OpenMeld ck = new OpenMeld(CLOSED_KAN_MELD, RedDragon());
            _closedKan = CreateCompleteHandComponent(ck);
        }
        
        [TestMethod]
        public void CompleteHandComponentFactory_SuccessfullyCreatesClosedKan()
        {
            Setup();
            Assert.IsNotNull(_closedKan);
        }

        [TestMethod]
        public void GetComponentType_ReturnsClosedKanComponent()
        {
            Setup();
            Assert.AreEqual(CLOSED_KAN_COMPONENT, _closedKan.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsGroup()
        {
            Setup();
            Assert.AreEqual(GROUP, _closedKan.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetTiles_ReturnsFourRedDragonTiles()
        {
            Setup();
            for(int i = 0; i < 4; i++)
            {
                Assert.IsTrue(AreTilesEquivalent(RedDragon(), _closedKan.GetTiles()[i]));
            }
        }

        [TestMethod]
        public void GetLeadTile_ReturnsRedDragon()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(RedDragon(), _closedKan.GetLeadTile()));
        }
    }
}
