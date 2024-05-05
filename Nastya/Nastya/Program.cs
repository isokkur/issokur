using System;

class MainClass
{
    public static void Main(string[] args)
    {
        int x = GetUserInput("Введите целое число x:");
        int y = GetUserInput("Введите целое число y:");

        if (x < 1 || y < 1)
        {
            Console.WriteLine("Введены некорректные числа. Числа должны быть целыми положительными.");
            return;
        }

        int[,] matrix = new int[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = (i + 1) * (j + 1);
            }
        }

        Console.WriteLine("Матрица умножения:");
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static int GetUserInput(string message)
    {
        int input;
        do
        {
            Console.WriteLine(message);
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }
}