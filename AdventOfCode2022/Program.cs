using System;
using System.IO;

namespace AdventOfCode2022;

internal static class Program
{
    private static int Main(string[] args)
    {
        try
        {
            string input  = File.ReadAllText("Input/Day8.txt").TrimEnd();
            int result = Day8.GetMaxTreeScore(input);
        
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