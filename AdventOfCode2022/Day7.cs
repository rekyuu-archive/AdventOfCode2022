using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022;

public static class Day7
{
    public static long SumOfLargeDirectoriesFromTerminalOutput(string input)
    {
        Dictionary<string, long> directorySizes = GetDirectorySizes(input);
        return directorySizes.Values.Where(x => x <= 100000).Sum();
    }

    public static long GetSmallestDirectorySizeForFreeSpace(string input)
    {
        Dictionary<string, long> directorySizes = GetDirectorySizes(input);
        
        const long diskSize = 70000000;
        const long requiredFreeSpace = 30000000;
        long currentFreeSpace = diskSize - directorySizes[""];
        long requiredDirectorySize = requiredFreeSpace - currentFreeSpace;

        return directorySizes.Values.Where(x => x >= requiredDirectorySize).Min();
    }

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