using System.Linq;

namespace AdventOfCode2022;

public static class Day8
{
    /// <summary>
    /// Gets the count of trees that are visible from outside the grid.
    /// </summary>
    /// <param name="input">The grid of trees.</param>
    /// <returns>The count of visible trees.</returns>
    public static int GetVisibleTrees(string input)
    {
        int[][] grid = InputToMatrix(input);

        int visibleTrees = (grid.Length * 2) + ((grid[0].Length - 2) * 2);
        for (int x = 1; x < grid.Length - 1; x++)
        {
            for (int y = 1; y < grid[x].Length - 1; y++)
            {
                int currentTree = grid[x][y];

                bool isVisibleFromTheNorth = true;
                for (int xi = 0; xi < x; xi++)
                {
                    isVisibleFromTheNorth = grid[xi][y] < currentTree;
                    if (!isVisibleFromTheNorth) break;
                }
                
                bool isVisibleFromTheEast = true;
                for (int yi = grid[x].Length - 1; yi > y; yi--)
                {
                    isVisibleFromTheEast = grid[x][yi] < currentTree;
                    if (!isVisibleFromTheEast) break;
                }
                
                bool isVisibleFromTheSouth = true;
                for (int xi = grid.Length - 1; xi > x; xi--)
                {
                    isVisibleFromTheSouth = grid[xi][y] < currentTree;
                    if (!isVisibleFromTheSouth) break;
                }
                
                bool isVisibleFromTheWest = true;
                for (int yi = 0; yi < y; yi++)
                {
                    isVisibleFromTheWest = grid[x][yi] < currentTree;
                    if (!isVisibleFromTheWest) break;
                }

                if (isVisibleFromTheNorth ||
                    isVisibleFromTheEast ||
                    isVisibleFromTheSouth ||
                    isVisibleFromTheWest) visibleTrees++;
            }
        }

        return visibleTrees;
    }
    
    /// <summary>
    /// Gets the scenic score based on amount of trees seen before another tree obstructs the view.
    /// </summary>
    /// <param name="input">The grid of trees.</param>
    /// <returns>The maximum tree score.</returns>
    public static int GetMaxTreeScore(string input)
    {
        int[][] grid = InputToMatrix(input);

        int maxScore = 0;
        for (int x = 1; x < grid.Length - 1; x++)
        {
            for (int y = 1; y < grid[x].Length - 1; y++)
            {
                int currentTree = grid[x][y];

                int bottom = 0;
                for (int xi = x + 1; xi < grid[x].Length; xi++)
                {
                    bottom++;
                    if (currentTree <= grid[xi][y]) break;
                }

                int top = 0;
                for (int xi = x - 1; xi >= 0; xi--)
                {
                    top++;
                    if (currentTree <= grid[xi][y]) break;
                }

                int right = 0;
                for (int yi = y + 1; yi < grid.Length; yi++)
                {
                    right++;
                    if (currentTree <= grid[x][yi]) break;
                }

                int left = 0;
                for (int yi = y - 1; yi >= 0; yi--)
                {
                    left++;
                    if (currentTree <= grid[x][yi]) break;
                }

                int score = top * right * bottom * left;
                if (score > maxScore) maxScore = score;
            }
        }

        return maxScore;
    }

    /// <summary>
    /// Converts a grid of integers to a two dimensional array.
    /// </summary>
    /// <param name="input">The grid of integers.</param>
    /// <returns>The two dimensional integer array.</returns>
    public static int[][] InputToMatrix(string input)
    {
        return input
            .Split("\n")
            .Select(row => row
                .Select(col => int.Parse(col.ToString()))
                .ToArray())
            .ToArray();
    }
}