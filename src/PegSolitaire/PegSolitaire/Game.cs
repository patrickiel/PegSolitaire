using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire
{
    public class Game
    {
        /// <summary>
        /// new game
        /// </summary>
        public Game()
            : this(GetStartLineup(), null)
        {
        }

        private Game(IEnumerable<Piece> pieces, IEnumerable<Move> moves)
        {
            Pieces = pieces.ToImmutableList();
            SizeX = (1, 7);
            SizeY = (1, 7);
            Moves = moves == null ? new List<Move>().ToImmutableList() : moves.ToImmutableList();
        }

        public ICollection<Piece> Pieces { get; }

        public (ushort Start, ushort End) SizeX { get; }

        public (ushort Start, ushort End) SizeY { get; }

        public IEnumerable<Move> Moves { get; }

        public static IEnumerable<Piece> GetStartLineup()
            => new List<Piece>() {
                new Piece(3,1),
                new Piece(4,1),
                new Piece(5,1),
                new Piece(3,2),
                new Piece(4,2),
                new Piece(5,2),
                new Piece(1,3),
                new Piece(2,3),
                new Piece(3,3),
                new Piece(4,3),
                new Piece(5,3),
                new Piece(6,3),
                new Piece(7,3),
                new Piece(1,4),
                new Piece(2,4),
                new Piece(3,4),
                new Piece(5,4),
                new Piece(6,4),
                new Piece(7,4),
                new Piece(1,5),
                new Piece(2,5),
                new Piece(3,5),
                new Piece(4,5),
                new Piece(5,5),
                new Piece(6,5),
                new Piece(7,5),
                new Piece(3,6),
                new Piece(4,6),
                new Piece(5,6),
                new Piece(3,7),
                new Piece(4,7),
                new Piece(5,7)
             };

        public bool IsSlot(Coordinates coordinates)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            return x >= SizeX.Start && y >= SizeX.Start && x <= SizeX.End && y <= SizeX.End &&
                   (x >= 3 && x <= 5 || y >= 3 && y <= 5);
        }

        public bool IsValidMove(Move move)
            => IsSlot(move.End) &&
               !PieceIsPresent(move.End) &&
               IsSlot(move.Middle) &&
               PieceIsPresent(move.Middle);

        public bool PieceIsPresent(Coordinates coordinates)
            => Pieces.Any(p => p.X == coordinates.X &&
                               p.Y == coordinates.Y);

        public ICollection<Move> GetPossibleMoves()
        {
            var result = new List<Move>();

            foreach (var piece in Pieces)
            {
                var moves = new List<Move>()
                {
                    new Move(piece, 1),
                    new Move(piece, 2),
                    new Move(piece, 3),
                    new Move(piece, 4)
                }
                .Where(m => IsValidMove(m));

                result.AddRange(moves);
            }

            return result;
        }

        public Game PerformMove(Move move)
        {
            var pieces = Pieces.ToList();
            pieces.Remove(new Piece(move.Start));
            pieces.Remove(new Piece(move.Middle));
            pieces.Add(new Piece(move.End));

            var moves = Moves.ToList();
            moves.Add(move);
            return new Game(pieces, moves);
        }

        public override string ToString()
            => $"pieces: {string.Join(" ", Pieces.Select(p => p.ToString()))}, moves: {string.Join(" ", Moves.Select(p => p.ToString()))}";
    }
}
