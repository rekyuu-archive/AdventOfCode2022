using System;
using System.Collections.Generic;
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

    [Fact]
    public void SortCrates_SortsIntoList()
    {
        string input = File.ReadAllText("TestInput/Day5.txt").TrimEnd();
        List<List<char>> result = Day5.SortCrates(input);

        List<List<char>> expected = new()
        {
            new List<char> { 'Z', 'N' },
            new List<char> { 'M', 'C', 'D' },
            new List<char> { 'P' }
        };
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetInstructions_ReturnsArrayOfInstructions()
    {
        string input = File.ReadAllText("TestInput/Day5.txt").TrimEnd();
        string[] result = Day5.GetInstructions(input);

        string[] expected = 
        {
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 1, 0)]
    [InlineData("move 3 from 1 to 3", 3, 0, 2)]
    [InlineData("move 2 from 2 to 1", 2, 1, 0)]
    [InlineData("move 1 from 1 to 2", 1, 0, 1)]
    public void ParseInstruction_ParsesCorrectInstructions(string instruction, int expectedAmount, int expectedSource, int expectedDestination)
    {
        (int amount, int source, int destination) result = Day5.ParseInstruction(instruction);
        Assert.Equal((expectedAmount, expectedSource, expectedDestination), result);
    }

    [Theory]
    [InlineData("\n")]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData("move 1 from 1 to")]
    public void ParseInstruction_BadInstructionThrowsException(string instruction)
    {
        Assert.Throws<Exception>(() => Day5.ParseInstruction(instruction));
    }
}