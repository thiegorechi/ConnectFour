using System;

namespace ConnectFour
{
    public class Game
    {
        private Board board;
        private Player player1;
        private Player player2;

        public Game()
        {
            board = new Board();
            player1 = new HumanPlayer('X', "Jogador 1");
            player2 = new HumanPlayer('O', "Jogador 2");
        }

        public void Play()
        {
            Player currentPlayer = player1;
            while (true)
            {
                board.DisplayBoard();
                int move = currentPlayer.GetMove();

                if (!board.PlaceDisc(currentPlayer.Symbol, move))
                {
                    Console.WriteLine("Coluna cheia. Tente novamente.");
                    continue;
                }

                if (board.CheckWin(currentPlayer.Symbol))
                {
                    board.DisplayBoard();
                    Console.WriteLine($"{currentPlayer.Name} venceu!");
                    break;
                }

                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
        }
    }
}
