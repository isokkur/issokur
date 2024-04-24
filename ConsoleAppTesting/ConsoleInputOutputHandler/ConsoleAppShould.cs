using System;
using ConsoleAppTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ConsoleAppTesting.Tests
{
    public class ProgramTests
    {
        [TestCase(3, 4)] // ������� ��� �������� ���������� ��������� ������
        [TestCase(0, 5)] // ������ �������� ������
        public void TestMultiply(int x, int y) // ����� ������������ ���������
        {
            int result = Program.Multiply(x, y); // ����� ������ Multiply �� ������ Program
            Assert.AreEqual(x * y, result); // �������� ������������ ���������� � ��������� ����������
        }

        [Test] 
        public void TestMatrixMultiplication() //������������ ��������� ������
        {
            int[,] expected = { // �������
                {1, 2, 3},
                {2, 4, 6},
                {3, 6, 9}
            };

            int[,] actual = new int[3, 3]; // �������� ������� ��� �������� �����������

            for (int i = 0; i < 3; i++) // ���� �� ������� �������
            {
                for (int j = 0; j < 3; j++) // ���� �� �������� �������
                {
                    actual[i, j] = Program.Multiply(i + 1, j + 1); // ���������� �������� �������
                }
            }

            CollectionAssert.AreEqual(expected, actual); // �������� ��������� ��������� � ���������� ������
        }
    }
}