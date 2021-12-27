using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PegSolitaire
{
    class Program
    {
        private static long numberOfFinishedGames;
        private static HashSet<Game> wonGames;
        private static int counter = 0;

        //https://devblogs.microsoft.com/pfxteam/recursion-and-concurrency/
        static void Main(string[] args)
        {
            numberOfFinishedGames = 0;
            wonGames = new HashSet<Game>();
            Printer printer = new();

            CollectGames(new Game(), printer);
            Console.Read();
        }

        private static void CollectGames(Game game, Printer printer)
        {
            var moves = game.GetPossibleMoves();

            if (moves.Count == 0)
            {
                //finished
                numberOfFinishedGames += 1;

                if (game.Pieces.Count == 1 &&
                    game.Pieces.First() == new Coordinates(4, 4))
                {
                    wonGames.Add(game);
                    Printer.PrintGame(game);
                }

                counter++;
                if (counter == 100000)
                {
                    Debug.Print(Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds.ToString());
                }
            }
            else
            {
                //unfinished
                foreach (var move in moves)
                {
                    CollectGames(game.PerformMove(move), printer);
                }
            }
        }
    }
}
