using System;

namespace ConnectFour
{
    public class Board
    {
        private char[,] grid;
        private const int rows = 6;
        private const int columns = 7;

        public Board()
        {
            grid = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public bool PlaceDisc(char symbol, int column)
        {
            if (column < 0 || column >= columns)
            {
                return false;
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                if (grid[i, column] == ' ')
                {
                    grid[i, column] = symbol;
                    return true;
                }
            }

            return false; // Coluna cheia
        }

        public bool CheckWin(char symbol)
        {
            // Verificar linhas
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns - 3; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row, col + 1] == symbol &&
                        grid[row, col + 2] == symbol &&
                        grid[row, col + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Verificar colunas
            for (int row = 0; row < rows - 3; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row + 1, col] == symbol &&
                        grid[row + 2, col] == symbol &&
                        grid[row + 3, col] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Verificar diagonais (cima-esquerda para baixo-direita)
            for (int row = 0; row < rows - 3; row++)
            {
                for (int col = 0; col < columns - 3; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row + 1, col + 1] == symbol &&
                        grid[row + 2, col + 2] == symbol &&
                        grid[row + 3, col + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Verificar diagonais (baixo-esquerda para cima-direita)
            for (int row = 3; row < rows; row++)
            {
                for (int col = 0; col < columns - 3; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row - 1, col + 1] == symbol &&
                        grid[row - 2, col + 2] == symbol &&
                        grid[row - 3, col + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsFull()
        {
            for (int col = 0; col < columns; col++)
            {
                if (grid[0, col] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"| {grid[i, j]} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('-', columns * 4));
        }
    }
}
