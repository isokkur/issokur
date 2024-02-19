using System;

namespace YourNamespace
{
    public static class MathHelper
    {
        public static double CalculateFunction(double x, double N)
        {
            if (x - N == 0)
            {
                throw new DivideByZeroException("Деление на 0 недопустимо.");
            }

            if (x < 0 || x > k) // Здесь k должно быть объявлено
            {
                throw new ArgumentOutOfRangeException("x", "Значение x находится за пределами диапазона.");
            }

            return 1 / (x - N);
        }
    }
}