namespace AdventOfCode2023.Day4;

using System.Text.RegularExpressions;

public class ScratchCards
{
    public ScratchCard Card { get; set; }
    public int Count { get; set; }

    public ScratchCards(ScratchCard card, int count)
    {
        Card = card;
        Count = count;
    }

    public void IncrementCount(int amount)
    {
        Count = Count + amount;
    }
}