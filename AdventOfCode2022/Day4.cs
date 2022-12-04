using System.Linq;

namespace AdventOfCode2022;

public static class Day4
{
    /// <summary>
    /// Returns the count of pairs where either are fully contained.
    /// </summary>
    /// <param name="input">The list of pairs.</param>
    /// <returns>The count of pairs that fully contain either pair.</returns>
    public static int GetCountOfFullyContainedPairs(string input)
    {
        string[] pairs = input.Split("\n");

        int fullyContainedPairs = 0;
        foreach (string pair in pairs)
        {
            int[][] assignments = GetAssignmentsFromPair(pair);

            if ((assignments.First().Min() >= assignments.Last().Min() 
                && assignments.First().Max() <= assignments.Last().Max())
                || 
                (assignments.Last().Min() >= assignments.First().Min() 
                 && assignments.Last().Max() <= assignments.First().Max())) fullyContainedPairs++;
        }

        return fullyContainedPairs;
    }
    
    /// <summary>
    /// Returns the count of pairs where either pair partially overlap.
    /// </summary>
    /// <param name="input">The list of pairs.</param>
    /// <returns>The count of pairs that partially overlap.</returns>
    public static int GetCountOfPartiallyContainedPairs(string input)
    {
        string[] pairs = input.Split("\n");

        int partiallyContainedPairs = 0;
        foreach (string pair in pairs)
        {
            int[][] assignments = GetAssignmentsFromPair(pair);
            
            if (assignments.First().Min() <= assignments.Last().Max() 
                && assignments.Last().Min() <= assignments.First().Max()) partiallyContainedPairs++;
        }

        return partiallyContainedPairs;
    }

    private static int[][] GetAssignmentsFromPair(string pair)
    {
        return pair
            .Split(",")
            .Select(x => x
                .Split("-")
                .Select(int.Parse)
                .ToArray())
            .ToArray();
    }
}