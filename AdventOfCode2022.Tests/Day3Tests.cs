using System;
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

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void GetCommonItemInCompartments_ReturnsCommonItem(string rucksack, char expected)
    {
        char result = Day3.GetCommonItemInCompartments(rucksack);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abcd")]
    [InlineData("efgh")]
    [InlineData("ijkl")]
    [InlineData("mnop")]
    public void GetCommonItemInCompartments_ThrowsWhenNoCommonItem(string rucksack)
    {
        Assert.Throws<Exception>(() => Day3.GetCommonItemInCompartments(rucksack));
    }

    [Theory]
    [InlineData('r', "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg")]
    [InlineData('Z', "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void GetCommonItemInRucksacks_ReturnsCommonItem(char expected, params string[] rucksacks)
    {
        char result = Day3.GetCommonItemInRucksacks(rucksacks);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abcd", "efgh")]
    [InlineData("ijkl", "mnop")]
    public void GetCommonItemInRucksacks_ThrowsWhenNoCommonItem(params string[] rucksacks)
    {
        Assert.Throws<Exception>(() => Day3.GetCommonItemInRucksacks(rucksacks));
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 2)]
    [InlineData('c', 3)]
    [InlineData('d', 4)]
    [InlineData('e', 5)]
    [InlineData('f', 6)]
    [InlineData('g', 7)]
    [InlineData('h', 8)]
    [InlineData('i', 9)]
    [InlineData('j', 10)]
    [InlineData('k', 11)]
    [InlineData('l', 12)]
    [InlineData('m', 13)]
    [InlineData('n', 14)]
    [InlineData('o', 15)]
    [InlineData('p', 16)]
    [InlineData('q', 17)]
    [InlineData('r', 18)]
    [InlineData('s', 19)]
    [InlineData('t', 20)]
    [InlineData('u', 21)]
    [InlineData('v', 22)]
    [InlineData('w', 23)]
    [InlineData('x', 24)]
    [InlineData('y', 25)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('B', 28)]
    [InlineData('C', 29)]
    [InlineData('D', 30)]
    [InlineData('E', 31)]
    [InlineData('F', 32)]
    [InlineData('G', 33)]
    [InlineData('H', 34)]
    [InlineData('I', 35)]
    [InlineData('J', 36)]
    [InlineData('K', 37)]
    [InlineData('L', 38)]
    [InlineData('M', 39)]
    [InlineData('N', 40)]
    [InlineData('O', 41)]
    [InlineData('P', 42)]
    [InlineData('Q', 43)]
    [InlineData('R', 44)]
    [InlineData('S', 45)]
    [InlineData('T', 46)]
    [InlineData('U', 47)]
    [InlineData('V', 48)]
    [InlineData('W', 49)]
    [InlineData('X', 50)]
    [InlineData('Y', 51)]
    [InlineData('Z', 52)]
    public void GetRankingForItem_ReturnsCorrectRank(char item, int expected)
    {
        int result = Day3.GetRankingForItem(item);
        Assert.Equal(expected, result);
    }
    
}