using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Введите первое число: ");
                int number1 = int.Parse(Console.ReadLine());

                Console.Write("Введите второе число: ");
                int number2 = int.Parse(Console.ReadLine());

                int result = number1 / number2;
                Console.WriteLine($"Результат деления: {result}");

                // Если деление выполнено, то вводим следующие 2 числа
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка! Деление на ноль.");
                break; // Выход из бесконечного цикла
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Некорректный ввод числа.");
                continue; // Продолжаем бесконечный цикл
            }
            finally
            {
                Console.WriteLine("Выполняется блок finally.");
            }
        }

        Console.WriteLine("Программа завершена.");
    }
}