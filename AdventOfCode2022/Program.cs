using System;
using System.IO;

namespace AdventOfCode2022;

internal static class Program
{
    private static void Main(string[] args)
    {
        var result = Day1Part2();
        Console.WriteLine(result);
    }

    private static int Day1Part1()
    {
        string data = File.ReadAllText("Input/Day1.txt").TrimEnd();
        return Day1.GetMaxCombinedCalories(data);
    }

    private static int Day1Part2()
    {
        string data = File.ReadAllText("Input/Day1.txt").TrimEnd();
        return Day1.GetTop3CombinedCalories(data);
    }
}