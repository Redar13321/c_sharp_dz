using ConsoleApp2.classes;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    internal class Program
    {
        static int _jobCount = 0;
        static void printJob(Action job)
        {
            Console.WriteLine($"Вариант {++_jobCount}");
            job();
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            printJob(() =>
            {
                Point point = new Point { X = 1, Y = 2, Z = 3 };
                Console.WriteLine($"Начальная точка: ({point.X}, {point.Y}, {point.Z})");
                point.MoveBy(2, -1, 0.5);
                Console.WriteLine($"После перемещения: ({point.X}, {point.Y}, {point.Z})");
            });

            printJob(() =>
            {
                User user = new User
                {
                    LastName = "Иванов",
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    Age = 30
                };
                Console.WriteLine($"ФИО: {user.GetFullName()}, Возраст: {user.Age}");
            });

            printJob(() =>
            {
                PersonalComputer pc = new PersonalComputer
                {
                    Model = "Dell XPS",
                    CpuFrequency = 3.5,
                    RamSize = 16,
                    HddSize = 512
                };
                Console.WriteLine(pc.Info());
            });

            printJob(() =>
            {
                Laptop laptop = new Laptop
                {
                    Model = "MacBook Pro",
                    CpuFrequency = 2.8,
                    RamSize = 8,
                    HddSize = 256,
                    Weight = 1.4
                };
                Console.WriteLine(laptop.Info());
            });

            printJob(() =>
            {
                Smartphone phone = new Smartphone
                {
                    Model = "iPhone 13",
                    CpuFrequency = 3.2,
                    RamSize = 4,
                    StorageSize = 128,
                    OsType = "iOS",
                    Weight = 174
                };
                Console.WriteLine(phone.Info);
            });

            printJob(() =>
            {
                Rectangle rect = new Rectangle
                {
                    TopLeft = new Point { X = 1, Y = 4 },
                    BottomRight = new Point { X = 5, Y = 1 }
                };
                Console.WriteLine($"Периметр: {rect.Perimeter()}, Площадь: {rect.Area()}");
            });

            printJob(() =>
            {
                Triangle triangle = new Triangle
                {
                    SideA = 3,
                    SideB = 4,
                    SideC = 5
                };
                triangle.PrintInfo();
            });

            printJob(() =>
            {
                Mail mail = new Mail
                {
                    ZipCode = "123456",
                    City = "Москва",
                    Street = "Ленина",
                    House = "10",
                    Building = "2",
                    Apartment = "34",
                    Message = "Привет! Как дела?"
                };
                Console.WriteLine($"Адрес: {mail.GetAddress()}");
                Console.WriteLine($"Сообщение: {mail.Message}");
            });

            printJob(() =>
            {
                Circle circle = new Circle
                {
                    Center = new Point { X = 0, Y = 0 },
                    Radius = 5
                };
                Console.WriteLine($"Длина окружности: {circle.Circumference():F2}");
                Console.WriteLine($"Площадь: {circle.Area():F2}");
            });

            printJob(() =>
            {
                Square square = new Square
                {
                    TopLeft = new Point { X = 1, Y = 1 },
                    SideLength = 4
                };
                Console.WriteLine($"Периметр: {square.Perimeter()}, Площадь: {square.Area()}");
            });
        }
    }
}
