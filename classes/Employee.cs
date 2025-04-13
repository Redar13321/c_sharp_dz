namespace ConsoleApp4.classes
{
    // Task 6
    public struct Employee
    {
        public string LastName { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string Position { get; }
        public int HireYear { get; }

        public string Info => $"{LastName} {FirstName} {MiddleName}, {Position}, hired in {HireYear}";

        public Employee(string lastName, string firstName, string middleName, string position, int hireYear)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Position = position;
            HireYear = hireYear;
        }

        public int GetExperience(int currentYear)
        {
            return currentYear - HireYear;
        }
    }
}
