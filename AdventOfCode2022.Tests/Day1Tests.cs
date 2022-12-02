using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day1Tests
{
    [Fact]
    public void InventoriesToCalories_ReturnsCaloriesCountArray()
    {
        string data = File.ReadAllText("TestInput/Day1.txt").TrimEnd();
        IEnumerable<int> result = Day1.InventoriesToCalories(data);
        
        Assert.Equal(new[] { 6000, 4000, 11000, 24000, 10000 }, result);
    }
    
    [Fact]
    public void GetMaxCombinedCalories_ReturnsMaxCalories()
    {
        string data = File.ReadAllText("TestInput/Day1.txt").TrimEnd();
        int result = Day1.GetMaxCombinedCalories(data);
        
        Assert.Equal(24000, result);
    }
    
    [Fact]
    public void GetTop3CombinedCalories_ReturnsCorrectSumOfCalories()
    {
        string data = File.ReadAllText("TestInput/Day1.txt").TrimEnd();
        int result = Day1.GetTop3CombinedCalories(data);
        
        Assert.Equal(45000, result);
    }
}