using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameWinnerServiceTests 
    {
        IGameWinnerServices gameWinnerService;
        private char[,] gameBoard;

        [TestInitialize]
        public void InitializeTest()
        {
            gameWinnerService = new GameWinnerService();

            gameBoard = new char[3, 3]
            {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
            };
        }

        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            const char expected = ' ';
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            const char expected = 'X';
            var gameBoard = new char[3, 3] { {expected, expected, expected},
                                             {' ', ' ', ' '},
                                             {' ', ' ', ' '}};
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
            
        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[columnIndex, 0] = expected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            const char expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                gameBoard[cellIndex, cellIndex] = expected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyUpAndToRightIsWinner()
        {
            const char expected = 'X';
            int columnIndex = 2;
            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                gameBoard[columnIndex, rowIndex] = expected;
                columnIndex--;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
