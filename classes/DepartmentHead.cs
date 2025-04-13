namespace ConsoleApp4.classes
{
    public class DepartmentHead : ISalary, IEmployeeConsoleOutput
    {
        public string EmployeeName { get; }
        public int WorkDays { get; }

        public DepartmentHead(string employeeName, int workDays)
        {
            EmployeeName = employeeName;
            WorkDays = workDays;
        }

        public decimal CalculateSalary()
        {
            return WorkDays * 2500;
        }

        public void Print()
        {
            Console.WriteLine($"Сотрудник: {EmployeeName}");
            Console.WriteLine($"Должность: Глава отдела");
            Console.WriteLine($"Рабочих дней: {WorkDays}");
            Console.WriteLine($"Зарплата: {CalculateSalary()}");
        }
    }
}
