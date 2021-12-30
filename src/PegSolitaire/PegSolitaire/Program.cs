namespace PegSolitaire;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"How many solutions do you want to find, hit [Enter] to find ALL solutions (This may take a long time! Enter a small number if you don't want to wait):");
        var isValid1 = int.TryParse(Console.ReadLine(), out int inputNumberOfSolutionsToFind);
        int? numberOfSolutionsToFind = isValid1 ? inputNumberOfSolutionsToFind : null;

        var useAsync = true; // change to false if you want to solve synchronously
        var solvedGames = useAsync 
            ? new SolverAsync(8, TimeSpan.FromSeconds(2)).GetSolutions(numberOfSolutionsToFind) 
            : SolverSync.GetSolutions();

        Console.WriteLine($"Finished, number of found solutions: {solvedGames.Count}");

        PrintSolutions(solvedGames);
    }

    private static void PrintSolutions(List<Game> solvedGames)
    {
        var printer = new Printer();

        while (true)
        {
            Console.WriteLine($"Enter a number form 1 to {solvedGames.Count} to print the desired solution:");
            var isValid2 = int.TryParse(Console.ReadLine(), out int index);

            if (isValid2 && index > 0 && index <= solvedGames.Count)
            {
                printer.Render(solvedGames[index - 1]);
            }
        }
    }
}
