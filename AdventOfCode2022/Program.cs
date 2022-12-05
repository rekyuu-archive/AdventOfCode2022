using System;
using System.IO;

namespace AdventOfCode2022;

internal static class Program
{
    private static int Main(string[] args)
    {
        try
        {
            string input  = File.ReadAllText("Input/Day5.txt").TrimEnd();
            string result = Day5.GetTopCratesFromMultipleSortedCrates(input);
        
            Console.WriteLine(result);

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return 1;
        }
    }
}