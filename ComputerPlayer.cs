using Projectsodv1202;
using System;
using System.Threading;

public class ComputerPlayer : Player
{
    private Random random = new Random();

    public ComputerPlayer(string name, string symbol) : base(name, symbol) { }

    public override void MakeMove(Board board)
    {
        Thread.Sleep(500);
        int column;

        // Try to win
        for (int col = 0; col < 7; col++)
        {
            if (board.CanPlace(col))
            {
                Board temp = board.Clone();
                temp.PlaceDisc(col, Symbol);

                if (temp.CheckWinner())
                {
                    board.PlaceDisc(col, Symbol);
                    return;
                }
            }
        }

        // Try to block
        string opponent = Symbol == "X" ? "O" : "X";

        for (int col = 0; col < 7; col++)
        {
            if (board.CanPlace(col))
            {
                Board temp = board.Clone();
                temp.PlaceDisc(col, opponent);

                if (temp.CheckWinner())
                {
                    board.PlaceDisc(col, Symbol);
                    return;
                }
            }
        }

        // Otherwise random
        do
        {
            column = random.Next(0, 7);
        }
        while (!board.CanPlace(column));

        board.PlaceDisc(column, Symbol);
    }
}