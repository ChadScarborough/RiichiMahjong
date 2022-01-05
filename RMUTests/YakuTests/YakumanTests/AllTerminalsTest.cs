using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Yaku.Yakuman;
using RMU.Tiles;
using RMU.Globals;
using RMU.Hands.TestHands;
using RMU.Yaku.YakuLists;

namespace RMUTests.YakuTests.YakumanTests
{
    [TestClass]
    public class AllTerminalsTest
    {
        private AbstractYakuman _allTerminals = YakumanList.ALL_TERMINALS;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("All Terminals", _allTerminals.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(13, _allTerminals.GetValue(TestHandList.ALL_TERMINALS_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandOnlyContainsHonorTiles()
        {
            TileObject tile = TileFactory.CreateTile(ConstValues.SOUTH_WIND, Enums.Suit.Wind);
            Assert.IsFalse(_allTerminals.CheckYaku(TestHandList.DRAGON_TEST_HAND, tile));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandOnlyContainsTerminalTiles()
        {
            TileObject tile = TileFactory.CreateTile(1, Enums.Suit.Sou);
            Assert.IsTrue(_allTerminals.CheckYaku(TestHandList.ALL_TERMINALS_TEST_HAND, tile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOneNonTerminalTile()
        {
            TileObject tile = TileFactory.CreateTile(4, Enums.Suit.Pin);
            Assert.IsFalse(_allTerminals.CheckYaku(TestHandList.ALL_TERMINALS_TEST_HAND, tile));
        }
    }
}
