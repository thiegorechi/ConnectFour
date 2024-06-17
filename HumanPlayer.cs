using System;

namespace ConnectFour
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(char symbol) : base(symbol)
        {
        }

        public override int GetMove()
        {
            Console.WriteLine($"Player {Symbol}, enter your move (1-7): ");
            return int.Parse(Console.ReadLine()) - 1;
        }
    }
}
