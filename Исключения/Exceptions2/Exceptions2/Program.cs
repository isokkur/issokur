using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите значение A: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Введите значение B: ");
            int B = int.Parse(Console.ReadLine());

            if (A == 0 && B == 0)
            {
                Console.WriteLine("Уравнение имеет бесконечное множество решений.");
            }
            else if (B % A == 0)
            {
                int x = B / A;
                Console.WriteLine($"Решение уравнения: x = {x}");
            }
            else
            {
                throw new Exception("Уравнение не имеет решений.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Введено некорректное значение.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}