namespace Test;

using AdventOfCode2023.Day4;

public class Day4Tests
{
    public Day4Tests()
    {
    }

    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86 6 31 17 9 48 53")]
    public void ScratchCards_ShouldParseInput_Correctly(string input)
    {
        var scratchCard = new ScratchCard(input);
        scratchCard.CardId.Should().Be(1);
        scratchCard.WinningNumbers.Should().Contain(41);
        scratchCard.WinningNumbers.Should().Contain(48);
        scratchCard.WinningNumbers.Should().Contain(83);
        scratchCard.WinningNumbers.Should().Contain(86);
        scratchCard.WinningNumbers.Should().Contain(17);

        scratchCard.Numbers.Should().Contain(83);
        scratchCard.Numbers.Should().Contain(86);
        scratchCard.Numbers.Should().Contain(6);
        scratchCard.Numbers.Should().Contain(31);
        scratchCard.Numbers.Should().Contain(17);
        scratchCard.Numbers.Should().Contain(9);
        scratchCard.Numbers.Should().Contain(48);
        scratchCard.Numbers.Should().Contain(53);
    }

    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86 6 31 17 9 48 53", 8)]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
    public void ScratchCards_ShouldCalculateScore_Correctly(string input, int expectedScore)
    {
        var scratchCard = new ScratchCard(input);
        var score = scratchCard.CalculateScore();
        score.Should().Be(expectedScore);
    }

    [Fact]
    public void ScratchCards_ShouldCalculateTotalSchratchCardsAmount_Correctly()
    {
        var scratchCards = new List<ScratchCards>()
        {
            new ScratchCards(new ScratchCard("Card 1: 41 48 83 86 17 | 83 86 6 31 17 9 48 53"), 1),
            new ScratchCards(new ScratchCard("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19"), 1),
            new ScratchCards(new ScratchCard("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1"), 1),
            new ScratchCards(new ScratchCard("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83"), 1),
            new ScratchCards(new ScratchCard("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36"), 1),
            new ScratchCards(new ScratchCard("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"), 1),
        };

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
        
        scratchCardCount.Should().Be(30);
    }
}
