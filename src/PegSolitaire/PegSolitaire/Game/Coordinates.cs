namespace PegSolitaire;

public record Coordinates
{
    public Coordinates(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }

    public ushort Y { get; }

    public override string ToString()
        => $"({X},{Y})";
}
