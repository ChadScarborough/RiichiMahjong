﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Hand.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;
using RMU.Hand;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class OpenPonTest
    {
        private ICompleteHandComponent _openPon;

        private void Setup()
        {
            OpenMeld op = new OpenMeld(PON, EastWind());
            _openPon = CreateCompleteHandComponent(op);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_OpenPon()
        {
            Setup();
            Assert.IsNotNull(_openPon);
        }

        [TestMethod]
        public void GetComponentType_ReturnsOpenPon()
        {
            Setup();
            Assert.AreEqual(OPEN_PON, _openPon.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsGroup()
        {
            Setup();
            Assert.AreEqual(GROUP, _openPon.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsEastWind()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(EAST_WIND, _openPon.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListOfSizeThree_ContainingThreeEastWinds()
        {
            Setup();
            Assert.AreEqual(3, _openPon.GetTiles().Count);
            for(int i = 0; i < 3; i++)
            {
                Assert.IsTrue(AreTilesEquivalent(EAST_WIND, _openPon.GetTiles()[i]));
            }
        }
    }
}