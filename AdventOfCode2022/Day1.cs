using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022;

public static class Day1
{
    /// <summary>
    /// Splits input by individual inventories and sums the total calories for each.
    /// </summary>
    /// <param name="input">List of inventories. Each item is separated by a new line, while inventories are separated by two new lines.</param>
    /// <returns>Inventories as sum of calories, in order provided by the input.</returns>
    public static IEnumerable<int> InventoriesToCalories(string input)
    {
        return input
            .Split("\n\n")
            .Select(inventory => inventory.Split("\n")
                .Select(int.Parse)
                .Sum());
    }
    
    /// <summary>
    /// Gets the sum of the inventory with the max calories.
    /// </summary>
    /// <param name="input">List of inventories. Each item is separated by a new line, while inventories are separated by two new lines.</param>
    /// <returns>The sum of calories.</returns>
    public static int GetMaxCombinedCalories(string input)
    {
        return InventoriesToCalories(input).Max();
    }
    
    /// <summary>
    /// Gets the sum of calories for the top 3 inventories with the highest calories.
    /// </summary>
    /// <param name="input">List of inventories. Each item is separated by a new line, while inventories are separated by two new lines.</param>
    /// <returns>The sum of calories.</returns>
    public static int GetTop3CombinedCalories(string input)
    {
        return InventoriesToCalories(input)
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}