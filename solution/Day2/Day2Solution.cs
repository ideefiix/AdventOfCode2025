using System.Diagnostics;

namespace solution.Day2;

public class Day2Solution : ISolution
{
    public void SolvePart1()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var ranges =
            File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day2\part1Input")
                .First().Split(',');

        Int64 sumOfInvalidIds = 0;

        foreach (var range in ranges)
        {
            var minString = range.Split("-")[0];
            var maxString = range.Split("-")[1];
            var min = Int64.Parse(minString);
            var max = Int64.Parse(maxString);

            for (Int64 i = min; i < max + 1; i++)
            {
                var currNum = i.ToString();
                if (currNum.Length % 2 == 1)
                {
                    continue;
                }

                var firstHalf = currNum.Substring(0, currNum.Length / 2);
                var secondHalf = currNum.Substring(currNum.Length / 2);
                if (firstHalf == secondHalf)
                {
                    sumOfInvalidIds += i;
                }
            }
        }

        time.Stop();
        Console.WriteLine("Answer is " + sumOfInvalidIds);
        Console.WriteLine("Execution time was " + time.Elapsed);
    }

    public void SolvePart2()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var ranges =
            File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day2\part2Input")
                .First().Split(',');

        Int64 sumOfInvalidIds = 0;

        foreach (var range in ranges)
        {
            var minString = range.Split("-")[0];
            var maxString = range.Split("-")[1];
            var min = Int64.Parse(minString);
            var max = Int64.Parse(maxString);

            for (Int64 i = min; i < max + 1; i++)
            {
                var currNum = i.ToString();
                
                for (int j = 1; j <= (currNum.Length/2); j++)
                {
                    var stringChunks = currNum.Chunk(j).Select(charArray => new String(charArray));
                    if (stringChunks.All(s => s == stringChunks.First()))
                    {
                        sumOfInvalidIds += i;
                        break;
                    }
                }
            }
        }

        time.Stop();
        Console.WriteLine("Answer is " + sumOfInvalidIds);
        Console.WriteLine("Execution time was " + time.Elapsed);
    }
}