namespace ConsoleApp4.classes
{
    public class Accounting
    {
        public decimal CalculateIncomeTax(ISalary employee)
        {
            return employee.CalculateSalary() * 0.13m;
        }
    }
}
