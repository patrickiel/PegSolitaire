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

        public static void Print(Game game)
        {
            for (int i = 1; i <= Game.SizeEndY - Game.SizeStartY + 1; i++)
            {
                string line = new(' ', Game.SizeEndX - Game.SizeStartX + 1);

                foreach (var piece in game.Pieces.Where(p => p.Y == i))
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
