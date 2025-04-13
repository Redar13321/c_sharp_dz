namespace ConsoleApp5.classes
{
    public class Country
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }

        public static Country operator +(Country a, Country b)
        {
            return new Country
            {
                Name = $"{a.Name} + {b.Name}",
                Population = a.Population + b.Population,
                Area = a.Area + b.Area
            };
        }

        public static bool operator <(Country a, Country b)
        {
            if (a.Population == b.Population)
                return a.Area < b.Area;
            return a.Population < b.Population;
        }

        public static bool operator >(Country a, Country b)
        {
            if (a.Population == b.Population)
                return a.Area > b.Area;
            return a.Population > b.Population;
        }
    }
}
