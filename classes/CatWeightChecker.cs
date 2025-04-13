namespace ConsoleApp5.classes
{
    public static class CatWeightChecker
    {
        public static double SmallWeight = 1.0;
        public static double MediumWeight = 3.0;
        public static double LargeWeight = 5.0;

        public static string CheckWeight(Cat cat)
        {
            if (cat.Weight < SmallWeight) return "Cat is very thin";
            if (cat.Weight < MediumWeight) return "Cat is thin";
            if (cat.Weight < LargeWeight) return "Cat is slightly overweight";
            return "Cat is overweight";
        }
    }
}
