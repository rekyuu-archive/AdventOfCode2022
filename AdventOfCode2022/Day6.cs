using System;

namespace AdventOfCode2022;

public static class Day6
{
    /// <summary>
    /// Finds the first iteration of a string with all unique characters of supplied length and returns it's ending index.
    /// </summary>
    /// <param name="input">The string to iterate through.</param>
    /// <param name="length">The length of the string to determine has unique characters.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Throws if the unique string is not found.</exception>
    public static int FindStartOfPacketMarkerIndex(string input, int length)
    {
        for (int i = 0; i < input.Length - length; i++)
        {
            string marker = input.Substring(i, length);
            if (StringHasAllUniqueCharacters(marker)) return i + length;
        }

        throw new Exception("Start marker not found.");
    }

    /// <summary>
    /// Checks if a string has all unique characters.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <returns>True if all characters are unique, false otherwise.</returns>
    public static bool StringHasAllUniqueCharacters(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j < input.Length; j++)
            {
                if (input[i] == input[j]) return false;
            }
        }

        return true;
    }
}