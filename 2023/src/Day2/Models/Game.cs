namespace AdventOfCode2023.Day2;

public class Game
{
    //(Game\s\d)
    public int Id { get; private set; }
    public List<CubeSets> CubeSets { get; private set; } = new List<CubeSets>();

    public int BlueCountMin { get; private set; } = 0;
    public int RedCountMin { get; private set; } = 0;
    public int GreenCountMin { get; private set; } = 0;

    public int Power { 
        get { return CalculatePower(); } 
    }

    public Game(string gameCSV)
    {
        var gamePart = gameCSV.Split(":");

        if(!int.TryParse(gamePart[0].Split(" ")[1], out var id))
        {
            throw new Exception($"Parsing issue to build game {gamePart}");
        }
        Id = id;

        foreach(var setsPart in gamePart[1].Split(";"))
        {
            var cubeSet = new CubeSets(setsPart);
            AddMinimumSetsInformation(cubeSet);
            CubeSets.Add(cubeSet);
        }
    }

    private void AddMinimumSetsInformation(CubeSets cubeSet)
    {
        if(BlueCountMin < cubeSet.BlueCount)
        {
            BlueCountMin = cubeSet.BlueCount;
        }

        if(RedCountMin < cubeSet.RedCount)
        {
            RedCountMin = cubeSet.RedCount;
        }

        if(GreenCountMin < cubeSet.GreenCount)
        {
            GreenCountMin = cubeSet.GreenCount;
        }
    }

    private int CalculatePower()
    {
        return BlueCountMin * RedCountMin * GreenCountMin;
    }

    public bool CanBePlayed(int blueCount, int redCount, int greenCount)
    {
        foreach(var cubeSet in CubeSets)
        {
            if (!cubeSet.CanBePlayed(redCount, blueCount, greenCount))
                return false;
        }

        return true;
    }
}