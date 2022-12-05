using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day5Tests
{
    [Fact]
    public void GetTopCratesFromSingleSortedCrates_ReturnsTheCorrectString()
    {
        string input = File.ReadAllText("TestInput/Day5.txt").TrimEnd();
        string result = Day5.GetTopCratesFromSingleSortedCrates(input);
        
        Assert.Equal("CMZ", result);
    }
    
    [Fact]
    public void GetTopCratesFromMultipleSortedCrates_ReturnsTheCorrectString()
    {
        string input = File.ReadAllText("TestInput/Day5.txt").TrimEnd();
        string result = Day5.GetTopCratesFromMultipleSortedCrates(input);
        
        Assert.Equal("MCD", result);
    }
}