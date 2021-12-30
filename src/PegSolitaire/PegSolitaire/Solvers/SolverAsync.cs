namespace PegSolitaire;

public class SolverAsync
{
    private readonly int maximalNumberOfParallelTasks;
    private readonly TimeSpan maximalTaskRunningTime;
    private readonly Stopwatch stopwatch;

    private readonly Stack<Game> ongoingGames;
    private readonly Stack<Game> wonGames;

    private List<Task<(List<Game> OngoingGames, List<Game> WonGames, int FinishedGames)>> tasks;
    private long finishedGames;

    public SolverAsync(int maximalNumberOfParallelTasks, TimeSpan maximalTaskRunningTime)
    {
        this.maximalNumberOfParallelTasks = maximalNumberOfParallelTasks;
        this.maximalTaskRunningTime = maximalTaskRunningTime;

        ongoingGames = new Stack<Game>(maximalNumberOfParallelTasks);
        ongoingGames.Push(Game.FirstMoveGiven());
        wonGames = new();

        stopwatch = new();
        stopwatch.Start();

        GenerateTasks();
    }

    public List<Game> GetSolutions(int? numberOfSolutionsToFind = null)
    {
        while (tasks.Any() && (numberOfSolutionsToFind == null || wonGames.Count <= (int)numberOfSolutionsToFind))
        {
            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WhenAll(tasks.ToArray());
            var results = tasks.Select(t => t.Result).ToList();

            foreach (var item in results.SelectMany(r => r.OngoingGames))
            {
                ongoingGames.Push(item);
            }

            foreach (var item in results.SelectMany(r => r.WonGames))
            {
                wonGames.Push(item);
            }

            finishedGames += results.Sum(r => r.FinishedGames);

            GenerateTasks();

            Console.WriteLine($"Finished games per second: {finishedGames / (stopwatch.ElapsedMilliseconds / 1000)}, total: {finishedGames}, ongoing {ongoingGames.Count}, solved: {wonGames.Count}");
        }

        return wonGames.ToList();
    }

    private void GenerateTasks()
    {
        tasks = new();

        for (int i = 0; i < maximalNumberOfParallelTasks; i++)
        {
            if (ongoingGames.TryPop(out Game game))
            {
                tasks.Add(new Task<(List<Game> OngoingGames, List<Game> WonGames, int FinishedGames)>(() => Play(game)));
            }
            else
            {
                break;
            }
        }
    }

    private (List<Game> OngoingGames, List<Game> WonGames, int finishedGames) Play(Game initialGame)
    {
        var stopwatch = new Stopwatch();
        var wonGames = new Stack<Game>();
        var ongoingGames = new Stack<Game>();
        int finishedGames = 0;
        ongoingGames.Push(initialGame);

        stopwatch.Start();

        while (ongoingGames.Count >=1 && stopwatch.Elapsed < maximalTaskRunningTime)
        {
            var game = ongoingGames.Pop();
            var moves = game.GetPossibleMoves();

            if (moves.Count == 0)
            {
                //finished
                if (game.Pieces.Count == 1 &&
                    game.Pieces.First() == new Piece(4, 4))
                {
                    wonGames.Push(game);
                }

                finishedGames++;
            }
            else
            {
                //unfinished
                foreach (var move in moves)
                {
                    ongoingGames.Push(game.PerformMove(move));
                }
            }
        }

        return (ongoingGames.ToList(), wonGames.ToList(), finishedGames);
    }
}