using System;

public class HumanPlayer : Player
{
    public HumanPlayer(char symbol, string name) : base(symbol, name) { }

    public override int GetMove()
    {
        Console.Write($"{Name} ({Symbol}), escolha uma coluna (0-6): ");
        int move;
        while (!int.TryParse(Console.ReadLine(), out move) || move < 0 || move > 6)
        {
            Console.Write("Entrada inválida. Escolha uma coluna (0-6): ");
        }
        return move;
    }
}
