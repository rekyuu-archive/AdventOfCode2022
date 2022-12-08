using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022;

public static class Day7
{
    /// <summary>
    /// Gets the sum of directories whose sizes are no more than 100000 bytes.
    /// </summary>
    /// <param name="input">The terminal log file.</param>
    /// <returns>The sum of directory sizes.</returns>
    public static long SumOfLargeDirectoriesFromTerminalOutput(string input)
    {
        Dictionary<string, long> directorySizes = GetDirectorySizes(input);
        return directorySizes.Values.Where(x => x <= 100000).Sum();
    }

    /// <summary>
    /// Gets minimum size of the directory needed to free up enough space for the upgrade.
    /// </summary>
    /// <param name="input">The terminal log file.</param>
    /// <returns>The minimum size of the directory.</returns>
    public static long GetSmallestDirectorySizeForFreeSpace(string input)
    {
        Dictionary<string, long> directorySizes = GetDirectorySizes(input);
        
        const long diskSize = 70000000;
        const long requiredFreeSpace = 30000000;
        long currentFreeSpace = diskSize - directorySizes[""];
        long requiredDirectorySize = requiredFreeSpace - currentFreeSpace;

        return directorySizes.Values.Where(x => x >= requiredDirectorySize).Min();
    }

    /// <summary>
    /// Gets a dictionary of folder paths with their respective sizes.
    /// </summary>
    /// <param name="input">The terminal log file.</param>
    /// <returns>A dictionary with the path as the key and the directory size as the value.</returns>
    public static Dictionary<string, long> GetDirectorySizes(string input)
    {
        string[] lines = input.Split("\n");
        Dictionary<string, long> directorySizes = new();
        
        List<string> currentDirectory = new();
        foreach (string line in lines)
        {
            string[] split = line.Split(" ");

            switch (split[0])
            {
                case "$":
                {
                    string command = split[1];
                    if (command == "ls") continue;

                    string destination = split[2];
                    if (destination == "..")
                    {
                        currentDirectory.RemoveAt(currentDirectory.Count - 1);
                        continue;
                    }
                    
                    currentDirectory.Add(destination.Replace("/", ""));
                    break;
                }
                case "dir":
                    continue;
                default:
                {
                    long fileSize = long.Parse(split[0]);
                    
                    for (int i = 0; i < currentDirectory.Count; i++)
                    {
                        string path = string.Join("/", currentDirectory.Take(i + 1));

                        if (directorySizes.ContainsKey(path)) directorySizes[path] += fileSize;
                        else directorySizes.Add(path, fileSize);
                    }
                    
                    break;
                }
            }
        }

        return directorySizes;
    }
}