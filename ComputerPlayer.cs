using System;

namespace ConnectFour
{
    public class ComputerPlayer : Player
    {
        private Random random;

        public ComputerPlayer(char symbol) : base(symbol)
        {
            random = new Random();
        }

        public override int GetMove()
        {
            // Escolha uma coluna aleatória para a jogada do computador
            return random.Next(0, 7);
        }
    }
}











