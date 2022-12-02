using System;
using System.Linq;

namespace AdventOfCode2022;

public static class Day2
{
    /// <summary>
    /// Calculates the possible score assuming responses are referencing rock, paper, or scissors respectively.
    /// </summary>
    /// <param name="input">Array of characters ABC for the opponent's play and XYZ for your play, separated by newlines.</param>
    /// <returns>The calculated score based on the provided input.</returns>
    public static int GetScoreForInputByResponse(string input)
    {
        return input
            .Split("\n")
            .Sum(GetScoreForRoundByResponse);
    }
    
    /// <summary>
    /// Calculates the possible score assuming responses are referencing the need to lose, draw, or win respectively.
    /// </summary>
    /// <param name="input">Array of characters ABC for the opponent's play and XYZ for the game's result, separated by newlines.</param>
    /// <returns>The calculated score based on the provided input.</returns>
    public static int GetScoreForInputByResult(string input)
    {
        return input
            .Split("\n")
            .Sum(GetScoreForRoundByResult);
    }

    private static int GetScoreForRoundByResponse(string input)
    {
        /* Them   You   Translation   Play Score
         * A      X     Rock          1
         * B      Y     Paper         2
         * C      Z     Scissors      3
         *
         * Win = 6 pts
         * Lose = 0 pts
         * Draw = 3 pts
         */

        int playScore = input[^1] switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => throw new Exception($"Input {input} is not valid.")
        };

        int outcomeScore = input switch
        {
            "A X" => 3,
            "A Y" => 6,
            "A Z" => 0,
            "B X" => 0,
            "B Y" => 3,
            "B Z" => 6,
            "C X" => 6,
            "C Y" => 0,
            "C Z" => 3,
            _ => throw new Exception($"Input {input} is not valid.")
        };

        return playScore + outcomeScore;
    }

    private static int GetScoreForRoundByResult(string input)
    {
        /* Play     Translation     Play Score
         * A        Rock            1
         * B        Paper           2
         * C        Scissors        3
         *
         * Result   Translation     Score
         * X        Lose            0
         * Y        Draw            3
         * Z        Win             6
         */

        int outcomeScore = input[^1] switch
        {
            'X' => 0,
            'Y' => 3,
            'Z' => 6,
            _ => throw new Exception($"Input {input} is not valid.")
        };

        int playScore = input switch
        {
            "A X" => 3,
            "A Y" => 1,
            "A Z" => 2,
            "B X" => 1,
            "B Y" => 2,
            "B Z" => 3,
            "C X" => 2,
            "C Y" => 3,
            "C Z" => 1,
            _ => throw new Exception($"Input {input} is not valid.")
        };

        return playScore + outcomeScore;
    }
}