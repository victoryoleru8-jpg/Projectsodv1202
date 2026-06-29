using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Projectsodv1202
{
    public class Game
    {
        private Player player1;
        private Player player2;
        private Board board;

        public Game(int mode)
        {
            player1 = CreateHumanPlayer(1);

            if (mode == 1)
            {
                player2 = CreateHumanPlayer(2);
            }
            else
            {
                string aiSymbol = player1.Symbol == "X" ? "O" : "X";
                player2 = new ComputerPlayer("Computer", aiSymbol);
            }

            board = new Board();
        }

        private Player CreateHumanPlayer(int num)
        {
            Console.Write($"Player {num} name: ");
            string name = Console.ReadLine();

            Console.Write($"Player {num} symbol: ");
            string symbol = Console.ReadLine().ToUpper();

            return new HumanPlayer(name, symbol);
        }

        public void Start()
        {
            Player current = player1;

            while (true)
            {
                board.Display();
                current.MakeMove(board);

                if (board.CheckWinner())
                {
                    board.Display();
                    Console.WriteLine($"{current.Name} wins!");
                    break;
                }

                if (board.IsFull())
                {
                    board.Display();
                    Console.WriteLine("Draw!");
                    break;
                }

                current = current == player1 ? player2 : player1;
            }
        }
    }
}

