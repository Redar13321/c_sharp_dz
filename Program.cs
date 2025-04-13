using ConsoleApp4.classes;

namespace ConsoleApp4
{

    internal class Program
    {
        static int _jobCount = 0;
        static void printJob(Action job)
        {
            Console.WriteLine($"Задание {++_jobCount}");
            job();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            printJob(() =>
            {
                var scooterRental = new TransportRental<Scooter>(
                    "John Doe",
                    new Scooter(0.5m, "Xiaomi Pro", 2020),
                    30);

                Console.WriteLine(scooterRental.GetRentalInfo());
                Console.WriteLine($"Total cost: {scooterRental.CalculateTotalCost()}");

                var carRental = new TransportRental<Car>(
                    "Alice Smith",
                    new Car(2.5m, "ABC123", "Toyota", "Camry", "Red"),
                    120);

                Console.WriteLine("\n" + carRental.GetRentalInfo());
                Console.WriteLine($"Total cost: {carRental.CalculateTotalCost()}");
            });

            printJob(() =>
            {
                var swordCharacter = new GameCharacter<Sword>(
                    "Arthur",
                    "Human",
                    new Sword(15, "Critical hit", "Unique"),
                    20);

                Console.WriteLine(swordCharacter.GetCharacterInfo());
                Console.WriteLine($"Total power: {swordCharacter.GetTotalPower()}");

                var bowCharacter = new GameCharacter<Bow>(
                    "Legolas",
                    "Elf",
                    new Bow(12, "Double shot", 90, 95),
                    18);

                Console.WriteLine("\n" + bowCharacter.GetCharacterInfo());
                Console.WriteLine($"Total power: {bowCharacter.GetTotalPower()}");
            });

            printJob(() =>
            {
                ITax bread = new NecessityItem("Bread", 50);
                ((IConsoleOutput)bread).Print();

                ITax diamondRing = new LuxuryItem("Diamond Ring", 10000);
                ((IConsoleOutput)diamondRing).Print();
            });

            printJob(() =>
            {
                ISalary manager = new Manager("Ivan Petrov", 20);
                ((IEmployeeConsoleOutput)manager).Print();
                Console.WriteLine($"Income tax: {new Accounting().CalculateIncomeTax(manager)}");

                ISalary head = new DepartmentHead("Maria Ivanova", 22);
                ((IEmployeeConsoleOutput)head).Print();
                Console.WriteLine($"Income tax: {new Accounting().CalculateIncomeTax(head)}");
            });

            printJob(() =>
            {
                List<CarStruct> cars = new List<CarStruct>
                {
                    new CarStruct("VIN001", "Toyota", "Camry", 2018, "Black"),
                    new CarStruct("VIN002", "Honda", "Accord", 2020, "White"),
                    new CarStruct("VIN003", "BMW", "X5", 2015, "Blue"),
                    new CarStruct("VIN004", "Mercedes", "E-Class", 2022, "Silver"),
                    new CarStruct("VIN005", "Audi", "A4", 2019, "Red")
                };

                Console.WriteLine("Original list:");
                cars.ForEach(c => Console.WriteLine(c.Info));

                Console.WriteLine("\nAdding new car:");
                cars.Add(new CarStruct("VIN006", "Ford", "Focus", 2021, "Gray"));
                cars.ForEach(c => Console.WriteLine(c.Info));

                Console.WriteLine("\nSorted by year:");
                cars = cars.OrderBy(c => c.Year).ToList();
                cars.ForEach(c => Console.WriteLine(c.Info));

                Console.WriteLine("\nRemoving car with VIN003:");
                cars.RemoveAll(c => c.EngineVIN == "VIN003");
                cars.ForEach(c => Console.WriteLine(c.Info));

                Console.WriteLine("\nChecking VIN:");
                var car = cars.First();
                Console.WriteLine(car.CheckVIN("VIN001"));
                Console.WriteLine(car.CheckVIN("WRONGVIN"));
            });

            printJob(() =>
            {
                List<Employee> employees = new List<Employee>
                {
                    new Employee("Smith", "John", "A.", "Developer", 2018),
                    new Employee("Johnson", "Alice", "B.", "Manager", 2020),
                    new Employee("Williams", "Bob", "C.", "Designer", 2015),
                    new Employee("Brown", "Emma", "D.", "Analyst", 2022),
                    new Employee("Jones", "Michael", "E.", "Tester", 2019)
                };

                Console.WriteLine("Original list:");
                employees.ForEach(e => Console.WriteLine(e.Info));

                Console.WriteLine("\nAdding new employee:");
                employees.Add(new Employee("Davis", "Sarah", "F.", "HR", 2021));
                employees.ForEach(e => Console.WriteLine(e.Info));

                Console.WriteLine("\nSorted by last name:");
                employees = employees.OrderBy(e => e.LastName).ToList();
                employees.ForEach(e => Console.WriteLine(e.Info));

                Console.WriteLine("\nRemoving employee Bob C. Williams:");
                employees.RemoveAll(e => e.LastName == "Williams" &&
                                       e.FirstName == "Bob" &&
                                       e.MiddleName == "C.");
                employees.ForEach(e => Console.WriteLine(e.Info));

                Console.WriteLine("\nCalculating experience (current year 2023):");
                employees.ForEach(e =>
                    Console.WriteLine($"{e.LastName}: {e.GetExperience(2023)} years"));
            });
        }
    }
}
