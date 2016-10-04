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

        //new tests from here on down

        // anden kolonne
        [TestMethod] 
        public void PlayerWithAllSpacesInSecondColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                //for loop sets [0,1],[1,1],[2,1]
                gameBoard[columnIndex, 1] = expected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        // tredje kolonne
        [TestMethod]
        public void PlayerWithAllSpacesInThirdColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                //for loop sets [0,2],[1,2],[2,2]
                gameBoard[columnIndex, 1] = expected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        // anden række
        [TestMethod]
        public void PlayerWithAllSpacesInMiddleRowIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                //for loop sets [1,0],[1,1],[1,2]
                gameBoard[1, columnIndex] = expected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        // tredje række
        [TestMethod]
        public void PlayerWithAllSpacesInBottomRowIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                //for loop sets [2,0],[2,1],[2,2]
                gameBoard[2, columnIndex] = expected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        /*
            Skråt op til højre
            [' '],[' '],['X']
            [' '],['X'],[' ']
            ['X'],[' '],[' ']
        */
        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyUpAndToRightIsWinner()
        {

            const char expected = 'X';
            int columnIndex = 2;
            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
            {   //for loop checks [2,0],[1,1],[0,2]
                gameBoard[columnIndex, rowIndex] = expected;
                columnIndex--;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
