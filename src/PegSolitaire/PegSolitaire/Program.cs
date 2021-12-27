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
                if (game.Pieces.Count == 1 &&
                    game.Pieces.First() == new Coordinates(4, 4))
                {
                    wonGames.Add(game);
                    Printer.PrintGame(game);
                }

                numberOfFinishedGames++;

                if (numberOfFinishedGames % 100000 == 0)
                {
                    Console.WriteLine($"{numberOfFinishedGames}: {Math.Round(Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds, 2)}s");
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
