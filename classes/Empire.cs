namespace ConsoleApp5.classes
{
    public static class Empire
    {
        public static long Population = 300000;
        public static double Area = 900000;

        public static string CheckCountry(Country country)
        {
            return country.Population >= Population && country.Area >= Area
                ? "This country is an empire"
                : "This country is not an empire";
        }
    }
}
