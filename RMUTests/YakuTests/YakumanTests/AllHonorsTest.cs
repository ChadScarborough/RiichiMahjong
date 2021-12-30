using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Yaku.Yakuman;
using RMU.Hand.TestHands;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.YakuLists;

namespace RMUTests.YakuTests.YakumanTests
{
    [TestClass]
    public class AllHonorsTest
    {
        private AbstractYakuman _allHonors = YakumanList.ALL_HONORS;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("All Honors", _allHonors.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(13, _allHonors.GetValue(TestHandList.DRAGON_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandOnlyContainsHonorTiles()
        {
            TileObject tile = StandardTileList.SOUTH_WIND;
            Assert.IsTrue(_allHonors.CheckYaku(TestHandList.DRAGON_TEST_HAND, tile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandOnlyContainsTerminalTiles()
        {
            TileObject tile = StandardTileList.ONE_SOU;
            Assert.IsFalse(_allHonors.CheckYaku(TestHandList.ALL_TERMINALS_TEST_HAND, tile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOneNonHonorTile()
        {
            TileObject extraTile = StandardTileList.THREE_SOU;
            Assert.IsFalse(_allHonors.CheckYaku(TestHandList.DRAGON_TEST_HAND, extraTile));
        }
    }
}
