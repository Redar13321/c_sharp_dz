namespace ConsoleApp3
{
    public class Dish : MenuItem
    {
        private int Calories { get; }
        private int WeightGrams { get; }

        public Dish(string name, decimal price, string category, int calories, int weightGrams)
            : base(name, price, category)
        {
            Calories = calories;
            WeightGrams = weightGrams;
        }

        public decimal PricePerGram() => Price / WeightGrams;

        public override string GetInfo() => $"{base.GetInfo()}, Calories: {Calories}, Weight: {WeightGrams}g";
    }
}
