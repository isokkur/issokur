﻿
using Xunit;

public class MultiplicationMatrixTests
{

    [Fact]
    public void TestMultiplicationMatrix()
    {
        // Arrange
        int[,] expectedMatrix = {
            {1, 2, 3},
            {2, 4, 6},
            {3, 6, 9},
            {4, 8, 12}
        };

        // Act
        int[,] actualMatrix = GenerateMultiplicationMatrix(3, 4);

        // Assert
        Assert.Equal(expectedMatrix, actualMatrix);
    }

    [Fact]
    public void TestInvalidInput()
    {
        // Arrange
        string expectedOutput = "Введены некорректные числа. Числа должны быть целыми положительными.";

        // Act
        string actualOutput = GetUserInputOutput("-1\n0\n3\n4");

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    static int[,] GenerateMultiplicationMatrix(int x, int y)
    {
        int[,] matrix = new int[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = (i + 1) * (j + 1);
            }
        }

        return matrix;
    }

    static string GetUserInputOutput(string input)
    {
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        var consoleInput = new System.IO.StringReader(input);
        Console.SetIn(consoleInput);

        MainClass.Main(new string[0]);

        return consoleOutput.ToString().Trim();
    }
}