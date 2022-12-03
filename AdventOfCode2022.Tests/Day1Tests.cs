using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day1Tests
{
    [Fact]
    public void InventoriesToCalories_ReturnsCaloriesCountArray()
    {
        string input = File.ReadAllText("TestInput/Day1.txt").TrimEnd();
        IEnumerable<int> result = Day1.InventoriesToCalories(input);
        
        Assert.Equal(new[] { 6000, 4000, 11000, 24000, 10000 }, result);
    }
    
    [Fact]
    public void GetMaxCombinedCalories_ReturnsMaxCalories()
    {
        string input = File.ReadAllText("TestInput/Day1.txt").TrimEnd();
        int result = Day1.GetMaxCombinedCalories(input);
        
        Assert.Equal(24000, result);
    }
    
    [Fact]
    public void GetTop3CombinedCalories_ReturnsCorrectSumOfCalories()
    {
        string input = File.ReadAllText("TestInput/Day1.txt").TrimEnd();
        int result = Day1.GetTop3CombinedCalories(input);
        
        Assert.Equal(45000, result);
    }
}