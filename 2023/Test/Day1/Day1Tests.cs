namespace Test;

using AdventOfCode2023.Day1;

public class Day1Tests
{
    private Day1 _day1;

    public Day1Tests()
    {
        _day1 = new Day1();
    }

    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void CalibrateV1_ShouldReturn_Correct_Value(string input, int output)
    {
        var result = _day1.CalibrateV1(input);
        result.Should().Be(output);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("1bbmmf ", 11)]
    [InlineData("eightthree ", 83)]
    [InlineData("sevenine ", 79)]
    public void CalibrateV2_ShouldReturn_Correct_Value(string input, int output)
    {
        var result = _day1.CalibrateV2(input);
        result.Should().Be(output);
    }
}
