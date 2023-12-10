namespace AdventOfCode2023.Day3;

using System.Text.RegularExpressions;

public class Engine
{
    public char[,] Schema { get; set; }

    private Regex rx = new Regex(@"([^\.\d])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private Regex rx2 = new Regex(@"([\D])", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public int Totals { get; set; } = 0;
    public int NumberCount { get; set; } = 0;

    public Engine(IEnumerable<string> schema)
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


    public void CalculateTotals()
    {
        var numberLength = 0;
        var numberStartPosition = 0;
        var numberString = "";
        for (int row = 0; row < Schema.GetLength(0); row++)
        {
            for (int column = 0; column < Schema.GetLength(1); column++)
            {
                var value = Schema[row, column];
                if (int.TryParse(value.ToString(), out var digit))
                {
                    if (string.IsNullOrEmpty(numberString))
                    {
                        numberStartPosition = column;
                    }
                    numberString += value.ToString();
                    numberLength++;
                }

                if (!string.IsNullOrEmpty(numberString) && rx2.Match(value.ToString()).Success)
                {
                    //Check if there is a sign around
                    if (AdjacentSymbolCheck(numberString, numberStartPosition, row))
                    {
                        if (int.TryParse(numberString, out var result))
                        {
                            Totals += result;
                        }
                    }
                    numberString = string.Empty;
                    numberLength = 0;
                    NumberCount++;
                }
            }

            if (!string.IsNullOrEmpty(numberString))
            {
                //Check if there is a sign around
                if (AdjacentSymbolCheck(numberString, numberStartPosition, row))
                {
                    if (int.TryParse(numberString, out var result))
                    {
                        Totals += result;
                    }
                }
                numberString = string.Empty;
                numberLength = 0;
                NumberCount++;
            }
        
        }
    }

    private bool AdjacentSymbolCheck(string value, int numberStartPosition, int row)
    {
        var hasUpSymbolAdjacent = AdjacentSymbolCheckUp(value, numberStartPosition, row);
        var hasLeftSymbolAdjacent = AdjacentSymbolCheckLeft(numberStartPosition, row);
        var hasRightSymbolAdjacent = AdjacentSymbolCheckRight(value, numberStartPosition, row);

        var hasLeft = numberStartPosition - 1 > 0;
        var hasRight = numberStartPosition + value.Length < Schema.GetLength(1);
        var left = hasLeft ? Schema[row, numberStartPosition - 1].ToString() : " ";
        var right = hasRight ? Schema[row, numberStartPosition + value.Length].ToString() : " ";
        Console.WriteLine($"{left}{value}{right}");

        var hasDownSymbolAdjacent = AdjacentSymbolCheckDown(value, numberStartPosition, row);

        var hasAdjacentSymbol = hasUpSymbolAdjacent || hasLeftSymbolAdjacent || hasRightSymbolAdjacent || hasDownSymbolAdjacent;
        if(hasAdjacentSymbol)
            Console.WriteLine($"Row : {row} / Match : {value}");
        else
            Console.WriteLine($"Row : {row} / No Match : {value}");
        return hasAdjacentSymbol;
    }

    private bool AdjacentSymbolCheckUp(string value, int numberStartPosition, int row)
    {
        var testStringAbove = string.Empty;
        var rowAbove = row - 1;
        var hasAdjacentSign = false;
        if(rowAbove >= 0)
        {
            for(int i = numberStartPosition - 1; i <= numberStartPosition + value.Length; i++)
            {
                if(i >= 0 && i < Schema.GetLength(1)) // Left/Right border
                {
                    var c = Schema[rowAbove, i];
                    testStringAbove += c;
                    MatchCollection matches = rx.Matches(c.ToString());
                    if(matches.Count == 1)
                    {
                        hasAdjacentSign = true;
                    }
                }

            }
        }
        Console.WriteLine(testStringAbove);
        return hasAdjacentSign;
    }

    private bool AdjacentSymbolCheckLeft(int numberStartPosition, int row)
    {
        var left = numberStartPosition - 1;
        var hasAdjacentSign = false;
        if(left > 0)
        {
            var c = Schema[row, left];
            MatchCollection matches = rx.Matches(c.ToString());
            if(matches.Count == 1)
            {
                hasAdjacentSign = true;
            }
        }
        return hasAdjacentSign;
    }

    private bool AdjacentSymbolCheckRight(string value, int numberStartPosition, int row)
    {
        var right = numberStartPosition + value.Length;
        var hasAdjacentSign = false;
        if(right < Schema.GetLength(1))
        {
            var c = Schema[row, right];
            MatchCollection matches = rx.Matches(c.ToString());
            if(matches.Count == 1)
            {
                hasAdjacentSign = true;
            }
        }
        return hasAdjacentSign;
    }

    private bool AdjacentSymbolCheckDown(string value, int numberStartPosition, int row)
    {
        var rowBelow = row + 1;
        var hasAdjacentSign = false;
        var testStringBelow = string.Empty;
        if(rowBelow < Schema.GetLength(0))
        {
            var dbg = numberStartPosition - 1;
            var dbd = numberStartPosition + value.Length + 1;
            for(int i = numberStartPosition - 1; i < numberStartPosition + value.Length + 1; i++)
            {
                if(i >= 0 && i < Schema.GetLength(1)) // Left/Right border
                {
                    var c = Schema[rowBelow, i];
                    testStringBelow += c;
                    MatchCollection matches = rx.Matches(c.ToString());
                    if(matches.Count == 1)
                    {
                        hasAdjacentSign = true;
                    }
                }

            }
        }
        Console.WriteLine(testStringBelow);
        return hasAdjacentSign;
    }
}