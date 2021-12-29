using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitaire;

internal class WorkDivider
{
    private static readonly Random random = new();

    private readonly int numberOfThreads;
    private readonly Stack<Game> work;
    private readonly List<Game> wonGames;
    private readonly List<Task> tasks;

    public WorkDivider(int numberOfThreads)
    {
        this.numberOfThreads = numberOfThreads;
        tasks = new List<Task>(numberOfThreads);

        work = new Stack<Game>();
        work.Push(Game.NewGame());
    }

    public bool HasWork()
        => work.Count > 0;

    public void Do()
    {
        Task getTask() => new(() => DoWork());

        var tasks = new List<Task>() 
        {
        getTask(),
        getTask(),
        getTask(),
        getTask()
        };

        Parallel.ForEach(tasks, t => t.Start());
    }

    public void DoWork()
    {
        while (HasWork())
        {
            var game = work.Pop();
            var moves = game.GetPossibleMoves();

            if (moves.Count == 0)
            {
                //finished
                if (game.Pieces.Count == 1 &&
                    game.Pieces.First() == new Piece(4, 4))
                {
                    wonGames.Add(game);
                }
            }
            else
            {
                //unfinished
                foreach (var move in moves)
                {
                    work.Push(game.PerformMove(move));
                }
            }
        }
    }
}

