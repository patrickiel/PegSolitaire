using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire;

public class Logger
{
    private readonly string filePath;
    private long numberOfFinishedGames;

    public Logger()
    {
        filePath = Path.GetTempFileName() + ".txt";
        File.WriteAllText(filePath, "Searching solutions..." + Environment.NewLine);

        new Process
        {
            StartInfo = new ProcessStartInfo(filePath)
            {
                UseShellExecute = true
            }
        }
        .Start();
    }

    public void Render(Game game)
    {
        var newGame = Game.NewGame();
        var moves = game.Moves.ToList();

        for (int i = 0; i < moves.Count; i++)
        {
            Move move = moves[i];
            newGame = newGame.PerformMove(move);

            var sb = new StringBuilder();
            sb.AppendLine($"{Environment.NewLine} {i + 1}. move: {move}");
            sb.AppendLine(" ┌─────────────────────┐");

            for (int j = Game.SizeEndY - Game.SizeStartY + 1; j >= 1; j--)
            {
                string line = string.Concat(Enumerable.Repeat("   ", Game.SizeEndX - Game.SizeStartX + 1));

                foreach (var piece in newGame.Pieces.Where(p => p.Y == j))
                {
                    line = line.Remove(3 * (piece.X - 1), 3);
                    string value = move.End.X == piece.X && move.End.Y == piece.Y
                        ? " ● "
                        : " ○ ";
                    line = line.Insert(3 * (piece.X - 1), value);
                }

                sb.AppendLine($"{j}│{line}│");
            }

            sb.AppendLine(" └─────────────────────┘");
            sb.AppendLine("   1  2  3  4  5  6  7");

            File.AppendAllText(filePath, sb.ToString());
        }
    }

    public void Print(string value)
        => File.AppendAllText(filePath, Environment.NewLine + value);

    public void WriteProgress()
    {
        numberOfFinishedGames++;

        if (numberOfFinishedGames % 100000 == 0)
        {
            Console.WriteLine($"{numberOfFinishedGames}: {Math.Round(Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds, 2)}s");
        }
    }
}
