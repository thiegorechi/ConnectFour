using System;

namespace ConnectFour
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(char symbol, string name) : base(symbol, name)
        {
        }

        public override int GetMove()
        {
            int move;
            do
            {
                Console.WriteLine($"{Name} ({Symbol}), enter your move (1-7): ");
                string? input = Console.ReadLine();
                move = string.IsNullOrEmpty(input) ? -1 : int.Parse(input) - 1;
            } while (move < 0 || move >= 7);
            return move;
        }
    }
}
