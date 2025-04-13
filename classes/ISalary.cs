namespace ConsoleApp4.classes
{
    // Task 4
    public interface ISalary
    {
        string EmployeeName { get; }
        int WorkDays { get; }
        decimal CalculateSalary();
    }
}
