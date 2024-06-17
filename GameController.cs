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
            player1 = new HumanPlayer('X', "Jogador 1"); // Corrigir o erro na linha 15
            Console.WriteLine("Choose opponent: 1 - Human, 2 - Computer");
            int choice;
            do
            {
                string? input = Console.ReadLine();
                choice = string.IsNullOrEmpty(input) ? 0 : int.Parse(input);
            } while (choice != 1 && choice != 2);

            if (choice == 2)
            {
                player2 = new ComputerPlayer('O', "Computer"); // Corrigir o erro na linha 26
            }
            else
            {
                player2 = new HumanPlayer('O', "Jogador 2"); // Corrigir o erro na linha 30
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

                int column = currentPlayer.GetMove();
                if (board.PlaceDisc(currentPlayer.Symbol, column))
                {
                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        gameWon = true;
                        board.DisplayBoard();
                        Console.WriteLine($"{currentPlayer.Name} wins!");
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
