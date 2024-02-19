using System;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double N;
            double k;
            Console.Write("Введите значение N: ");
            N = double.Parse(Console.ReadLine());
            Console.Write("Введите значение k: ");
            k = double.Parse(Console.ReadLine());

            for (x = 0; x <= k; x += 0.1)
            {
                try
                {
                    double result = MathHelper.CalculateFunction(x, N);
                    Console.WriteLine($"f({x}) = {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}