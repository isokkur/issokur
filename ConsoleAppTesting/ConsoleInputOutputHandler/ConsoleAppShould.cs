using System;
using ConsoleAppTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ConsoleAppTesting.Tests
{
    public class ProgramTests
    {
        [TestCase(3, 4)] // Атрибут для указания параметров тестового случая
        [TestCase(0, 5)] // Другой тестовый случай
        public void TestMultiply(int x, int y) // Метод тестирования умножения
        {
            int result = Program.Multiply(x, y); // Вызов метода Multiply из класса Program
            Assert.AreEqual(x * y, result); // Проверка соответствия ожидаемого и реального результата
        }

        [Test] 
        public void TestMatrixMultiplication() //тестирование умножения матриц
        {
            int[,] expected = { // матрица
                {1, 2, 3},
                {2, 4, 6},
                {3, 6, 9}
            };

            int[,] actual = new int[3, 3]; // Создание матрицы для хранения результатов

            for (int i = 0; i < 3; i++) // Цикл по строкам матрицы
            {
                for (int j = 0; j < 3; j++) // Цикл по столбцам матрицы
                {
                    actual[i, j] = Program.Multiply(i + 1, j + 1); // Вычисление элемента матрицы
                }
            }

            CollectionAssert.AreEqual(expected, actual); // Проверка равенства ожидаемой и полученной матриц
        }
    }
}