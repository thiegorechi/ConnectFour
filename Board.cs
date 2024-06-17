using System;

public class Board
{
    private const int Rows = 6;
    private const int Columns = 7;
    private char[,] grid;

    public Board()
    {
        grid = new char[Rows, Columns];
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                grid[row, col] = ' ';
            }
        }
    }

    public bool DropPiece(int column, char piece)
    {
        if (column < 0 || column >= Columns) return false;

        for (int row = Rows - 1; row >= 0; row--)
        {
            if (grid[row, column] == ' ')
            {
                grid[row, column] = piece;
                return true;
            }
        }
        return false;
    }

    public bool CheckForWin(char piece)
    {
        return CheckHorizontalWin(piece) || CheckVerticalWin(piece) || CheckDiagonalWin(piece);
    }

    private bool CheckHorizontalWin(char piece)
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns - 3; col++)
            {
                if (grid[row, col] == piece && grid[row, col + 1] == piece &&
                    grid[row, col + 2] == piece && grid[row, col + 3] == piece)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckVerticalWin(char piece)
    {
        for (int row = 0; row < Rows - 3; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[row, col] == piece && grid[row + 1, col] == piece &&
                    grid[row + 2, col] == piece && grid[row + 3, col] == piece)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckDiagonalWin(char piece)
    {
        for (int row = 3; row < Rows; row++)
        {
            for (int col = 0; col < Columns - 3; col++)
            {
                if (grid[row, col] == piece && grid[row - 1, col + 1] == piece &&
                    grid[row - 2, col + 2] == piece && grid[row - 3, col + 3] == piece)
                {
                    return true;
                }
            }
        }

        for (int row = 0; row < Rows - 3; row++)
        {
            for (int col = 0; col < Columns - 3; col++)
            {
                if (grid[row, col] == piece && grid[row + 1, col + 1] == piece &&
                    grid[row + 2, col + 2] == piece && grid[row + 3, col + 3] == piece)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Display()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                Console.Write($"| {grid[row, col]} ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine(new string('-', Columns * 4));
    }
}
