namespace ConsoleApp5.classes
{
    public class Person
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }

        public static string operator +(Person a, Person b)
        {
            if (a.EyeColor == "brown" || b.EyeColor == "brown") return "brown";
            if (a.EyeColor == "green" && b.EyeColor == "green") return "green";
            return "blue";
        }
    }
}
