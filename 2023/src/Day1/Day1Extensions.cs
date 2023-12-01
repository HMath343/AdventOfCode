namespace AdventOfCode2023.Day1;

using System.Text.RegularExpressions;


public static class Day1Extensions 
{
    private static Dictionary<string, int> stringToInt = new Dictionary<string, int>()
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
                
    };

    public static int? ToInt(this string value)
    {
        if(stringToInt.ContainsKey(value))
        {
            stringToInt.TryGetValue(value, out var convertedValue);
            return convertedValue;
        }
        int.TryParse(value, out var result);
        return result;
    }
    
    public static string GetMatchedValue(this Match match)
    {
        if (!string.IsNullOrEmpty(match.Value))
        {
            return match.Value;
        }

        var result = match.Groups.Values.Where(x => !string.IsNullOrEmpty(x.Value)).FirstOrDefault();

        return result?.Value ?? string.Empty;
    }


}