using System;

namespace PegSolitaire
{
    public class Move
    {
        public Move(Piece piece, ushort direction)
        {
            Piece = piece;
            Direction = direction;
            Start = piece;
            Middle = GetCoordinates(1);
            End = GetCoordinates(2);

            Coordinates GetCoordinates(ushort step)
            {
                var x = Piece.X;
                var y = Piece.Y;

                return direction switch
                {
                    1 => new(x, (ushort)(y + step)),
                    2 => new((ushort)(x + step), y),
                    3 => new(x, (ushort)(y - step)),
                    4 => new((ushort)(x - step), y),
                    _ => throw new Exception(),
                };
            }
        }

        public Piece Piece { get; }

        public ushort Direction { get; }

        public Coordinates Start { get; }

        public Coordinates Middle { get; }

        public Coordinates End { get; }

        public override string ToString()
            => $"{Start}=>{End}";
    }
}