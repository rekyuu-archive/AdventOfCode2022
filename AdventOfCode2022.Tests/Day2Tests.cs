using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day2Tests
{
    [Fact]
    public void GetScoreForInputByResponse_ReturnsTheCorrectScore()
    {
        string data = File.ReadAllText("TestInput/Day2.txt").TrimEnd();
        int result = Day2.GetScoreForInputByResponse(data);
        
        Assert.Equal(15, result);
    }
    
    [Fact]
    public void GetScoreForInputByResult_ReturnsTheCorrectScore()
    {
        string data = File.ReadAllText("TestInput/Day2.txt").TrimEnd();
        int result = Day2.GetScoreForInputByResult(data);
        
        Assert.Equal(12, result);
    }
}