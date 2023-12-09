namespace Test;

using AdventOfCode2023.Day2;

public class Day2Tests
{

    public Day2Tests()
    {
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 14, 12, 13)]
    public void Game1_Can_Be_Played(string gameCSV, int blueCubes,  int redCubes, int greenCubes)
    {
        var game = new Game(gameCSV);
        game.Id.Should().Be(1);

        game.CubeSets.Count().Should().Be(3);

        var cubeSet1 = game.CubeSets.First();
        cubeSet1.BlueCount.Should().Be(3);
        cubeSet1.RedCount.Should().Be(4);
        cubeSet1.GreenCount.Should().Be(0);

        var cubeSet2 = game.CubeSets.ElementAt(1);
        cubeSet2.BlueCount.Should().Be(6);
        cubeSet2.RedCount.Should().Be(1);
        cubeSet2.GreenCount.Should().Be(2);

        var cubeSet3 = game.CubeSets.Last();
        cubeSet3.BlueCount.Should().Be(0);
        cubeSet3.RedCount.Should().Be(0);
        cubeSet3.GreenCount.Should().Be(2);

        var couldBePlayed = game.CanBePlayed(blueCubes, redCubes, greenCubes);
        couldBePlayed.Should().BeTrue();

        game.BlueCountMin.Should().Be(6);
        game.RedCountMin.Should().Be(4);
        game.GreenCountMin.Should().Be(2);

        game.Power.Should().Be(48);
    }

    [Theory]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 14, 12, 13)]
    public void Game2_Can_Be_Played(string gameCSV, int blueCubes,  int redCubes, int greenCubes)
    {
        var game = new Game(gameCSV);
        game.Id.Should().Be(2);

        game.CubeSets.Count().Should().Be(3);

        var cubeSet1 = game.CubeSets.First();
        cubeSet1.BlueCount.Should().Be(1);
        cubeSet1.RedCount.Should().Be(0);
        cubeSet1.GreenCount.Should().Be(2);

        var cubeSet2 = game.CubeSets.ElementAt(1);
        cubeSet2.BlueCount.Should().Be(4);
        cubeSet2.RedCount.Should().Be(1);
        cubeSet2.GreenCount.Should().Be(3);

        var cubeSet3 = game.CubeSets.Last();
        cubeSet3.BlueCount.Should().Be(1);
        cubeSet3.RedCount.Should().Be(0);
        cubeSet3.GreenCount.Should().Be(1);

        var canBePlayed = game.CanBePlayed(blueCubes, redCubes, greenCubes);
        canBePlayed.Should().BeTrue();

        game.BlueCountMin.Should().Be(4);
        game.RedCountMin.Should().Be(1);
        game.GreenCountMin.Should().Be(3);

        game.Power.Should().Be(12);

    }

    [Theory]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 14, 12, 13)]
    public void Game3_Cannot_Be_Played(string gameCSV, int blueCubes,  int redCubes, int greenCubes)
    {
        var game = new Game(gameCSV);
        game.Id.Should().Be(3);

        game.CubeSets.Count().Should().Be(3);

        var cubeSet1 = game.CubeSets.First();
        cubeSet1.BlueCount.Should().Be(6);
        cubeSet1.RedCount.Should().Be(20);
        cubeSet1.GreenCount.Should().Be(8);

        var cubeSet2 = game.CubeSets.ElementAt(1);
        cubeSet2.BlueCount.Should().Be(5);
        cubeSet2.RedCount.Should().Be(4);
        cubeSet2.GreenCount.Should().Be(13);

        var cubeSet3 = game.CubeSets.Last();
        cubeSet3.BlueCount.Should().Be(0);
        cubeSet3.RedCount.Should().Be(1);
        cubeSet3.GreenCount.Should().Be(5);

        var canBePlayed = game.CanBePlayed(blueCubes, redCubes, greenCubes);
        canBePlayed.Should().BeFalse();

        game.BlueCountMin.Should().Be(6);
        game.RedCountMin.Should().Be(20);
        game.GreenCountMin.Should().Be(13);

        game.Power.Should().Be(1560);

    }


    [Theory]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 14, 12, 13)]
    public void Game4_Cannot_Be_Played(string gameCSV, int blueCubes,  int redCubes, int greenCubes)
    {
        var game = new Game(gameCSV);
        game.Id.Should().Be(4);

        game.CubeSets.Count().Should().Be(3);

        var cubeSet1 = game.CubeSets.First();
        cubeSet1.BlueCount.Should().Be(6);
        cubeSet1.RedCount.Should().Be(3);
        cubeSet1.GreenCount.Should().Be(1);

        var cubeSet2 = game.CubeSets.ElementAt(1);
        cubeSet2.BlueCount.Should().Be(0);
        cubeSet2.RedCount.Should().Be(6);
        cubeSet2.GreenCount.Should().Be(3);

        var cubeSet3 = game.CubeSets.Last();
        cubeSet3.BlueCount.Should().Be(15);
        cubeSet3.RedCount.Should().Be(14);
        cubeSet3.GreenCount.Should().Be(3);

        var canBePlayed = game.CanBePlayed(blueCubes, redCubes, greenCubes);
        canBePlayed.Should().BeFalse();

        game.BlueCountMin.Should().Be(15);
        game.RedCountMin.Should().Be(14);
        game.GreenCountMin.Should().Be(3);

        game.Power.Should().Be(630);

    }

    [Theory]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 14, 12, 13)]
    public void Game5_Can_Be_Played(string gameCSV, int blueCubes,  int redCubes, int greenCubes)
    {
        var game = new Game(gameCSV);
        game.Id.Should().Be(5);

        game.CubeSets.Count().Should().Be(2);

        var cubeSet1 = game.CubeSets.First();
        cubeSet1.BlueCount.Should().Be(1);
        cubeSet1.RedCount.Should().Be(6);
        cubeSet1.GreenCount.Should().Be(3);

        var cubeSet3 = game.CubeSets.Last();
        cubeSet3.BlueCount.Should().Be(2);
        cubeSet3.RedCount.Should().Be(1);
        cubeSet3.GreenCount.Should().Be(2);

        var canBePlayed = game.CanBePlayed(blueCubes, redCubes, greenCubes);
        canBePlayed.Should().BeTrue();

        game.BlueCountMin.Should().Be(2);
        game.RedCountMin.Should().Be(6);
        game.GreenCountMin.Should().Be(3);

        game.Power.Should().Be(36);
    }
}
