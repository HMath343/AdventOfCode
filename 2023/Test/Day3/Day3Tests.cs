namespace Test;

using AdventOfCode2023.Day3;

public class Day3Tests
{
    public Day3Tests()
    {

    }

    [Theory]
    [InlineData(@"467..114..|
                  ...*......|
                  ..35..633.|
                  ......#...|
                  617*......|
                  .....+.58.|
                  ..592.....|
                  ......755.|
                  ...$.*....|
                  .664.598..")]
    public void EngineV1_Should_Calculate_Totals_Correctly(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new Engine(test.Split("|"));
        engine.CalculateTotals();

        engine.Totals.Should().Be(4361);
    }

    [Theory]
    [InlineData(@"..........|
                  ....5.....|
                  .....*....")]
    public void EngineV1_Should_Calculate_Totals_Correctly_WrongCase1(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new Engine(test.Split("|"));
        engine.CalculateTotals();

        engine.Totals.Should().Be(5);
    }

    [Theory]
    [InlineData(@"..........|
                  ...45*46..|
                  ..........")]
    public void EngineV2_Should_Get_Left_Right_Gear(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(45*46);
    }

    [Theory]
    [InlineData(@"..123.....|
                  .....*46..|
                  ..........")]
    public void EngineV2_Should_Get_Top_Gear(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(123*46);
    }

    [Theory]
    [InlineData(@"..123.46..|
                  .....*....|
                  ..........")]
    public void EngineV2_Should_Get_Top_Gear2(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(123*46);
    }

    [Theory]
    [InlineData(@"....123...|
                  ...46*....|
                  ..........")]
    public void EngineV2_Should_Get_Top_Gear3(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(123*46);
    }

    [Theory]
    [InlineData(@"..........|
                  .....*46..|
                  .....123..")]
    public void EngineV2_Should_Get_Bottom_Gear(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(123*46);
    }

    [Theory]
    [InlineData(@"..........|
                  .....*....|
                  ..123.46..")]
    public void EngineV2_Should_Get_Bottom_Gear2(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(123*46);
    }

    [Theory]
    [InlineData(@"..........|
                  ...46*....|
                  ....123...")]
    public void EngineV2_Should_Get_Bottom_Gear3(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(123*46);
    }

    [Theory]
    [InlineData(@"...35.....|
                  ...*......|
                  ..552.171.")]
    public void EngineV2_Should_Wrong_Case1(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(35*552);
    }

    [Theory]
    [InlineData(@"..552.171.|
                  ...*......|
                  ...35.....")]
    public void EngineV2_Should_Wrong_Case2(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(35*552);
    }

    [Theory]
    [InlineData(@"467..114..|
                  ...*......|
                  ..35..633.|
                  ......#...|
                  617*......|
                  .....+.58.|
                  ..592.....|
                  ......755.|
                  ...$.*....|
                  .664.598..")]
    public void EngineV2_Should_Calculate_Gear_Totals_Correctly(string schematic)
    {
        var test = schematic.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
        var engine = new EngineV2(test.Split("|"));
        engine.CalculateGearTotals();

        engine.Totals.Should().Be(467835);
    }

}
