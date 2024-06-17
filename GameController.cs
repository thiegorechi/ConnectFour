using System;

namespace ConnectFour
{
    public class GameController
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public GameController()
        {
            board = new Board();
            player1 = new HumanPlayer('X');
            Console.WriteLine("Choose opponent: 1 - Human, 2 - Computer");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 2)
            {
                player2 = new ComputerPlayer('O');
            }
            else
            {
                player2 = new HumanPlayer('O');
            }
            currentPlayer = player1;
        }

        public void StartGame()
        {
            bool gameWon = false;
            while (!gameWon)
            {
                board.DisplayBoard();
                Console.WriteLine($"{currentPlayer.Symbol}'s turn.");

                int column;
                if (currentPlayer is HumanPlayer)
                {
                    column = currentPlayer.GetMove();
                }
                else
                {
                    column = currentPlayer.GetMove();
                    Console.WriteLine($"Computer chooses column {column + 1}");
                }

                if (board.PlaceDisc(currentPlayer.Symbol, column))
                {
                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        gameWon = true;
                        board.DisplayBoard();
                        Console.WriteLine($"{currentPlayer.Symbol} wins!");
                    }
                    else if (board.IsFull())
                    {
                        gameWon = true;
                        board.DisplayBoard();
                        Console.WriteLine("It's a draw!");
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }
    }
}
