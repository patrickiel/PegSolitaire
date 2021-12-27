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
        public const ushort SizeStartX = 1;
        public const ushort SizeEndX = 7;
        public const ushort SizeStartY = 1;
        public const ushort SizeEndY = 7;

        /// <summary>
        /// new game
        /// </summary>
        public Game()
            : this(GetStartLineup(), null)
        {
        }

        private Game(IEnumerable<Piece> pieces, IEnumerable<Move> moves)
        {
            Pieces = pieces.ToList();
            Moves = moves ?? Enumerable.Empty<Move>();
        }

        public ICollection<Piece> Pieces { get; }

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

            return x >= SizeStartX && y >= SizeStartY && x <= SizeEndX && y <= SizeEndY &&
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
            => Pieces.SelectMany(p => new List<Move>()
                     {
                         new Move(p, 1),
                         new Move(p, 2),
                         new Move(p, 3),
                         new Move(p, 4)
                     }
                     .Where(m => IsValidMove(m)))
                     .ToList();

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
