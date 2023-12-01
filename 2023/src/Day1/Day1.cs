namespace AdventOfCode2023.Day1;

using System;
using System.Text.RegularExpressions;

public class Day1 
{
    public void Run()
    {
        var directory = Environment.CurrentDirectory.Split("bin");
        Part1(@$"{directory[0]}\Day1\Part1Input.txt");
        Part2(@$"{directory[0]}\Day1\Part2Input.txt");
    }

    private void Part1(string filePath)
    {
        var result = 0;
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                result += CalibrateV1(line) ?? 0;
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        Console.WriteLine($"Sum of all of the calibration values : {result}");
    }

    internal int? CalibrateV1(string value)
    {
        Regex rx = new Regex(@"[0-9]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(value);

        return int.Parse($"{matches.First().Value + matches.Last().Value}");
    }

    private void Part2(string filePath)
    {
        var result = 0;
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();
           
            while (line != null)
            {
                result += CalibrateV2(line) ?? 0;
                line = sr.ReadLine();
            }
            sr.Close();
        }

        Console.WriteLine($"Sum of all of the calibration values : {result}");
    }

    internal int? CalibrateV2(string line)
    {
        Regex rx = new Regex(@"(?<=(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|(\d{1}))", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(line);

        return int.Parse($"{matches.First().GetMatchedValue().ToInt()}{matches.Last().GetMatchedValue().ToInt()}");
    }
}