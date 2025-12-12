namespace solution.Day1;

public class Day1Solution : ISolution
{
    public void SolvePart1()
    {
        var startNumber = 50;
        var currentNumber = startNumber;
        var numberOfZeroes = 0;
        var input = File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day1\part1Input.txt");
        
        foreach (var instruction in input)
        {
            var operation = instruction[0];
            var clicks = int.Parse(instruction.Substring(1));
            if (operation == 'L')
            {
                currentNumber = (currentNumber - clicks) % 100;
            }
            else if (operation == 'R')
            {
                currentNumber = (currentNumber + clicks) % 100;
            }
            else
            {
                throw new Exception("Unknown operation in instruction " + operation);
            }

            if (currentNumber == 0)
            {
                numberOfZeroes++;
            }
        }
        
        Console.WriteLine("The answer is " + numberOfZeroes);
    }

    public void SolvePart2()
    {
        var startNumber = 50;
        var currentNumber = startNumber;
        var numerOfZeroes = 0;
        var input = File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2025\solution\Day1\part1Input.txt");
        
        foreach (var instruction in input)
        {
            var operation = instruction[0];
            var clicks = int.Parse(instruction.Substring(1));
            if (operation == 'L')
            {
                var distanceToZero = currentNumber - clicks;
                if (distanceToZero <= 0) //We reached 0
                {
                    if (currentNumber != 0) //If we start from 0 the 0 is already counted
                    {
                        numerOfZeroes++;
                    }
                    var fullRotations = Math.Abs(distanceToZero) / 100;
                    numerOfZeroes += fullRotations;
                }
                currentNumber = (((currentNumber - clicks) % 100) + 100) % 100; 
            }
            else if (operation == 'R')
            {
                var distanceToZero = currentNumber-100+clicks;
                if (distanceToZero >= 0) // We passed zero
                {
                    numerOfZeroes++;
                    var fullRotations = distanceToZero / 100;
                    numerOfZeroes += fullRotations;
                }
                currentNumber = (currentNumber + clicks) % 100;
            }
            else
            {
                throw new Exception("Unknown operation in instruction " + operation);
            }
        }
        
        Console.WriteLine("The answer is " + numerOfZeroes);
    }
}