namespace AdventOfCode2023.Day2;

using System;

public class Day2 
{
    public void Run(int blueCubes, int redCubes, int greenCubes)
    {
        var directory = Environment.CurrentDirectory.Split("bin");
        Part1(@$"{directory[0]}\Day2\Game2Input.txt", blueCubes, redCubes, greenCubes);
        Part2(@$"{directory[0]}\Day2\Game2Input.txt");
    }

    private void Part1(string filePath, int blueCubes, int redCubes, int greenCubes)
    {
        var result = 0;
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                result += CanBePlayed(line, blueCubes, redCubes, greenCubes) ?? 0;
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        Console.WriteLine($@"Sum of all of game that can be played {result}");
        Console.WriteLine($@"BlueCubes : {blueCubes}");
        Console.WriteLine($@"RedCubes : {redCubes}");
        Console.WriteLine($@"GreenCubes : {greenCubes}");
    }

    private void Part2(string filePath)
    {
        var result = 0;
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                var game = new Game(line);
                Console.WriteLine($@"-----------------------------------");
                Console.WriteLine($@"Game power {game.Power} for {line} ");
                Console.WriteLine($@"Game min blue {game.BlueCountMin}");
                Console.WriteLine($@"Game min red {game.RedCountMin}");
                Console.WriteLine($@"Game min green {game.GreenCountMin}");
                result += game.Power;
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        Console.WriteLine($@"Sum of all of game that can be played {result}");

    }

    internal int? CanBePlayed(string gameCSV, int blueCubes, int redCubes, int greenCubes)
    {
        var game = new Game(gameCSV);
        if (game.CanBePlayed(blueCubes, redCubes, greenCubes))
        {
            Console.WriteLine($@"Game {game.Id} can be played : {gameCSV}");
            return game.Id;
        }

        Console.WriteLine($@"Game {game.Id} cannot be played : {gameCSV}");
        return 0;
    }
}