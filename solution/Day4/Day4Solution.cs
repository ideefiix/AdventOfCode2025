using System.Diagnostics;

namespace solution.Day4;

public class Day4Solution : ISolution
{
    public void SolvePart1()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var rows =
            File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day4\part1&2Input");
        List<(int x, int y)> toiletPapperCoordinates = new List<(int x, int y)>();

        for (int y = 0; y < rows.Length; y++)
        {
            for (int x = 0; x < rows[y].Length; x++)
            {
                if (rows[y][x] == '@')
                {
                    toiletPapperCoordinates.Add(new ValueTuple<int, int>(x, y));
                }
            }
        }

        var answer = toiletPapperCoordinates.Count(coord => 
            toiletPapperCoordinates.Count(otherCoord => Math.Abs(coord.x - otherCoord.x) < 2 &&
            Math.Abs(coord.y - otherCoord.y) < 2) < 5);
        time.Stop();
        Console.WriteLine("Answer: Number of pickable toiletrolls are: " + answer);
        Console.WriteLine("Execution time was " + time.Elapsed);
    }

    public void SolvePart2()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var rows =
            File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day4\part1&2Input");
        List<(int x, int y)> toiletPapperCoordinates = new List<(int x, int y)>();

        for (int y = 0; y < rows.Length; y++)
        {
            for (int x = 0; x < rows[y].Length; x++)
            {
                if (rows[y][x] == '@')
                {
                    toiletPapperCoordinates.Add(new ValueTuple<int, int>(x, y));
                }
            }
        }

        var deletedToiletRolls = 0;
        
        while (true)
        {
            var coordsToRemove = toiletPapperCoordinates.Where(coord =>
                toiletPapperCoordinates.Count(otherCoord => Math.Abs(coord.x - otherCoord.x) < 2 &&
                                                            Math.Abs(coord.y - otherCoord.y) < 2) < 5).ToList();
            if (!coordsToRemove.Any())
            {
                break;
            }
            
            deletedToiletRolls += coordsToRemove.Count;
            //Console.WriteLine("Debug: Removed " + coordsToRemove.Count + " number of paperolls!");
            toiletPapperCoordinates.RemoveAll(coord => coordsToRemove.Contains(coord));
        }
        
        time.Stop();
        Console.WriteLine("Answer: Number of removable toiletrolls are: " + deletedToiletRolls);
        Console.WriteLine("Execution time was " + time.Elapsed);
    }
}