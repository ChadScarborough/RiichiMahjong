using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Hand.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;
using RMU.Hand;
using RMU.Hand.Calls;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class OpenKanTest
    {
        private ICompleteHandComponent _openKan;

        private void Setup()
        {
            OpenMeld ok = new OpenMeld(OPEN_KAN_1, EastWind());
            _openKan = CreateCompleteHandComponent(ok);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_OpenKan()
        {
            Setup();
            Assert.IsNotNull(_openKan);
        }

        [TestMethod]
        public void GetComponentType_ReturnsOpenKan()
        {
            Setup();
            Assert.AreEqual(OPEN_KAN, _openKan.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsGroup()
        {
            Setup();
            Assert.AreEqual(GROUP, _openKan.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsEastWind()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(EAST_WIND, _openKan.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListOfSizeFour_ContainingFourEastWinds()
        {
            Setup();
            Assert.AreEqual(4, _openKan.GetTiles().Count);
            for (int i = 0; i < 4; i++)
            {
                Assert.IsTrue(AreTilesEquivalent(EAST_WIND, _openKan.GetTiles()[i]));
            }
        }
    }
}
