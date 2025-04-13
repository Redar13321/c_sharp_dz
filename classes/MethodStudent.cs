namespace ConsoleApp3
{
    public class MethodStudent
    {
        private string _fullName;
        private readonly int _groupNumber;
        private readonly string _recordBookNumber;
        private readonly string _snils;

        public string GetFullName() => _fullName;
        public void SetFullName(string value) => _fullName = value;
        public int GetGroupNumber() => _groupNumber;
        public string GetRecordBookNumber() => _recordBookNumber;
        public string GetSNILS() => _snils;

        public MethodStudent(string fullName, int groupNumber, string recordBookNumber, string snils)
        {
            _fullName = fullName;
            _groupNumber = groupNumber;
            _recordBookNumber = recordBookNumber;
            _snils = snils;
        }

        public string GetInformation() => $"Student: {GetFullName()}, Group: {GetGroupNumber()}, RecordBook: {GetRecordBookNumber()}, SNILS: {GetSNILS()}";
    }
}
