using System;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day6Tests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 4, 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 14, 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26)]
    public void FindStartOfPacketMarkerIndex_ReturnsCorrectIndex(string input, int length, int expected)
    {
        int result = Day6.FindStartOfPacketMarkerIndex(input, length);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("mjqj")]
    [InlineData("jqjp")]
    [InlineData("qjpq")]
    public void FindStartOfPacketMarkerIndex_ThrowsIfNoUniqueCharacterString(string input)
    {
        Assert.Throws<Exception>(() => Day6.FindStartOfPacketMarkerIndex(input, 4));
    }

    [Theory]
    [InlineData("mjqj", false)]
    [InlineData("jqjp", false)]
    [InlineData("qjpq", false)]
    [InlineData("jpqm", true)]
    public void StringHasAllUniqueCharacters_ReturnsCorrectly(string input, bool expected)
    {
        bool result = Day6.StringHasAllUniqueCharacters(input);
        Assert.Equal(expected, result);
    }
}