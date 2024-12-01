using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var (leftColumn, rightColumn) = GetColumns("input.txt");
            //GetTotalDistance(leftColumn, rightColumn);
            //GetSimilarityScore(leftColumn, rightColumn); 
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static (List<int> leftColumn, List<int> rightColumn) GetColumns(string filePath)
    {
        var leftColumn = new List<int>();
        var rightColumn = new List<int>();

        using (var streamReader = new StreamReader(filePath))
        {
            string? line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var inputs = line.Split(' ');
                if (inputs.Length > 3)
                {
                    if (int.TryParse(inputs[0], out var leftValue))
                        leftColumn.Add(leftValue);

                    if (int.TryParse(inputs[3], out var rightValue))
                        rightColumn.Add(rightValue);
                }
            }
        }

        return (leftColumn, rightColumn);
    }

    static void DisplayColums(List<int> a, List<int> b)
    {
        for (int i = 0; i < a.Count; i++)
        {
            var message = $"{a[i]} - {b[i]}";
            Console.WriteLine(message);
        }
    }

    static void GetTotalDistance(List<int> a, List<int> b)
    {
        a.Sort();
        b.Sort();
        DisplayColums(a, b);
        var delta = GetColumnDelta(a, b);
        Console.WriteLine(delta);
        Console.ReadLine();
    }

    static int GetColumnDelta(List<int> a, List<int> b)
    {
        var total = 0;
        for (int i = 0; i < a.Count; i++)
        {
            total += Math.Abs((a[i] - b[i]));
        }
        return total;
    }

    static Dictionary<int, int> GetColumnFrequency(List<int> a)
    {
        var frequencyTable = new Dictionary<int, int>();
        for (int i = 0;i < a.Count; i++)
        {
            if (frequencyTable.ContainsKey(a[i]))
            {
                frequencyTable[a[i]]++;
            }
            else
            {
                frequencyTable.Add(a[i], 1);
            }
        }
        return frequencyTable;
    }

    static void GetSimilarityScore(List<int> a, List<int> b)
    {
        var frequencyTable = GetColumnFrequency(b);
        var score = 0;
        for (int i = 0; i < a.Count; i++)
        {
            if (frequencyTable.ContainsKey(a[i]))
            {
                score += a[i]*frequencyTable[a[i]];
            }
        }
        Console.WriteLine(score);
        Console.ReadLine();
    }
}



