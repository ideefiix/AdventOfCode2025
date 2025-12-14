using System.Diagnostics;

namespace solution.Day3;

public class Day3Solution : ISolution
{
    public void SolvePart1()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var banks =
            File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day3\part1&2Input")
                .Select(line => line.Chunk(1))
                .Select(line => line.Select(c => int.Parse(c)).ToArray());
        
        Int64 totalJoltage = 0;
        
        foreach (var bank in banks)
        {
            totalJoltage += FindMaxJoltageInBank(bank, 2);
        }
        
        time.Stop();
        Console.WriteLine("Answer: The totaljoltage in the banks are " + totalJoltage);
        Console.WriteLine("ExecutionTime: " + time.Elapsed);
    }
    
    public void SolvePart2()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var banks =
            File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day3\part1&2Input")
                .Select(line => line.Chunk(1))
                .Select(line => line.Select(c => int.Parse(c)).ToArray());
        Int64 totalJoltage = 0;
        
        foreach (var bank in banks)
        {
            totalJoltage += FindMaxJoltageInBank(bank, 12);
        }
        time.Stop();
        Console.WriteLine("Answer: The totaljoltage in the banks are " + totalJoltage);
        Console.WriteLine("ExecutionTime: " + time.Elapsed);
    }
    
    private Int64 FindMaxJoltageInBank(int[] bank, int numberOfBatteriesToInclude)
    {
        string maxJoltageInBank = "";
        var previousHighestJoltIndex = 0;

        for (int i = numberOfBatteriesToInclude; i > 0; i--)
        {
            var biggestJoltage = 0;
            var nextBatteryStartPosition = 0;

            for (int j = previousHighestJoltIndex; j < bank.Length -(i-1); j++)
            {
                if (bank[j] > biggestJoltage)
                {
                    biggestJoltage = bank[j];
                    nextBatteryStartPosition = j+1;
                }
            }

            maxJoltageInBank += biggestJoltage;
            previousHighestJoltIndex = nextBatteryStartPosition;
        }

        //Console.WriteLine("Debug: Adding joltage " + maxJoltageInBank);
        return long.Parse(maxJoltageInBank);
    }
}