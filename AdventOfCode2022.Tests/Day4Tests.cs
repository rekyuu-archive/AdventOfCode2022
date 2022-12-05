using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day4Tests
{
    [Fact]
    public void GetCountOfFullyContainedPairs_ReturnsTheCorrectCount()
    {
        string input = File.ReadAllText("TestInput/Day4.txt").TrimEnd();
        int result = Day4.GetCountOfFullyContainedPairs(input);
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void GetCountOfPartiallyContainedPairs_ReturnsTheCorrectCount()
    {
        string input = File.ReadAllText("TestInput/Day4.txt").TrimEnd();
        int result = Day4.GetCountOfPartiallyContainedPairs(input);
        
        Assert.Equal(4, result);
    }

    [Theory]
    [InlineData("2-4,6-8", 2, 4, 6, 8)]
    [InlineData("2-3,4-5", 2, 3, 4, 5)]
    [InlineData("5-7,7-9", 5, 7, 7, 9)]
    [InlineData("2-8,3-7", 2, 8, 3, 7)]
    [InlineData("6-6,4-6", 6, 6, 4, 6)]
    [InlineData("2-6,4-8", 2, 6, 4, 8)]
    public void GetAssignmentsFromPair_ReturnsCorrectArray(string pair, params int[] expectedPairs)
    {
        int[][] result = Day4.GetAssignmentsFromPair(pair);
        int[][] expected =
        {
            new[] { expectedPairs[0], expectedPairs[1] }, 
            new[] { expectedPairs[2], expectedPairs[3] }
        };
        
        Assert.Equal(expected, result);
    }
}