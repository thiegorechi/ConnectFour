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
            // Verificar linhas, colunas e diagonais para uma vitória
            // Implementação omitida para simplicidade
            return false;
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
