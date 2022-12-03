using System;
using System.Linq;

namespace AdventOfCode2022;

public static class Day3
{
    private const string _priorities = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Gets the total of item rankings for the common item in a rucksack's evenly sized compartments.
    /// </summary>
    /// <param name="input">List of rucksacks with each line indicating it's contents by characters representing items.</param>
    /// <returns>The sum of item rankings.</returns>
    public static int GetSumOfRankingsForRucksacks(string input)
    {
        return input
            .Split("\n")
            .Select(GetCommonItemInCompartments)
            .Sum(GetRankingForItem);
    }

    /// <summary>
    /// Gets the total of item rankings for the common item in groups of 3 rucksacks.
    /// </summary>
    /// <param name="input">List of rucksacks with each line indicating it's contents by characters representing items.</param>
    /// <returns>The sum of item rankings.</returns>
    public static int GetSumOfRankingsForTeam(string input)
    {
        string[] rucksacks = input.Split("\n");

        int total = 0;
        for (int i = 0; i < rucksacks.Length; i += 3)
        {
            char commonItem = GetCommonItemInRucksacks(new[]
            {
                rucksacks[i],
                rucksacks[i + 1],
                rucksacks[i + 2]
            });

            total += GetRankingForItem(commonItem);
        }

        return total;
    }

    private static char GetCommonItemInRucksacks(string[] rucksacks)
    {
        char? result = 'a';
        foreach (char item in rucksacks[0])
        {
            if (!rucksacks[1].Contains(item) || !rucksacks[2].Contains(item)) continue;
            if (GetRankingForItem(result.Value) < GetRankingForItem(item)) result = item;
        }

        if (result == null) throw new Exception($"No common items found in rucksacks: {rucksacks}");

        return result.Value;
    }

    private static char GetCommonItemInCompartments(string rucksack)
    {
        int compartmentSize = rucksack.Length / 2;
        string[] compartments = 
        {
            rucksack[..compartmentSize], 
            rucksack.Substring(compartmentSize, compartmentSize)
        };

        char? result = 'a';
        foreach (char item in compartments[0])
        {
            if (!compartments[1].Contains(item)) continue;
            if (GetRankingForItem(result.Value) < GetRankingForItem(item)) result = item;
        }

        if (result == null) throw new Exception($"No common items found in rucksack: {rucksack}");

        return result.Value;
    }

    private static int GetRankingForItem(char item)
    {
        return _priorities.IndexOf(item) + 1;
    }
}