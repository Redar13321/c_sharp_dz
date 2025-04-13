namespace ConsoleApp4.classes
{
    public class Manager : ISalary, IEmployeeConsoleOutput
    {
        public string EmployeeName { get; }
        public int WorkDays { get; }

        public Manager(string employeeName, int workDays)
        {
            EmployeeName = employeeName;
            WorkDays = workDays;
        }

        public decimal CalculateSalary()
        {
            return WorkDays * 1000;
        }

        public void Print()
        {
            Console.WriteLine($"Сотрудник: {EmployeeName}");
            Console.WriteLine($"Должность: Менеджер");
            Console.WriteLine($"Рабочих дней: {WorkDays}");
            Console.WriteLine($"Зарплата: {CalculateSalary()}");
        }
    }
}
