namespace PegSolitaire
{
    public static class SolverSync
    {
        public static List<Game> GetSolutions()
        {
            Console.WriteLine($"ThreadId:{Environment.CurrentManagedThreadId} Start...");

            var stopwatch = new Stopwatch();
            var wonGames = new Stack<Game>();
            var ongoingGames = new Stack<Game>();
            int finishedGames = 0;
            ongoingGames.Push(Game.FirstMoveGiven());

            stopwatch.Start();

            while (ongoingGames.Any())
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

                if (stopwatch.ElapsedMilliseconds % 1000 == 0)
                {
                    Console.WriteLine($"Finished games per second: {finishedGames / (stopwatch.ElapsedMilliseconds / 1000)}, total: {finishedGames}, solved: {wonGames.Count}");
                }
            }

            return wonGames.ToList();
        }
    }
}
