namespace PegSolitaire;

public record Piece : Coordinates
{
    public Piece(ushort x, ushort y)
        : base(x, y)
    {
    }

    public Piece(Coordinates coordinates)
        : base(coordinates.X, coordinates.Y)
    {
    }

    public override string ToString()
        => $"({X},{Y})";
}