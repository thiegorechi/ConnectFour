public abstract class Player
{
    public char Symbol { get; set; }
    public string Name { get; set; }

    public Player(char symbol, string name)
    {
        Symbol = symbol;
        Name = name;
    }

    public abstract int GetMove();
}
