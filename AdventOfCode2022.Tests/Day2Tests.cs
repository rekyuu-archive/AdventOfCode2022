using System;
using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day2Tests
{
    [Fact]
    public void GetScoreForInputByResponse_ReturnsTheCorrectScore()
    {
        string input = File.ReadAllText("TestInput/Day2.txt").TrimEnd();
        int result = Day2.GetScoreForInputByResponse(input);
        
        Assert.Equal(15, result);
    }
    
    [Fact]
    public void GetScoreForInputByResult_ReturnsTheCorrectScore()
    {
        string input = File.ReadAllText("TestInput/Day2.txt").TrimEnd();
        int result = Day2.GetScoreForInputByResult(input);
        
        Assert.Equal(12, result);
    }

    [Theory]
    [InlineData("A X", 4)]
    [InlineData("A Y", 8)]
    [InlineData("A Z", 3)]
    [InlineData("B X", 1)]
    [InlineData("B Y", 5)]
    [InlineData("B Z", 9)]
    [InlineData("C X", 7)]
    [InlineData("C Y", 2)]
    [InlineData("C Z", 6)]
    public void GetScoreForRoundByResponse_ReturnsCorrectScore(string input, int expected)
    {
        int result = Day2.GetScoreForRoundByResponse(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\n")]
    [InlineData("A ")]
    [InlineData(" Z")]
    [InlineData(" ")]
    [InlineData("         ")]
    public void GetScoreForRoundByResponse_ThrowsForBadInput(string input)
    {
        Assert.Throws<Exception>(() => Day2.GetScoreForRoundByResponse(input));
    }

    [Theory]
    [InlineData("A X", 3)]
    [InlineData("A Y", 4)]
    [InlineData("A Z", 8)]
    [InlineData("B X", 1)]
    [InlineData("B Y", 5)]
    [InlineData("B Z", 9)]
    [InlineData("C X", 2)]
    [InlineData("C Y", 6)]
    [InlineData("C Z", 7)]
    public void GetScoreForRoundByResult_ReturnsCorrectScore(string input, int expected)
    {
        int result = Day2.GetScoreForRoundByResult(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\n")]
    [InlineData("A ")]
    [InlineData(" Z")]
    [InlineData(" ")]
    [InlineData("         ")]
    public void GetScoreForRoundByResult_ThrowsForBadInput(string input)
    {
        Assert.Throws<Exception>(() => Day2.GetScoreForRoundByResult(input));
    }
}