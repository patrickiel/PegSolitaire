using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PegSolitaire;

class Program
{
    private static long numberOfFinishedGames = 0;
    private static List<Game> wonGames;

    static void Main(string[] args)
    {
        wonGames = new List<Game>();
        Logger logger = new();
        Play(Game.FirstMoveGiven(), logger);
        logger.Print("TOTAL FINISHED GAMES: " + numberOfFinishedGames);
        logger.Print("TOTAL WON GAMES: " + wonGames.Count);
        Console.Read();
    }

    private static void Play(Game startingGame, Logger logger)
    {
        WorkDivider<Game> workDivider = new(4);
        workDivider.Add(startingGame);

        while (workDivider.HasWork())
        {
            Game game = workDivider.Get();
            var moves = game.GetPossibleMoves();

            if (moves.Count == 0)
            {
                //finished
                numberOfFinishedGames++;

                if (game.Pieces.Count == 1 &&
                    game.Pieces.First() == new Piece(4, 4))
                {
                    wonGames.Add(game);
                    logger.Print($"Game won after {GetTotalSeconds()}, game number {numberOfFinishedGames}, {game}");
#if DEBUG
                        logger.Render(game);
#endif
                }

                if (numberOfFinishedGames % 100000 == 0)
                {
                    logger.Print($"{numberOfFinishedGames}: {GetTotalSeconds()}");
                }
            }
            else
            {
                //unfinished
                foreach (var move in moves)
                {
                    workDivider.Add(game.PerformMove(move));
                }
            }
        }
    }

    private static string GetTotalSeconds()
    {
        int numberOfDigits = 2;
        return $"{Math.Round(Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds, numberOfDigits).ToString($"0.{new string('0', numberOfDigits)}")}s";
    }
}
