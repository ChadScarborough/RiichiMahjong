using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles;
using RMU.Yaku;
using RMU.Yaku.YakuLists;
using RMU.Globals;
using RMU.Hands.TestHands;

namespace RMUTests.YakuTests
{
    [TestClass]
    public class AllSimplesTest
    {
        private readonly AbstractYaku _allSimples = YakuList.ALL_SIMPLES;

        [TestMethod]
        public void Yaku_ReturnsCorrectStringName()
        {
            Assert.AreEqual("All Simples", _allSimples.GetName());
        }

        [TestMethod]
        public void Yaku_ReturnsCorrectIntValue()
        {
            Assert.AreEqual(1, _allSimples.GetValue(TestHandList.ALL_SIMPLES_TEST_HAND));
        }

        [TestMethod]
        public void CheckYakuReturnsTrue_WhenHandContainsOnlySimples()
        {
            TileObject extraTile = StandardTileList.EIGHT_MAN;
            Assert.IsTrue(_allSimples.CheckYaku(TestHandList.ALL_SIMPLES_TEST_HAND, extraTile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOneTerminalTile()
        {
            TileObject extraTile = StandardTileList.NINE_MAN;
            Assert.IsFalse(_allSimples.CheckYaku(TestHandList.ALL_SIMPLES_TEST_HAND, extraTile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOneHonorTile()
        {
            TileObject extraTile = StandardTileList.EAST_WIND;
            Assert.IsFalse(_allSimples.CheckYaku(TestHandList.ALL_SIMPLES_TEST_HAND, extraTile));
        }

        [TestMethod]
        public void CheckYakuReturnsFalse_WhenHandContainsOnlyHonorTiles()
        {
            TileObject extraTile = StandardTileList.SOUTH_WIND;
            Assert.IsFalse(_allSimples.CheckYaku(TestHandList.DRAGON_TEST_HAND, extraTile));
        }
    }
}
