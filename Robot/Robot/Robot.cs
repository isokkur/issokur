using System;
using System.Threading;

namespace Robot1
{
    public class Robot
    {
        private int x; // координата x
        private int y; // координата y
        private string name; // имя робота

        // Конструктор с параметром name
        public Robot(string name)
        {
            this.name = name; // присваиваем имя роботу
            x = 0; // начальная координата x равна 0
            y = 0; // начальная координата y равна 0
        }

        // Метод Move, отвечающий за движение робота
        public void Move()
        {
            Random random = new Random(); // создаем экземпляр класса Random
            int direction = random.Next(4); // генерируем случайное число от 0 до 3

            // Используем оператор switch для выбора направления движения
            switch (direction)
            {
                case 0:
                    // Вперед
                    y++; // увеличиваем значение y на 1
                    Console.WriteLine("Робот {0} двигается вперёд", name);
                    break;
                case 1:
                    // Назад
                    y--; // уменьшаем значение y на 1
                    Console.WriteLine("Робот {0} двигается назад", name);
                    break;
                case 2:
                    // Поворот налево
                    x--; // уменьшаем значение x на 1
                    Console.WriteLine("Робот {0} поворачивает налево", name);
                    break;
                case 3:
                    // Поворот направо
                    x++; // увеличиваем значение x на 1
                    Console.WriteLine("Робот {0} поворачивает направо", name);
                    break;
            }
        }

        // Метод GetInfo, выводящий информацию о текущих координатах робота
        public void GetInfo()
        {
            Console.WriteLine("Робот {0} находится на координатах ({1}, {2})", name, x, y);
        }
    }
}
