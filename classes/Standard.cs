namespace ConsoleApp5.classes
{
    public static class Standard
    {
        public static int StudentsCount = 100;
        public static int TeachersCount = 10;

        public static bool CheckCollege(College college)
        {
            return college.StudentsCount >= StudentsCount &&
                   college.TeachersCount >= TeachersCount;
        }
    }
}
