namespace ConsoleApp5.classes
{
    public class Cat
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }

        public static bool operator <(Cat a, Cat b) => a.Weight < b.Weight;
        public static bool operator >(Cat a, Cat b) => a.Weight > b.Weight;
        public static string operator *(Cat a, Cat b) =>
            a.Breed == b.Breed ? "Breeding possible" : "Breeding impossible";
    }
}
