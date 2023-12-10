namespace AdventOfCode2023.Day3;

using System;

public class Day3 
{
    public void Run()
    {
        var directory = Environment.CurrentDirectory.Split("bin");
        Part1(@$"{directory[0]}\Day3\Game3Input.txt");
        Part2(@$"{directory[0]}\Day3\Game3Input2.txt");
    }

    private void Part1(string filePath)
    {
        var schema = new List<string>();
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                schema.Add(line);
                
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        Engine engine = new Engine(schema);
        engine.CalculateTotals();
        Console.WriteLine($@"Total number found : {engine.NumberCount}");
        Console.WriteLine($@"Sum of all of numbers with an adjacent symbol : {engine.Totals}");
    }

    private void Part2(string filePath)
    {
        var schema = new List<string>();
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                schema.Add(line);
                
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        EngineV2 engine = new EngineV2(schema);
        engine.CalculateGearTotals();
        Console.WriteLine($@"Sum of all of numbers with an adjacent symbol : {engine.Totals}");
    }
}