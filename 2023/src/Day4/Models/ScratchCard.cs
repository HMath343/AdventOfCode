namespace AdventOfCode2023.Day4;

using System.Text.RegularExpressions;

public class ScratchCard
{
    private Regex RxNumber = new Regex(@"(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public int CardId { get; set; }
    public HashSet<int> WinningNumbers { get; set; } = new HashSet<int>();
    public List<int> Numbers { get; set; } = new List<int>();

    public ScratchCard(string input)
    {
        var input1 = input.Split(":");

        Match match = RxNumber.Match(input1.First());
        if(!int.TryParse(match.Value, out var cardId))
        {
            throw new Exception("Parsing exception");
        }
        CardId = cardId;

        var numberInputs = input1[1].Split("|");
        foreach(Match winningNumberMatch in RxNumber.Matches(numberInputs[0]))
        {
            if(int.TryParse(winningNumberMatch.Value, out var winningNumber))
            {
                if(WinningNumbers.Contains(winningNumber))
                {
                    throw new Exception("Convert Hashset to list ?");
                }

                WinningNumbers.Add(winningNumber);
            }
            
        }

        foreach(Match numberMatch in RxNumber.Matches(numberInputs[1]))
        {
            if(int.TryParse(numberMatch.Value, out var number))
            {
                Numbers.Add(number);
            }
        }
    }

    public int CalculateScore()
    {
        var score = 0;

        foreach(var number in Numbers)
        {
            if(WinningNumbers.Contains(number))
            {
                score = score == 0 ? 1 : score * 2;
            }
        }
        return score;
    }

    public int GetMatchingCount()
    {
        var match = 0;
        foreach(var number in Numbers)
        {
            if(WinningNumbers.Contains(number))
            {
                match++;
            }
        }

        return match;
    }
}