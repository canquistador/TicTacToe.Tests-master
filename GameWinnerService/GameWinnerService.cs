using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services
{
    public interface IGameWinnerServices
    {
        char Validate(char[,] gameBoard);
    }
    public class GameWinnerService : IGameWinnerServices
    {
        private const char SymbolForNoWinner = ' ';
        public char Validate(char[,] gameBoard)
        {
            // HORIZONTAL CHECKS
            var currentWinningSymbol = CheckForThreeInARowInTopHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner) 
                return currentWinningSymbol;
            // new horizontalrow checks
            currentWinningSymbol = CheckForThreeInARowInMiddleHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowInBottomHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            // VERTICAL CHECKS
            currentWinningSymbol = CheckForThreeInARowInTopVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            // new vertical checks
            currentWinningSymbol = CheckForThreeInARowInMiddleVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowInBottomVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            // DIAGONAL CHECKS
            currentWinningSymbol = CheackForThreeInARowDiagonallyDown(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            // new diagonal up and right
            currentWinningSymbol = CheackForThreeInARowDiagonallyUp(gameBoard);
            return currentWinningSymbol;
        }

        /*
           Navneændring fra
           CheckForThreeInARowinVerticalColumn (det andet "in" startede også med småt før)
           til
           CheckForThreeInARowInTopVerticalColumn
         */
        private static char CheckForThreeInARowInTopVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 0];
            var rowTwoChar = gameBoard[1, 0];
            var rowThreeChar = gameBoard[2, 0];
            if (rowOneChar == rowTwoChar && rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }
        // mid row set
        private static char CheckForThreeInARowInMiddleVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 1];
            var rowTwoChar = gameBoard[1, 1];
            var rowThreeChar = gameBoard[2, 1];
            if (rowOneChar == rowTwoChar && rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }
        // bottom row set
        private static char CheckForThreeInARowInBottomVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 2];
            var rowTwoChar = gameBoard[1, 2];
            var rowThreeChar = gameBoard[2, 2];
            if (rowOneChar == rowTwoChar && rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }
        /*
          navneændring fra
          CheckForThreeInARowInHorizontalRow
          til
          CheckForThreeInARowInTopHorizontalRow
        */
        private static char CheckForThreeInARowInTopHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[0, 0];
            var columnTwoChar = gameBoard[0, 1];
            var columnThreeChar = gameBoard[0, 2];
            if (columnOneChar == columnTwoChar && columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }
        // to nye HorizontalRow methods
        private static char CheckForThreeInARowInMiddleHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[1, 0];
            var columnTwoChar = gameBoard[1, 1];
            var columnThreeChar = gameBoard[1, 2];
            if (columnOneChar == columnTwoChar && columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowInBottomHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[2, 0];
            var columnTwoChar = gameBoard[2, 1];
            var columnThreeChar = gameBoard[2, 2];
            if (columnOneChar == columnTwoChar && columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheackForThreeInARowDiagonallyDown(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];
            if (cellOneChar == cellTwoChar && cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
        // new
        private static char CheackForThreeInARowDiagonallyUp(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[2, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[0, 2];
            if (cellOneChar == cellTwoChar && cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
    }
}
