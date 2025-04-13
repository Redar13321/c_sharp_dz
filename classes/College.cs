namespace ConsoleApp5.classes
{
    public class College
    {
        public string Name { get; set; }
        public int StudentsCount { get; set; }
        public int ClassroomsCount { get; set; }
        public int TeachersCount { get; set; }

        public static bool operator <(College a, College b)
        {
            if (a.StudentsCount == b.StudentsCount)
                return a.ClassroomsCount < b.ClassroomsCount;
            return a.StudentsCount < b.StudentsCount;
        }

        public static bool operator >(College a, College b)
        {
            if (a.StudentsCount == b.StudentsCount)
                return a.ClassroomsCount > b.ClassroomsCount;
            return a.StudentsCount > b.StudentsCount;
        }
    }
}
