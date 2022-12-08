using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day8Tests
{
    [Fact]
    public void GetVisibleTrees_ReturnsTheCorrectNumberOfTrees()
    {
        string input = File.ReadAllText("TestInput/Day8.txt").TrimEnd();
        int result = Day8.GetVisibleTrees(input);
        
        Assert.Equal(21, result);
    }
    
    [Fact]
    public void GetMaxTreeScore_ReturnsTheCorrectMaxScore()
    {
        string input = File.ReadAllText("TestInput/Day8.txt").TrimEnd();
        int result = Day8.GetMaxTreeScore(input);
        
        Assert.Equal(8, result);
    }

    [Fact]
    public void InputToMatrix_ProperlyCreatesMatrix()
    {
        string input = File.ReadAllText("TestInput/Day8.txt").TrimEnd();
        int[][] result = Day8.InputToMatrix(input);
        int[][] expected = {
            new[] { 3, 0, 3, 7, 3 },
            new[] { 2, 5, 5, 1, 2 },
            new[] { 6, 5, 3, 3, 2 },
            new[] { 3, 3, 5, 4, 9 },
            new[] { 3, 5, 3, 9, 0 }
        };
        
        Assert.Equal(expected, result);
    }
}