using System;

namespace ConnectFour
{
    public class ComputerPlayer : Player
    {
        private Random random;

        public ComputerPlayer(char symbol, string name) : base(symbol, name)
        {
            random = new Random();
        }

        public override int GetMove()
        {
            return random.Next(0, 7);
        }
    }
}
