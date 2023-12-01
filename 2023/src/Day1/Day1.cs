namespace AdventOfCode2023.Day1;

using System;
using System.Text.RegularExpressions;

public class Day1 
{
    public Day1()
    {

    }

    public void Run()
    {
        Part1(@"C:\Users\hugom\repo\AdventOfCode\2023\src\Day1\Part1Input.txt");
        Part2(@"C:\Users\hugom\repo\AdventOfCode\2023\src\Day1\Part2Input.txt");
    }

    private void Part1(string filePath)
    {
        //Read files
        using(var sr = new StreamReader(filePath))
        {
            //Read the first line of text
            var line = sr.ReadLine();
            var result = 0;
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                result += CalibrateV1(line) ?? 0;
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            Console.WriteLine($"Sum of all of the calibration values : {result}");
        }
    }

    /// <summary>
    /// Calibrate a value by 
    /// </summary>
    /// <param name="value">Value to calibrate</param>
    /// <returns>Calibrated value or null</returns>
    public int? CalibrateV1(string value)
    {
        Regex rx = new Regex(@"[0-9]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(value);

        return int.Parse($"{matches.First().Value + matches.Last().Value}");
    }

    private void Part2(string filePath)
    {
        //Read files
        using(var sr = new StreamReader(filePath))
        {
            //Read the first line of text
            var line = sr.ReadLine();
            var result = 0;
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                result += CalibrateV2(line) ?? 0;
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            Console.WriteLine($"Sum of all of the calibration values : {result}");
        }
    }

    public int? CalibrateV2(string line)
    {
        Regex rx = new Regex(@"(?<=(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|(\d{1}))", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(line);

        var a = matches.First().GetMatchedValue().ToInt();
        var b = matches.Last().GetMatchedValue().ToInt();
        return int.Parse($"{a}{b}");
    }


}