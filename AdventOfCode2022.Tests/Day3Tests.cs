using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day3Tests
{
    [Fact]
    public void GetScoreForInputByResponse_ReturnsTheCorrectSum()
    {
        string input = File.ReadAllText("TestInput/Day3.txt").TrimEnd();
        int result = Day3.GetSumOfRankingsForRucksacks(input);
        
        Assert.Equal(157, result);
    }
    
    [Fact]
    public void GetSumOfRankingsForTeam_ReturnsTheCorrectSum()
    {
        string input = File.ReadAllText("TestInput/Day3.txt").TrimEnd();
        int result = Day3.GetSumOfRankingsForTeam(input);
        
        Assert.Equal(70, result);
    }
}