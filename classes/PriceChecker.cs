namespace ConsoleApp5.classes
{
    public static class PriceChecker
    {
        public static double SmallPrice = 100;
        public static double MediumPrice = 500;
        public static double LargePrice = 1500;

        public static string CheckPrice(Ingredient ingredient)
        {
            if (ingredient.Price < SmallPrice) return "Price is very low";
            if (ingredient.Price < MediumPrice) return "Price is low";
            if (ingredient.Price < LargePrice) return "Price is high";
            return "Price is too high";
        }
    }
}
