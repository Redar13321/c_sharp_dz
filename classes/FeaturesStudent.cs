namespace ConsoleApp3
{
    // 1. Student classes
    public class FeaturesStudent
    {
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        public int GroupNumber { get; }
        public string RecordBookNumber { get; }
        public string SNILS { get; }

        public FeaturesStudent(string fullName, int groupNumber, string recordBookNumber, string snils)
        {
            _fullName = fullName;
            GroupNumber = groupNumber;
            RecordBookNumber = recordBookNumber;
            SNILS = snils;
        }

        public string Information => $"Student: {FullName}, Group: {GroupNumber}, RecordBook: {RecordBookNumber}, SNILS: {SNILS}";
    }
}
