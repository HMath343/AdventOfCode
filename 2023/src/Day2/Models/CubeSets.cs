namespace AdventOfCode2023.Day2;

using System.Text.RegularExpressions;

public class CubeSets
{
    //(\d\sblue)
    public int BlueCount { get; set; }
    //(\d\sred)
    public int RedCount { get; set; }
    //(\d\sgreen)
    public int GreenCount { get; set; }

    public CubeSets(string cubeSets)
    {
        BlueCount = CalculateBlueCount(cubeSets);
        RedCount = CalculateRedCount(cubeSets);
        GreenCount = CalculateGreenCount(cubeSets);
    }

    private int CalculateBlueCount(string cubeSets)
    {
        Regex rx = new Regex(@"(\d+\sblue)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(cubeSets);
        if(matches.Count == 1)
        {
            if(!int.TryParse(matches.First().Value.Split(" ").First(), out var blueCount))
            {
                throw new Exception($"Parsing issue to calcule blue balls count {matches.First().Value}");
            }
            return blueCount;
        }
        return 0;
    }

    private int CalculateRedCount(string cubeSets)
    {
        Regex rx = new Regex(@"(\d+\sred)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(cubeSets);
        if(matches.Count == 1)
        {
            if(!int.TryParse(matches.First().Value.Split(" ").First(), out var redCount))
            {
                throw new Exception($"Parsing issue to calcule blue balls count {matches.First().Value}");
            }
            return redCount;
        }
        return 0;
    }

    private int CalculateGreenCount(string cubeSets)
    {
        Regex rx = new Regex(@"(\d+\sgreen)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        MatchCollection matches = rx.Matches(cubeSets);
        if(matches.Count == 1)
        {
            if(!int.TryParse(matches.First().Value.Split(" ").First(), out var greenCount))
            {
                throw new Exception($"Parsing issue to calcule blue balls count {matches.First().Value}");
            }
            return greenCount;
        }
        return 0;
    }

    public bool CanBePlayed(int redCount, int blueCount, int greenCount)
    {
        if(redCount >= RedCount && blueCount >= BlueCount && greenCount >= GreenCount)
        {
            return true;
        }

        return false;
    }
}