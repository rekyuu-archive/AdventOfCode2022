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
}