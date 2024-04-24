using System;

namespace ConsoleAppTesting
{
    public class Program
    {
        public static void Main() 
        {
            Console.WriteLine("Введите два числа для построения матрицы умножения:");

            if (int.TryParse(Console.ReadLine(), out int x) && int.TryParse(Console.ReadLine(), out int y)) // Считывание и проверка введенных пользователем чисел
            {
                if (x <= 0 || y <= 0) // Проверка наличия корректных чисел
                {
                    Console.WriteLine("Числа должны быть больше нуля."); //ошибка
                }
                else
                {
                    int[,] multiplicationTable = new int[x, y]; // Создание матрицы умножения

                    for (int i = 0; i < x; i++) // Цикл по строкам матрицы
                    {
                        for (int j = 0; j < y; j++) // Цикл по столбцам матрицы
                        {
                            multiplicationTable[i, j] = (i + 1) * (j + 1); // Вычисление элемента матрицы
                        }
                    }

                    Console.WriteLine("Матрица умножения:"); // Заголовок

                    for (int i = 0; i < x; i++) // Цикл по строкам матрицы
                    {
                        for (int j = 0; j < y; j++) // Цикл по столбцам матрицы
                        {
                            Console.Write(multiplicationTable[i, j] + "\t"); // Вывод элемента матрицы с табуляцией
                        }
                        Console.WriteLine(); // Переход на новую строку
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод чисел."); //ошибка
            }
        }

        public static int Multiply(int x, int y) // Метод для умножения двух чисел
        {
            return x * y; // Возвращение результата
        }
    }
}