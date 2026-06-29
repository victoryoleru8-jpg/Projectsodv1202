using System;

public class Board
{
    private string[,] grid = new string[6, 7];

    public Board()
    {
        for (int r = 0; r < 6; r++)
            for (int c = 0; c < 7; c++)
                grid[r, c] = " ";
    }

    public bool PlaceDisc(int col, string symbol)
    {
        for (int row = 5; row >= 0; row--)
        {
            if (grid[row, col] == " ")
            {
                grid[row, col] = symbol;
                return true;
            }
        }
        return false;
    }

    public bool CanPlace(int col)
    {
        return grid[0, col] == " ";
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(" 1   2   3   4   5   6   7 ");
        Console.WriteLine("-----------------------------");

        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 7; c++)
                Console.Write($"| {grid[r, c]} ");
            Console.WriteLine("|");
            Console.WriteLine("-----------------------------");
        }
    }

    public bool CheckWinner()
    {
        return CheckLines();
    }

    private bool CheckLines()
    {
        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 7; c++)
            {
                string s = grid[r, c];
                if (s == " ") continue;

                if (c + 3 < 7 &&
                    s == grid[r, c + 1] &&
                    s == grid[r, c + 2] &&
                    s == grid[r, c + 3]) return true;

                if (r + 3 < 6 &&
                    s == grid[r + 1, c] &&
                    s == grid[r + 2, c] &&
                    s == grid[r + 3, c]) return true;

                if (r + 3 < 6 && c + 3 < 7 &&
                    s == grid[r + 1, c + 1] &&
                    s == grid[r + 2, c + 2] &&
                    s == grid[r + 3, c + 3]) return true;

                if (r - 3 >= 0 && c + 3 < 7 &&
                    s == grid[r - 1, c + 1] &&
                    s == grid[r - 2, c + 2] &&
                    s == grid[r - 3, c + 3]) return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int c = 0; c < 7; c++)
            if (grid[0, c] == " ") return false;
        return true;
    }

    public Board Clone()
    {
        Board copy = new Board();
        Array.Copy(grid, copy.grid, grid.Length);
        return copy;
    }
}