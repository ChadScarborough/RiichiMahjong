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
    public class DrawTileTest
    {
        private ICompleteHandComponent _drawTile;

        private void Setup()
        {
            _drawTile = CreateCompleteHandComponent(EightSou(), DRAW_TILE);
        }

        [TestMethod]
        public void FactorySuccessfullyCreatesDrawTile()
        {
            Setup();
            Assert.IsNotNull(_drawTile);
        }

        [TestMethod]
        public void GetComponentType_ReturnsDrawTile()
        {
            Setup();
            Assert.AreEqual(DRAW_TILE, _drawTile.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsTile()
        {
            Setup();
            Assert.AreEqual(TILE, _drawTile.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsEightSou()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(EightSou(), _drawTile.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListContainingExactlyOneEightSou()
        {
            Setup();
            Assert.AreEqual(1, _drawTile.GetTiles().Count);
            Assert.IsTrue(AreTilesEquivalent(EightSou(), _drawTile.GetTiles()[0]));
        }
    }
}
