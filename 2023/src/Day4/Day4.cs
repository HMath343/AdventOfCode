namespace AdventOfCode2023.Day4;

using System;

public class Day4 
{
    public void Run()
    {
        var directory = Environment.CurrentDirectory.Split("bin");
        Part1(@$"{directory[0]}\Day4\Game4Input.txt");
        Part2(@$"{directory[0]}\Day4\Game4Input2.txt");
    }

    private void Part1(string filePath)
    {
        var result = 0;
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                var scratchCard = new ScratchCard(line);
                result += scratchCard.CalculateScore();
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        Console.WriteLine($@"Sum of scratch cards pile : {result}");
    }

    private void Part2(string filePath)
    {
        var scratchCards = new List<ScratchCards>();
        using(var sr = new StreamReader(filePath))
        {
            var line = sr.ReadLine();

            while (line != null)
            {
                var scratchCard = new ScratchCard(line);
                scratchCards.Add(new ScratchCards(scratchCard, 1));
                line = sr.ReadLine();
            }
            sr.Close();   
        }

        var pos = 1;
        foreach(var scratchCard in scratchCards)
        {
            var amount = scratchCard.Card.GetMatchingCount();
            for(int i = 0; i < amount; i++)
            {
                var element = scratchCards[pos + i];
                element.IncrementCount(scratchCard.Count);
            }     
            pos++;
        }

        var scratchCardCount = 0;
        foreach(var scratchCard in scratchCards)
        {
            scratchCardCount += scratchCard.Count;
        }
        
        Console.WriteLine($@"Sum of scratch cards pile : {scratchCardCount}");
    }
}