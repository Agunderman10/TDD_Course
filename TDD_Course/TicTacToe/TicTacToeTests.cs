using System;
using NUnit.Framework;

namespace TDD_Course
{
    [TestFixture]
    public class TicTacToeTests
    {
        [Test]
        public void CreateGame_GameIsInTheCorrectState()
        {
            Game game = new Game();
            Assert.AreEqual(0, game.MovesCounter);
            Assert.AreEqual(State.Unset, game.GetState(1));
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(5, 1)]
        [TestCase(9, 1)]
        [TestCase(7, 1)]
        public void MakeMove_CounterShifts(int index, int expected)
        {
            Game game = new Game();
            game.MakeMove(index);

            Assert.AreEqual(expected, game.MovesCounter);
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        [TestCase(-1)]
        public void MakeInvalidMove_ThrowsException(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(index);
            });
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(9)]
        public void MoveOnTheSameSquare_ThrowsException(int index)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var game = new Game();
                game.MakeMove(index);
                game.MakeMove(index);
            });
        }

        [Test]
        public void MakingMoves_SetStateCorrectly()
        {
            Game game = new Game();
            
            MakeMoves(game, 1, 2, 3, 4);

            DetermineCorrectStateBasedOnIndex(game, 1, 2, 3, 4);
        }

        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach(var index in indexes)
            {
                game.MakeMove(index);
            }
        }

        private void DetermineCorrectStateBasedOnIndex(Game game, params int[] indexes)
        {
            foreach(var index in indexes)
            {
                if (index % 2 == 0)
                {
                    Assert.AreEqual(State.Zero, game.GetState(index));
                }
                else
                {
                    Assert.AreEqual(State.Cross, game.GetState(index));
                }
            }
        }

        [Test]
        public void GetWinner_ZeroesWinVertically_ReturnsZeroes()
        {
            Game game = new Game();

            //indexes of 2, 5, 8 means zeroes win
            MakeMoves(game, 1, 2, 3, 5, 7, 8);

            Assert.AreEqual(Winner.Zeroes, game.GetWinner());
        }

        [Test] 
        public void GetWinner_CrossesWinDiagonal_ReturnsCrosses()
        {
            Game game = new Game();

            //indexes of 1, 5, 9 means crosses win
            MakeMoves(game, 1, 4, 5, 2, 9);

            Assert.AreEqual(Winner.Crosses, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
        {
            Game game = new Game();

            MakeMoves(game, 1, 2, 4);

            Assert.AreEqual(Winner.GameIsUnfinished, game.GetWinner());
        }
    }
}
