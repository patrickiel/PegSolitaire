using System;

namespace PegSolitaire;

public class Move
{
    public Move(Coordinates start, ushort direction)
    {
        Direction = direction;
        Start = start;
        Middle = GetCoordinates(1);
        End = GetCoordinates(2);

        Coordinates GetCoordinates(ushort step)
            => direction switch
            {
                1 => new(start.X, (ushort)(start.Y + step)),
                2 => new((ushort)(start.X + step), start.Y),
                3 => new(start.X, (ushort)(start.Y - step)),
                4 => new((ushort)(start.X - step), start.Y),
                _ => throw new Exception(),
            };
    }

    public ushort Direction { get; }

    public Coordinates Start { get; }

    public Coordinates Middle { get; }

    public Coordinates End { get; }

    public override string ToString()
        => $"{Start}=>{End}";
}