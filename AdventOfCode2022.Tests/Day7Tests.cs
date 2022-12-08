using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day7Tests
{
    [Fact]
    public void SumOfLargeDirectoriesFromTerminalOutput_ReturnsCorrectFileSizeSum()
    {
        string input = File.ReadAllText("TestInput/Day7.txt").TrimEnd();
        long result = Day7.SumOfLargeDirectoriesFromTerminalOutput(input);
        
        Assert.Equal(95437, result);
    }
    
    [Fact]
    public void GetSmallestDirectorySizeForFreeSpace_ReturnsCorrectDirectorySize()
    {
        string input = File.ReadAllText("TestInput/Day7.txt").TrimEnd();
        long result = Day7.GetSmallestDirectorySizeForFreeSpace(input);
        
        Assert.Equal(24933642, result);
    }
    
    [Fact]
    public void GetDirectorySizes_ReturnsTheCorrectDirectorySizes()
    {
        string input = File.ReadAllText("TestInput/Day7.txt").TrimEnd();
        Dictionary<string, long> result = Day7.GetDirectorySizes(input);
        Dictionary<string, long> expected = new()
        {
            { "", 48381165 },
            { "/a", 94853 },
            { "/a/e", 584 },
            { "/d", 24933642 }
        };
        
        Assert.Equal(expected, result);
    }
}