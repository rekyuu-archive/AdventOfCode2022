using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022;

public class Day5
{
    /// <summary>
    /// Gets the topmost crates as a string when sorted one at a time.
    /// </summary>
    /// <param name="input">The current crate stack and the instructions for sorting them.</param>
    /// <returns>The topmost crates as a string.</returns>
    public static string GetTopCratesFromSingleSortedCrates(string input)
    {
        List<List<char>> crates = SortCrates(input);
        string[] instructions = GetInstructions(input);
        
        foreach (string instruction in instructions)
        {
            (int amount, int source, int destination) = ParseInstruction(instruction);

            for (int i = 0; i < amount; i++)
            {
                char crate = crates[source].Last();
                
                crates[source].RemoveAt(crates[source].Count - 1);
                crates[destination].Add(crate);
            }
        }

        return new string(crates
            .Select(x => x.Last())
            .ToArray());
    }
    
    /// <summary>
    /// Gets the topmost crates as a string when sorted multiple at a time.
    /// </summary>
    /// <param name="input">The current crate stack and the instructions for sorting them.</param>
    /// <returns>The topmost crates as a string.</returns>
    public static string GetTopCratesFromMultipleSortedCrates(string input)
    {
        List<List<char>> crates = SortCrates(input);
        string[] instructions = GetInstructions(input);
        
        foreach (string instruction in instructions)
        {
            (int amount, int source, int destination) = ParseInstruction(instruction);
            
            int start = crates[source].Count - amount;
            char[] stack = crates[source].Skip(start).ToArray();

            crates[source] = crates[source].SkipLast(amount).ToList();
            crates[destination].AddRange(stack);
        }

        return new string(crates
            .Select(x => x.Last())
            .ToArray());
    }

    public static List<List<char>> SortCrates(string input)
    {
        string[] rawCrates = input.Split("\n\n").First().Split("\n").Reverse().Skip(1).ToArray();
        
        List<List<char>> crates = new();
        foreach (string row in rawCrates)
        {
            for (int stack = 0; stack * 4 < row.Length; stack++)
            {
                string crate = row
                    .Substring(stack * 4, 3)
                    .Trim()
                    .Replace("[", "")
                    .Replace("]", "");

                if (crates.Count < stack + 1) crates.Add(new List<char>());
                if (!string.IsNullOrEmpty(crate.Trim())) crates[stack].Add(char.Parse(crate));
            }
        }

        return crates;
    }

    public static string[] GetInstructions(string input)
    {
        return input.Split("\n\n").Last().Split("\n");
    }

    public static (int amount, int source, int destination) ParseInstruction(string instruction)
    {
        Regex rx = new("move ([0-9]+) from ([0-9]+) to ([0-9]+)");
        Match match = rx.Match(instruction);
            
        if (!match.Success || match.Groups.Count < 3) throw new Exception($"Match on instruction failed: {instruction}");
            
        int amount = int.Parse(match.Groups[1].Value);
        int source = int.Parse(match.Groups[2].Value) - 1;
        int destination = int.Parse(match.Groups[3].Value) - 1;

        return (amount, source, destination);
    }
}