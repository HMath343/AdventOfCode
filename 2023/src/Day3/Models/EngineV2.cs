namespace AdventOfCode2023.Day3;

using System.Text.RegularExpressions;

public class EngineV2
{
    public char[,] Schema { get; set; }

    private Regex NotNumberRegex = new Regex(@"([\D])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private Regex NumberRegex = new Regex(@"(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public int Totals { get; set; } = 0;
    public int NumberCount { get; set; } = 0;

    public EngineV2(IEnumerable<string> schema)
    {
        Schema = new char[schema.Count(), schema.First().Length];
        var rowNumber = 0;
        var columnNumber = 0;

        foreach(string schemaLine in schema)
        {
            columnNumber = 0;
            foreach(char c in schemaLine)
            {
                Schema[rowNumber, columnNumber] = c;
                columnNumber++;
            }
            rowNumber++;
        }

    }

    public void CalculateGearTotals()
    {
        for (int row = 0; row < Schema.GetLength(0); row++)
        {
            for (int column = 0; column < Schema.GetLength(1); column++)
            {
                var value = Schema[row, column];
                if (value == '*')
                {
                    AdjacentNumbersCheck(row, column);
                }
            }       
        }
    }

    private void AdjacentNumbersCheck(int row, int column)
    {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"Investigating gear at {row} / {column}");
        var topNumbers = TopAdjacentNumbersCheck(row, column);
        var leftNumber = LeftAdjacentNumbersCheck(row, column);
        var rightNumber = RightAdjacentNumbersCheck(row, column);
        Console.WriteLine($"{leftNumber.Item2}*{rightNumber.Item2}");
        var bottomNumbers = BottomAdjacentNumbersCheck(row, column);

        var numbers = new List<int>();
        numbers.AddRange(topNumbers);
        if(leftNumber.Item1 is not null)
            numbers.Add((int)leftNumber.Item1);
        if(rightNumber.Item1 is not null)
            numbers.Add((int)rightNumber.Item1);
        numbers.AddRange(bottomNumbers);

        if(numbers.Count == 2)
        {
            Console.WriteLine($"Gear found {numbers.First()} {numbers.Last()}");
            Totals += numbers.First() * numbers.Last();
        }
    }


    private IEnumerable<int> TopAdjacentNumbersCheck(int row, int column)
    {
        var top = row - 1;
        if(top < 0)
        {
            return Enumerable.Empty<int>();
        }

        var bufferLeft = string.Empty;
        var noLeftMatchCount = 0;
        var numberFound = false;
        for(int i = column; i >= 0; i--)
        {
            var c = Schema[top, i];
            if(NotNumberRegex.Match(c.ToString()).Success)
            {
                noLeftMatchCount++;
                if(noLeftMatchCount == 2)
                    break;
            }
            else
            {
                numberFound = true;
            }
            if (i <= column - 1 && NotNumberRegex.Match(c.ToString()).Success && numberFound)
                break;

            bufferLeft += c;
        }

        var bufferRight = string.Empty;
        var noRightMatchCount = 0;
        numberFound = false;
        for(int i = column; i < Schema.GetLength(1); i++)
        {
            var c = Schema[top, i];
            if(NotNumberRegex.Match(c.ToString()).Success)
            {
                noRightMatchCount++;
                if(noRightMatchCount == 2)
                    break;
            }
            else
            {
                numberFound = true;
            }

            if (i >= column + 1 && NotNumberRegex.Match(c.ToString()).Success && numberFound)
                break;

            bufferRight += c;
        }

        if(string.IsNullOrEmpty(bufferLeft) && string.IsNullOrEmpty(bufferRight))
        {
            return Enumerable.Empty<int>();

        }

        string leftNumber = string.Empty;
        if(!string.IsNullOrEmpty(bufferLeft))
        {
            foreach(var c in bufferLeft.Reverse())
            {
                leftNumber += c;
            };
        }

        var aboveChar = Schema[top, column];
        var topBuffer = string.Empty;
        if(NumberRegex.Match(aboveChar.ToString()).Success)
        {
            topBuffer = $"{leftNumber.Remove(leftNumber.Length - 1, 1)}{aboveChar}{bufferRight.Remove(0,1)}";
           
        }
        else
        {
            topBuffer = $"{leftNumber}{bufferRight}";
        }

        Console.WriteLine($"{topBuffer}");
        var numbers = new List<int>();
        foreach(Match match in NumberRegex.Matches(topBuffer))
        {
            if(int.TryParse(match.Value, out var v))
            {
                numbers.Add(v);
            }
        }

        return numbers;
    }

    private (int?, string) LeftAdjacentNumbersCheck(int row, int column)
    {
        var left = column - 1;
        var buffer = string.Empty;
        for(int i = left; i >= 0; i--)
        {
            var c = Schema[row, i];
            if(NotNumberRegex.Match(c.ToString()).Success)
            {
                break;
            }
            buffer += c;
        }

        if(string.IsNullOrEmpty(buffer))
        {
            return (null, string.Empty);
        }

        string leftNumber = string.Empty;
        foreach(var c in buffer.Reverse())
        {
            leftNumber += c;
        };

        
        if(int.TryParse(leftNumber, out var leftNumberValue))
        {
            return (leftNumberValue, buffer);
        }

        return (null, string.Empty);
        
    }

    private (int?, string) RightAdjacentNumbersCheck(int row, int column)
    {
        var right = column + 1;
        var buffer = string.Empty;
        for(int i = right; i < Schema.GetLength(1); i++)
        {
            var c = Schema[row, i];
            if(NotNumberRegex.Match(c.ToString()).Success)
            {
                break;
            }
            buffer += c;
        }

        if(string.IsNullOrEmpty(buffer))
        {
            return (null, string.Empty);
        }
        

        if(int.TryParse(buffer, out var rightNumberValue))
        {
            return (rightNumberValue, buffer);
        }

        return (null, string.Empty);
        
    }

    private IEnumerable<int> BottomAdjacentNumbersCheck(int row, int column)
    {
        var bottom = row + 1;
        if(bottom > Schema.GetLength(1))
        {
            return Enumerable.Empty<int>();
        }

        var bufferLeft = string.Empty;
        var noLeftMatchCount = 0;
        var numberFound = false;
        for(int i = column; i > 0; i--)
        {
            var c = Schema[bottom, i];
            if(NotNumberRegex.Match(c.ToString()).Success)
            {
                noLeftMatchCount++;
                if(noLeftMatchCount == 2)
                    break;
            }
            else
            {
                numberFound = true;
            }

            if (i <= column - 1 && NotNumberRegex.Match(c.ToString()).Success && numberFound)
                break;

            bufferLeft += c;
        }

        var bufferRight = string.Empty;
        var noRightMatchCount = 0;
        numberFound = false;
        for(int i = column; i < Schema.GetLength(1); i++)
        {
            var c = Schema[bottom, i];
            if(NotNumberRegex.Match(c.ToString()).Success)
            {
                noRightMatchCount++;
                if(noRightMatchCount == 2)
                    break;
            }
            else
            {
                numberFound = true;
            }

            if (i >= column + 1 && NotNumberRegex.Match(c.ToString()).Success && numberFound)
                break;

            bufferRight += c;
        }

        if(string.IsNullOrEmpty(bufferLeft) && string.IsNullOrEmpty(bufferRight))
        {
            return Enumerable.Empty<int>();

        }

        string leftNumber = string.Empty;
        if(!string.IsNullOrEmpty(bufferLeft))
        {
            foreach(var c in bufferLeft.Reverse())
            {
                leftNumber += c;
            };
        }

        var aboveChar = Schema[bottom, column];
        var bottomBuffer = string.Empty;
        if(NumberRegex.Match(aboveChar.ToString()).Success)
        {
            bottomBuffer = $"{leftNumber.Remove(leftNumber.Length - 1, 1)}{aboveChar}{bufferRight.Remove(0,1)}";
           
        }
        else
        {
            bottomBuffer = $"{leftNumber}{bufferRight}";
        }

        Console.WriteLine($"{bottomBuffer}");
        var numbers = new List<int>();
        foreach(Match match in NumberRegex.Matches(bottomBuffer))
        {
            if(int.TryParse(match.Value, out var v))
            {
                numbers.Add(v);
            }
        }

        return numbers;
    }
}