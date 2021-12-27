using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire
{
    public class Printer
    {
        public Printer()
        {
        }

        public static void Print(Game board)
        {
            for (int i = 1; i <= board.SizeY.End - board.SizeY.Start + 1; i++)
            {
                string line = new(' ', board.SizeX.End - board.SizeX.Start + 1);

                foreach (var piece in board.Pieces.Where(p => p.Y == i))
                {
                    line = line.Remove(piece.X - 1, 1);
                    line = line.Insert(piece.X - 1, "O");
                }

                Console.WriteLine(line);
            }
        }

        public static void Print(IEnumerable<Move> moves)
        {
            var movesList = moves.ToList();

            for (int i = 0; i < movesList.Count; i++)
            {
                Move move = movesList[i];
                Console.WriteLine($"{i + 1}: {move}");
            }
        }

        public static void PrintGame(Game game)
        {
            Console.WriteLine($"{game}");
        }
    }
}
