using Projectsodv1202;
using System;

public class HumanPlayer : Player
{
    public HumanPlayer(string name, string symbol) : base(name, symbol) { }

    public override void MakeMove(Board board)
    {
        while (true)
        {
            Console.Write($"{Name} ({Symbol}) - Choose column (1-7): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int col))
            {
                col--; // convert to 0-6

                if (col >= 0 && col < 7)
                {
                    if (board.PlaceDisc(col, Symbol))
                        break;
                    else
                        Console.WriteLine("Column is full. Try another.");
                }
                else
                {
                    Console.WriteLine("Enter a number between 1 and 7.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}