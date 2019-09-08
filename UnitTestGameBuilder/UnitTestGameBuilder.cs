using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGameBuilder
{
    [TestClass]
    public class UnitTestGameBuilder
    {
        //TODO: write unit tests for all the corner and edge cases
        [TestMethod]
        public void ShouldDieLiveCell_If_LessThanTwoLiveNeighbours ()
        {
            //Arrange or setup
            uint universeSize = 3;
            IGameBuilder gameBuilder = new GameBuilder(new GameOfLife(universeSize));

            var cells = gameBuilder.GetCells();

            cells[0, 1].IsAlive = true;
            cells[1, 1].IsAlive = true;

            //Perform or Act
            gameBuilder.Play();

            //validate and Assert
            for (var i = 0; i < universeSize; i++)
            {
                for (var j = 0; j < universeSize; j++)
                {
                    Assert.AreEqual(cells[i, j].IsAlive, false);
                }
            }
        }

        [TestMethod]
        public void ShouldLive_LiveCell_If_TwoOrThreeLiveNeighbours()
        {
            //Arrange or setup
            uint universeSize = 3;
            IGameBuilder gameBuilder = new GameBuilder(new GameOfLife(universeSize));

            var cells = gameBuilder.GetCells();

            cells[0, 1].IsAlive = true;
            cells[1, 1].IsAlive = true;
            cells[2, 1].IsAlive = true;

            //Perform or Act
            gameBuilder.Play();

            //validate and Assert
            Assert.AreEqual(cells[0, 1].IsAlive, false);
            Assert.AreEqual(cells[1, 1].IsAlive, true);
            Assert.AreEqual(cells[2, 1].IsAlive, false);
        }

        [TestMethod]
        public void ShouldLive_DedCell_If_ExactlyThreeLiveNeighbours()
        {
            //Arrange or setup
            uint universeSize = 3;
            IGameBuilder gameBuilder = new GameBuilder(new GameOfLife(universeSize));

            var cells = gameBuilder.GetCells();

            cells[0, 0].IsAlive = true;
            cells[0, 1].IsAlive = true;
            cells[1, 1].IsAlive = false;
            cells[2, 1].IsAlive = true;

            //Perform or Act
            gameBuilder.Play();

            //validate and Assert
            Assert.AreEqual(cells[0, 0].IsAlive, false);
            Assert.AreEqual(cells[0, 1].IsAlive, false);
            Assert.AreEqual(cells[1, 1].IsAlive, true);
            Assert.AreEqual(cells[2, 1].IsAlive, false);
        }

        [TestMethod]
        public void ShouldDie_LiveCell_If_MoreThanThreeLiveNeighbours()
        {
            //Arrange or setup
            uint universeSize = 3;
            IGameBuilder gameBuilder = new GameBuilder(new GameOfLife(universeSize));

            var cells = gameBuilder.GetCells();

            cells[0, 0].IsAlive = true;
            cells[0, 1].IsAlive = true;
            cells[0, 2].IsAlive = true;
            cells[1, 1].IsAlive = true;
            cells[2, 1].IsAlive = true;

            //Perform or Act
            gameBuilder.Play();

            //validate and Assert
            Assert.AreEqual(cells[0, 0].IsAlive, true);
            Assert.AreEqual(cells[0, 1].IsAlive, true);
            Assert.AreEqual(cells[0, 2].IsAlive, true);
            Assert.AreEqual(cells[1, 1].IsAlive, false);
            Assert.AreEqual(cells[2, 1].IsAlive, false);
        }
    }
}
