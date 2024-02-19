using Robot1;

namespace PotokConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot("Robot1"); // создаем экземпляр класса Robot с именем "Robot1"
            for (int i = 0; i < 10; i++)
            {
                robot.Move(); // вызываем метод Move у робота
                Thread.Sleep(1000); // приостанавливаем выполнение программы на 1 секунду
                robot.GetInfo(); // вызываем метод GetInfo у робота
            }
        }
    }
}